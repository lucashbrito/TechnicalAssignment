using System;
using TechnicalAssignmentAB.Domain.Model._0rderAggregate;
using Xunit;

namespace TechnicalAssignmentAB.Unitest.Domain
{
    public class OrderItemTest
    {
        [Theory]
        [InlineData(0, "Renata", 3, "unit can't be 0 or negative")]
        [InlineData(1, "", 2, "productName can't be null or empty!")]
        [InlineData(1, "Cicero", -1, "productId can't be 0 or negative")]
        public void Create_new_order_item_failure(int productId, string productName, int unit, string expectedMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new OrderItem(productId, productName, unit));

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}