using System;
using System.Collections.Generic;

namespace TechnicalAssignmentAB.API.Features.Order.ViewModel
{
    public class CreateOrderViewModel
    {
        public Guid CustomerId { get; set; }
        public decimal Price { get; set; }

        public IList<OrderItemViewModel> OrderItemViewModels { get; set; }
    }
}
