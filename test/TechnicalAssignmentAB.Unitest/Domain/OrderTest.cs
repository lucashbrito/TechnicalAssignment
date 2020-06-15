using System;
using TechnicalAssignmentAB.Domain.Core.DomainObject;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;
using Xunit;

namespace TechnicalAssignmentAB.UnitTest.Domain
{
    public class OrderTest
    {
        [Fact]
        public void Create_new_order_success()
        {
            var customerId = Guid.NewGuid();
            decimal price = 100;

            Order newOrder = new Order(customerId, price);

            Assert.Equal(customerId, newOrder.CustomerId);
            Assert.Equal(price, newOrder.Price);
            Assert.IsType<DateTime>(newOrder.CreatedAt);
        }

        [Theory]
        [InlineData("1DC6FF05-BE80-49B2-825F-660A05876C09", 100, "invalid parameter customerId")]
        [InlineData("1DC6FF05-BE80-49B2-825F-660A05876C09", -1, "invalid parameter price")]
        public void Create_new_order_failure(Guid customerId, decimal price, string expectedMessage)
        {
            var exception = Assert.Throws<DomainException>(() => new Order(customerId, price));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Add_new_order_item()
        {
            var customerId = Guid.NewGuid();
            decimal price = 100;

            var productId = Guid.NewGuid();
            var productName = "teste";
            var unit = 1;

            var newOrder = new Order(customerId, price);

            var orderItem = new OrderItem(productId, productName, unit);

            newOrder.AddOrdemItem(orderItem);

            Assert.NotNull(newOrder.OrderItems);
        }

        [Fact]
        public void Remove_order_item()
        {
            var customerId = Guid.NewGuid();
            decimal price = 100;

            var productId = Guid.NewGuid();
            var productName = "teste";
            var unit = 1;

            var newOrder = new Order(customerId, price);
            var orderItem = new OrderItem(productId, productName, unit);

            newOrder.AddOrdemItem(orderItem);

            newOrder.RemoveOrdemItem(orderItem);

            Assert.False(newOrder.OrderItems.Count > 0);
        }

        [Theory]
        [InlineData("", "maria", 3, "productId can't be 0 or negative!")]
        [InlineData("1DC6FF05-BE80-49B2-825F-660A05876C09", "", 2, "productName can't be null or empty!")]
        [InlineData("1DC6FF05-BE80-49B2-825F-660A05876C09", "joao", -1, "units can't be 0 or negative!")]
        public void Create_new_order_item_failure(Guid productId, string productName, int unit, string expectedMessage)
        {
            var exception = Assert.Throws<DomainException>(() => new OrderItem(productId, productName, unit));

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
