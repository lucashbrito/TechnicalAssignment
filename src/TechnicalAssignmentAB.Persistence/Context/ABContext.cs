using Microsoft.EntityFrameworkCore;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;
using TechnicalAssignmentAB.Domain.Model.CustomerAggregate;

namespace TechnicalAssignmentAB.Persistence.Context
{
    public class AbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }


        public AbContext(DbContextOptions<AbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Database=TechnicalAssingment;Integrated Security=True");
        }
    }
}
