using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entites
{
    public class Delivery : Entity // Entrega
    {
        public Delivery (
            DateTime estimateDeliveryDate
        )

        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {   
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}