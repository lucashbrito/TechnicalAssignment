using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalAssignmentAB.Domain;
using TechnicalAssignmentAB.Domain.Model.CustomerAggregate;
using TechnicalAssignmentAB.Persistence.Context;

namespace TechnicalAssignmentAB.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AbContext _context;

        public CustomerRepository(AbContext context)
            => _context = context ?? throw new ArgumentNullException("context", "invalid parameter ef AbContext");

        public async Task<IReadOnlyCollection<Customer>> ListCustomers()
        {
            var customers = await _context.Customer.ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(_ => _.Id == customerId);

            return customer;
        }

        public async Task RegisterNewCustomer(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
