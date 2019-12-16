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

            var newOrder = new Order(customerId, price);

            var orderItem = new OrderItem(productId, productName, unit);

            newOrder.AddOrdemItem(orderItem);

            Assert.NotNull(newOrder.OrderItems);
        }

        [Theory]
        [InlineData(0, "Renata", 3, "productId can't be 0 or negative!")]
        [InlineData(1, "", 2, "productName can't be null or empty!")]
        [InlineData(1, "Cicero", -1, "units can't be 0 or negative!")]
        public void Create_new_order_item_failure(int productId, string productName, int unit, string expectedMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new OrderItem(productId, productName, unit));

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
