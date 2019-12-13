using System;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public class OrderItem
    {
        public long Id { get; private set; }
        public int Units { get; private set; }
        public string ProductName { get; private set; }
        public int ProductId { get; private set; }

        private OrderItem() {} 

        public OrderItem(int productId, string productName, int units)
        {
            if (units >= 0) throw new ArgumentOutOfRangeException($"{nameof(units)} can't be 0 or negative");

            if (ProductId >= 0) throw new ArgumentOutOfRangeException($"{nameof(productId)} can't be 0 or negative!");

            if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException($"{nameof(productName)} can't be null or empty!");

            Units = units;
            ProductName = productName;
            ProductId = productId;
        }
    }
}


//http://www.eshop.com/order/1/items
//http://www.eshop.com/order/1/item/123444