using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Address : Entity //Endereco
    {
        public Address (
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode,
            EAdressType type
        )

        {
            State = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAdressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }

    }
}