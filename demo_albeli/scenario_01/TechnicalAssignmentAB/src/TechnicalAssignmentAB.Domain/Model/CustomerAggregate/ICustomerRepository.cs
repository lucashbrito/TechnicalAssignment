using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignmentAB.Domain.Model.CustomerAggregate
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyCollection<Customer>> ListCustomers();

        Task<Customer> GetCustomer(long customerId);

        Task RegisterNewCustomer(Customer customer);
    }
}
