using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entites
{
    public class Order : Entity // Pedido
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order (
            Customer customer
        )

        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray();} }
        public IReadOnlyCollection<Delivery> Deliveries { get { return _deliveries.ToArray();} }
        
        public void AddItem(Product product, decimal quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        public void Place() // Criar um pedido
        {
            //Gera numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            if(_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
            
        }

        public void Pay() // Pagar um pedido
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship() //Enviar um pedido
        {
            // A cada 5 produtos monta uma nova entrega
            var deliveries = new List<Delivery>();
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count ++;
            }

            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x =>  _deliveries.Add(x));
        }

        public void Cancel() //Cancelar um pedido
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x=> x.Cancel());
        }
    }
}