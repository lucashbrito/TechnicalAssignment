using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalAssignmentAB.Domain;
using TechnicalAssignmentAB.Persistence.Context;
using TechnicalAssignmentAB.Persistence.Repositories;

namespace TechnicalAssignmentAB.Persistence
{
    public static class Startup
    {
        public static void AddInfrastructureAb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AbContext>(_ => _.UseSqlServer(configuration["ConnectionString:dbURL"]));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
