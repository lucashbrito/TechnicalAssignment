using System;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public sealed class Order : Identity
    {
        public Order(long id)
            : base(id) { }

        private Order() { }

        public long CustomerId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public Order(long customerId, decimal price)
        {
            if (price <= 0) throw new ArgumentException($"invalid parameter {nameof(price)}");
            if (customerId <= 0) throw new ArgumentException($"invalid parameter {nameof(customerId)}");
            
            Price = price;
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
        }
    }
}
