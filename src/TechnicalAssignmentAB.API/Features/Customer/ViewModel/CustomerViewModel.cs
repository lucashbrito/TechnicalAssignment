namespace TechnicalAssignmentAB.API.Features.Customer.ViewModel
{
    public class CustomerViewModel
    {
        public string Name { get; }
        public string Email { get;  }

        public CustomerViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
