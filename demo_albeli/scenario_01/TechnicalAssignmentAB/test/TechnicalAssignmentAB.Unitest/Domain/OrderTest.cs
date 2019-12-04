using System;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;
using Xunit;

namespace TechnicalAssignmentAB.Unitest.Domain
{
    public class OrderTest
    {
        [Fact]
        public void Create_new_order_success()
        {
            var customerId = 1001;
            decimal price = 100;

            Order newOrder = new Order(customerId, price);

            Assert.Equal(customerId, newOrder.CustomerId);
            Assert.Equal(price, newOrder.Price);
            Assert.IsType<DateTime>(newOrder.CreatedAt);
        }

        [Theory]
        [InlineData(0, 100, "invalid parameter customerId")]
        [InlineData(1, -1, "invalid parameter price")]
        public void Create_new_order_failure(long customerId, decimal price, string expectedMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Order(customerId, price));

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
