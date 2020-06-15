using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAssignmentAB.Domain.Model.CustomerAggregate;

namespace TechnicalAssignmentAB.Domain
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyCollection<Customer>> ListCustomers();

        Task<Customer> GetCustomer(Guid customerId);

        Task RegisterNewCustomer(Customer customer);
    }
}
