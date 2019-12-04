using System.Collections.Generic;

namespace TechnicalAssignmentAB.API.Features.Customer.ViewModel
{
    using CustomerModel = Domain.Model.CustomerAggregate.Customer;

    public class ListCustomerViewModel
    {
        public IList<CustomerViewModel> CustomerView { get; set; }

        public ListCustomerViewModel() => this.CustomerView = new List<CustomerViewModel>();

        public ListCustomerViewModel(IEnumerable<CustomerModel> customers)
            : this()
        {
            foreach (var customer in customers)
                this.CustomerView.Add(new CustomerViewModel(customer.Name, customer.Email));
        }
    }
}
