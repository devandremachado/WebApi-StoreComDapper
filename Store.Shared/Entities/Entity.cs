using System;
using FluentValidator;

namespace Store.Shared.Entities
{
    // abstract = nao pode ser instanciada
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; private set; }
    }
}