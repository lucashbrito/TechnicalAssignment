using System;
using System.Collections.Generic;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class OrderViewModel
    {
        public long OrderId { get; }
        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public IEnumerable<OrderItemViewModel> OrderItemViewModels { get; }

        public OrderViewModel(long orderId, decimal price, DateTime createdAt)
        {
            OrderId = orderId;
            Price = price;
            CreatedAt = createdAt;           
        }

        public void SetOrderItemViewModelList(IList<OrderItem> orderItem)
        {
            if (orderItem != null || orderItem.Count > 0)
            {
                foreach (var ordemItemViewModel in orderItem)
                {
                    var orderItem = new OrderItemViewModel(ordemItemViewModel.ProductId, ordemItemViewModel.ProductName, ordemItemViewModel.Units);
                    OrderItems.Add(orderItem);
                }
            }
        }
    }
}
