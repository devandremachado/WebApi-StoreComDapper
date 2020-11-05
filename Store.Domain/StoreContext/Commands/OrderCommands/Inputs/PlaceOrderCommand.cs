using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
             OrderItems = new List<OrderItemCommand>();  
        }

        public Guid IdCustomer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(IdCustomer.ToString(), 36, "IdCustomer", "Identificador do cliente inválido")
                .IsGreaterOrEqualsThan(OrderItems.Count, 0, "Items", "Nehum item no pedido foi encontrado")
            );
            return Valid;
        }
    }

    public class OrderItemCommand
    {
        public Guid IdProduct { get; set; }
        public decimal Quantity { get; set; }
    }
}