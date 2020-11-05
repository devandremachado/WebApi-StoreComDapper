using System;
using FluentValidator;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerComands.Inputs
{
    public class AddAdressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAdressType Type { get; set; }

        public bool IsValid()
        {
            return Valid;
        }
    }
}