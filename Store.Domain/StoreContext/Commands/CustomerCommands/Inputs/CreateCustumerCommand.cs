using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerComands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Fail Fast Validation, validacoes simples
        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Address", "O email é invalido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );

            return Valid;
        }
    }
}