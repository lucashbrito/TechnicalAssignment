﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignmentAB.API.Features.Customer.ViewModel;
using TechnicalAssignmentAB.Domain;
using TechnicalAssignmentAB.Domain.Model.CustomerAggregate;

namespace TechnicalAssignmentAB.API.Features.Customer
{

    using  CustomerModel = Domain.Model.CustomerAggregate.Customer;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository) => _customerRepository = customerRepository;
        
        [HttpGet("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.ListCustomers();

            if (customers.Count <= 0)
                return NotFound("No register was found");

            var customerViewModel = new ListCustomerViewModel(customers);

            return Ok(customerViewModel);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewCustomer([FromBody] CreateCustomerViewModel viewModel)
        {
            if (!TryValidateModel(viewModel))
                return BadRequest("Invalid Parameters");

            CustomerModel customerModel = CustomerModel.Factory.Create(viewModel.Name, viewModel.Email);

            await _customerRepository.RegisterNewCustomer(customerModel);

            return Ok("Customer registered");
        }
    }
}