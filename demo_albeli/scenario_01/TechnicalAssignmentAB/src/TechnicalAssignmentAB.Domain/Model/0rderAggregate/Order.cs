using System;
using System.Collections.Generic;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public sealed class Order : Identity
    {
        public Order(long id)
            : base(id) { }

        private Order()
        {
            _orderItems = new List<OrderItem>();

            OrderItems = _orderItems;
        }

        public long CustomerId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems;

        public Order(long customerId, decimal price)
            : this()
        {
            if (price <= 0) throw new ArgumentException($"invalid parameter {nameof(price)}");
            if (customerId <= 0) throw new ArgumentException($"invalid parameter {nameof(customerId)}");

            Price = price;
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
        }

        public void AddOrdemItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentException("");

            _orderItems.Add(orderItem);
        }
    }
}
