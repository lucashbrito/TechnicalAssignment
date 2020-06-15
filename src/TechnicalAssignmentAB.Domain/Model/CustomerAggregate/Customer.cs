using TechnicalAssignmentAB.Domain.Core.DomainObject;

namespace TechnicalAssignmentAB.Domain.Model.CustomerAggregate
{
    public sealed class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        private Customer() { }

        private Customer(string name, Email email)
        {
            ValidationAssertionConcern.IsEmpty(name, $"{nameof(name)} can't be null or empty!");
            ValidationAssertionConcern.IsEmpty(Email, $"{nameof(email)} can't be null or empty!");

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

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email);
        }
    }
}
