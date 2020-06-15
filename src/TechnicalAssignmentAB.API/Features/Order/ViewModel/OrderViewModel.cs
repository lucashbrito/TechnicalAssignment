using System;
using System.Collections.Generic;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class OrderViewModel
    {
        public Guid OrderId { get; }
        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public List<OrderItemViewModel> OrderItemViewModels { get; }

        public OrderViewModel(Guid orderId, decimal price, DateTime createdAt)
        {
            OrderId = orderId;
            Price = price;
            CreatedAt = createdAt;
        }

        public void SetOrderItemViewModelList(IReadOnlyCollection<OrderItem> orderItems)
        {
            if (orderItems != null || orderItems.Count > 0)
            {
                foreach (var orderItem in orderItems)
                {
                    var orderItemViewModel = OrderItemViewModel.CreateOrderItemViewModel(orderItem.ProductId, orderItem.ProductName, orderItem.Unit);
                    OrderItemViewModels.Add(orderItemViewModel);
                }
            }
        }
    }
}
