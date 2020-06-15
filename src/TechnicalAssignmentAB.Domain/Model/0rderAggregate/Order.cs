using System;
using System.Collections.Generic;
using TechnicalAssignmentAB.Domain.Core.DomainObject;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public sealed class Order : Entity, IAggregateRoot
    {
        private Order()
        {
            _orderItems = new List<OrderItem>();

            OrderItems = _orderItems;
        }

        public Guid CustomerId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems;

        public Order(Guid customerId, decimal price)
        {
            ValidationAssertionConcern.IsLessOrEquals(price, 0, "Price can't be less or equals 0");
            ValidationAssertionConcern.IsEquals(customerId, Guid.Empty, "Price can't be less or equals 0");

            Price = price;
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
        }

        public void AddOrdemItem(OrderItem orderItem)
        {
            ValidationAssertionConcern.IsNull(orderItem, "Order item can't null or empty");

            _orderItems.Add(orderItem);
        }
        public void RemoveOrdemItem(OrderItem orderItem)
        {
            ValidationAssertionConcern.IsNull(orderItem, "Order item can't null or empty");

            _orderItems.Remove(orderItem);
        }

        public override bool IsValid()
        {
            return Price > 0 && CustomerId != Guid.Empty;
        }
    }
}
