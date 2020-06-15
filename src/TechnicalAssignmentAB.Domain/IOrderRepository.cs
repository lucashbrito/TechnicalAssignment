using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;

namespace TechnicalAssignmentAB.Domain
{
    public interface IOrderRepository
    {
        Task CreateNewOrder(Order order);

        Task<IReadOnlyCollection<Order>> ListOrder(Guid customerId);
    }
}
