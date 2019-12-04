using System;

namespace TechnicalAssignmentAB.Domain.Model.CustomerAggregate
{
    public sealed class Customer : Identity
    {
        public Customer(long id)
            : base(id) { }

        public string Name { get; private set; }
        public string Email { get; private set; }

        private Customer() { }

        private Customer(string name, Email email)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name, $"invalid parameter {nameof(name)}");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email, $"invalid parameter {nameof(Email)}");

            Name = name;
            Email = email;
        }

        public class Factory
        {
            public static Customer Create(string name, Email email)
            {
                return new Customer(name, email);
            }
        }
    }
}
