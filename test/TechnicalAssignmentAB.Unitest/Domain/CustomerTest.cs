using System;
using TechnicalAssignmentAB.Domain.Model.CustomerAggregate;
using Xunit;

namespace TechnicalAssignmentAB.Unitest.Domain
{
    public class CustomerTest
    {
        [Fact]
        public void Create_new_customer_success()
        {
            var nameExpected = "test";
            var emailExpected = "test1@gmail.com";

            var newCustomer = Customer.Factory.Create("test", "test1@gmail.com");

            Assert.Equal(nameExpected, newCustomer.Name);
            Assert.Equal(emailExpected, newCustomer.Email);
        }

        [Theory]
        [InlineData(null, "test1@sovos.com","invalid parameter name")]
        [InlineData("test1",null, "invalid parameter Email")]
        public void Create_new_customer_failure(string name,string email, string messageExpected)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Customer.Factory.Create(name, email));

            Assert.Equal(messageExpected, exception.Message);
        }
    }
}
