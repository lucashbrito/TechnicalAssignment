using System;
using System.Collections.Generic;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class OrderItemViewModel
    {
        public int Units { get; private set; }
        public string ProductName { get; private set; }
        public Guid ProductId { get; private set; }

        private static List<OrderItem> OrderItems = new List<OrderItem>();

        private OrderItemViewModel()
        {
        }

        private OrderItemViewModel(Guid productId, string productName, int units)
        {
            ProductId = productId;
            ProductName = productName;
            Units = units;
        }

        internal static OrderItemViewModel CreateOrderItemViewModel(Guid productId, string productName, int units)
        {
            return new OrderItemViewModel(productId, productName, units);
        }

        private static void GetOrderItemList(IList<OrderItemViewModel> ordemItemViewModels)
        {
            if (ordemItemViewModels != null || ordemItemViewModels.Count > 0)
            {
                foreach (var ordemItemViewModel in ordemItemViewModels)
                {
                    var orderItem = new OrderItem(ordemItemViewModel.ProductId, ordemItemViewModel.ProductName, ordemItemViewModel.Units);
                    OrderItems.Add(orderItem);
                }
            }
        }

        internal static Domain.Model._0rderAggregate.Order AddOrderItemToOrdem(Domain.Model._0rderAggregate.Order newOrder, IList<OrderItemViewModel> orderItemViewModels)
        {
            GetOrderItemList(orderItemViewModels);

            foreach (var item in OrderItems)
            {
                newOrder.AddOrdemItem(item);
            }

            return newOrder;
        }
    }
}
