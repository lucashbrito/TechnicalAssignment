using System.Collections.Generic;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    using OrderModel = Domain.Model._0rderAggregate.Order;

    public class ListOrderViewModel
    {
        public long CustomerId { get; set; }
        public IList<OrderViewModel> OrdersViewModel { get; set; }

        private ListOrderViewModel() => OrdersViewModel = new List<OrderViewModel>();

        public ListOrderViewModel(long customerId, IEnumerable<OrderModel> orders)
            : this()
        {
            this.CustomerId = customerId;

            foreach (var item in orders)
            {
                var order = new OrderViewModel(item.Id, item.Price, item.CreatedAt);
                order.SetOrderItemViewModelList(item.OrderItems);
                this.OrdersViewModel.Add(order);
            }

        }
    }
}
