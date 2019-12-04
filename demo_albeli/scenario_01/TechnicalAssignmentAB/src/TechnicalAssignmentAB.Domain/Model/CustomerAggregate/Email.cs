namespace TechnicalAssignmentAB.Domain.Model.CustomerAggregate
{
    public class Email 
    {
        public string Value { get; set; }

        public Email(string value) 
            => Value = value;

        public static implicit operator Email(string value) => new Email(Parse(value));

        public static implicit operator string(Email email) => Parse(email.Value);

        private static string Parse(string value)
        {
            //todo: apply some logic here to check whether parse is correct or not.
            return value;
        }
    }
}
