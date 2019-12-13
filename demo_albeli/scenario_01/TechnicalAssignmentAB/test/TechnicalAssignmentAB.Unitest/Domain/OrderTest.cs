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

        [Fact]
        public void Add_new_order_item()
        {
            var customerId = 10;
            decimal price = 100;

            var productId = 10;
            var productName = "teste";
            var unit = 1;

            Order newOrder = new Order(customerId, price);

            OrderItem orderItem = new OrderItem(productId, productName, unit);

            newOrder.AddOrdemItem(orderItem);

            Assert.Collection(newOrder.OrderItems, _ => 
            {
                
            });
        }
    }
}
