using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalAssignmentAB.Domain.Model._0rderAggregate
{
    public interface IOrderRepository
    {
        Task CreateNewOrder(Order order);

        Task<IReadOnlyCollection<Order>> ListOrder(long customerId);
    }
}
