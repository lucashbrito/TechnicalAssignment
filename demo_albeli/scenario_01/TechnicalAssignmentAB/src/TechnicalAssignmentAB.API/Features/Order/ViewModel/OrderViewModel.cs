using System;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class OrderViewModel
    {
        public long OrderId { get;  }
        public decimal Price { get; }
        public DateTime CreatedAt { get;  }

        public OrderViewModel(long orderId, decimal price, DateTime createdAt)
        {
            OrderId = orderId;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
