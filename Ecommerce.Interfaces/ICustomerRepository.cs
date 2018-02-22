using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interfaces
{
    public interface ICustomerRepository
    {
        bool AddCustomer(CustomerModel customer);

        bool AddCustomerAddress(CustomerAddressViewModel address);

        IEnumerable<CustomerViewModel> GetCustomers();
    }
}
