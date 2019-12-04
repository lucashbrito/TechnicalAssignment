using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;
using TechnicalAssignmentAB.Persistence.Context;

namespace TechnicalAssignmentAB.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AbContext _context;

        public OrderRepository(AbContext context)
            => _context = context ?? throw new ArgumentNullException("context", "invalid parameter AbContext");


        public async Task CreateNewOrder(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Order>> ListOrder(long customerId)
        {
            var orders = await _context.Order.Where(_ => _.CustomerId == customerId).ToListAsync();

            if (orders.Count <= 0)
                return new List<Order>();

            return await Task.FromResult(orders);
        }
    }
}
