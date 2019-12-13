using System.Collections.Generic;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class OrderItemViewModel
    {
        public int Units { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }

        public IList<OrderItem> OrderItems { get; private set; }

        public OrderItemViewModel(IList<OrderItemViewModel> ordemItemViewModels)
        {
            OrderItems = new List<OrderItem>();
            GetOrderItemList(ordemItemViewModels);
        }

        private void GetOrderItemList(IList<OrderItemViewModel> ordemItemViewModels)
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
    }
}
