using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class CustomerModel
    {
        public long customerId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
    }


    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            customerAddresses = new List<CustomerAddressViewModel>();
        }
        public long customerId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public List<CustomerAddressViewModel> customerAddresses { get; set; }
    }

    public class CustomerAddressViewModel
    {
        public long customer_Id { get; set; }
        public string addressLine1 { get; set; }
        public string landmark { get; set; }
        public string addressLine2 { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}
