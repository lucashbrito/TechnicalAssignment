using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignmentAB.API.Features.Order.ViewModel;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

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

            OrderModel newOrder = new OrderModel(viewModel.CustomerId, viewModel.Price);

            var orderItem = new OrderItemViewModel(viewModel.OrderItemViewModels);

            newOrder.AddOrdemItemId(orderItem.OrderItems);

            await _orderRepository.CreateNewOrder(newOrder);

            return Ok("Order has been created successfuly");
        }

        [HttpGet("customer/{customerId:int}/items")]
        public async Task<IActionResult> ListCustomerOrders([FromQuery] long customerId)
        {
            var customerOrders = await _orderRepository.ListOrder(customerId);

            if (customerOrders.Count <= 0)
                return NotFound("No order has found");

            var viewModel = new ListOrderViewModel(customerId, customerOrders);

            return Ok(viewModel);
        }
    }
}