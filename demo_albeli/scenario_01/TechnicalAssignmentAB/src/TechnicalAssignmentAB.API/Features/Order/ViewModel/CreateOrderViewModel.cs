using System.Collections.Generic;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class CreateOrderViewModel
    {
        public long CustomerId { get; set; }
        public decimal Price { get; set; }

        public IList<OrderItemViewModel> OrderItemViewModels { get; set; }
    }
}
