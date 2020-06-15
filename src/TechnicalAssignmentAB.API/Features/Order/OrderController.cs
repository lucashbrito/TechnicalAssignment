using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignmentAB.API.Features.Order.ViewModel;
using TechnicalAssignmentAB.Domain;

namespace TechnicalAssignmentAB.API.Features.Order
{
    using OrderModel = Domain.Model._0rderAggregate.Order;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository) => _orderRepository = orderRepository;


        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewOrder([FromBody] CreateOrderViewModel viewModel)
        {
            if (!TryValidateModel(viewModel))
                return BadRequest("Invalid Parameters");

            var newOrder = new OrderModel(viewModel.CustomerId, viewModel.Price);

            newOrder = OrderItemViewModel.AddOrderItemToOrdem(newOrder, viewModel.OrderItemViewModels);

            await _orderRepository.CreateNewOrder(newOrder);

            return Ok("Order has been created successfuly");
        }

        [HttpGet("customer/{customerId:int}/items")]
        public async Task<IActionResult> ListCustomerOrders([FromQuery] Guid customerId)
        {
            var customerOrders = await _orderRepository.ListOrder(customerId);

            if (customerOrders.Count <= 0)
                return NotFound("No order has found");

            return Ok(new ListOrderViewModel(customerId, customerOrders));
        }
    }
}