using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerComands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerComands.Outputs;
using Store.Domain.StoreContext.Entites;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers 
{
    
    public class CustomerHandler : 
        Notifiable, 
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAdressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o Email ja existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar as Entidades
            var customer = new Customer(name, document, email, command.Phone);

            // Validar os VOs e Entidades
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            
            // Retorna Erros (se houver)
            if(Invalid) {
                return new CommandResult(false, "Por favor, corrija os campos abaixo", Notifications);
            }
            
            // Persistir no Banco
            _repository.Save(customer);

            // Enviar Email
            _emailService.Send(email.Address, "andre.machado@gmail.com", "Bem vindo", "Seja bem vindo na Store");

            // Retornar o resultado
            return new CommandResult(true, "Bem vindo ao Store", new {
                Id = customer.Id, 
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
        
    }
}