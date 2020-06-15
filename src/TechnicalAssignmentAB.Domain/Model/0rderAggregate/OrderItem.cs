using System;
using TechnicalAssignmentAB.Domain.Core.DomainObject;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public class OrderItem : ValueObject<OrderItem>
    {
        public int Unit { get; private set; }
        public string ProductName { get; private set; }
        public Guid ProductId { get; private set; }

        public OrderItem(Guid productId, string productName, int unit)
        {
            ValidationAssertionConcern.IsLessOrEquals(unit, 0, $"{nameof(unit)} can't be less or equals 0");
            ValidationAssertionConcern.IsDifferent(productId, Guid.Empty, $"{nameof(productId)} can't be less or equals 0");
            ValidationAssertionConcern.IsEmpty(productName, $"{nameof(productName)} can't be null or empty!");

            Unit = unit;
            ProductName = productName;
            ProductId = productId;
        }

        protected override bool EqualsCore(OrderItem orderItem)
        {
            if (orderItem is null) return false;

            if (ReferenceEquals(this, orderItem)) return true;

            return orderItem.Unit.Equals(Unit) && orderItem.ProductName.Equals(ProductName) && orderItem.ProductId.Equals(ProductId);
        }
    }
}