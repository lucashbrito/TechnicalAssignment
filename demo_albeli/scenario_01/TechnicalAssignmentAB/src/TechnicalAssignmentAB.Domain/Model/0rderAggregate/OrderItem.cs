using System;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public class OrderItem
    {        
        public int Units { get; private set; }
        public string ProductName { get; private set; }
        public int ProductId { get; private set; }

        private OrderItem() {} 

        public OrderItem(int productId, string productName, int units)
        {
            if (units <= 0) throw new ArgumentException($"{nameof(units)} can't be 0 or negative!");

            if (productId <= 0) throw new ArgumentException($"{nameof(productId)} can't be 0 or negative!");

            if (string.IsNullOrEmpty(productName)) throw new ArgumentException($"{nameof(productName)} can't be null or empty!");

            Units = units;
            ProductName = productName;
            ProductId = productId;
        }
    }
}