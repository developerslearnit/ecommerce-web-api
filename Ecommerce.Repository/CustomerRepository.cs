using Ecommerce.Data;
using Ecommerce.Interfaces;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class CustomerRepository : BaseRepository<EcommerceEntities>, ICustomerRepository
    {
        public bool AddCustomer(CustomerModel customer)
        {
            var cust = new Customer()
            {
                Email = customer.email,
                Password = customer.password,
                DateCreated = DateTime.Now,
                FirstName = customer.firstName,
                LastName = customer.lastName,
                Mobile = customer.mobile,
            };

            DataContext.Customers.Add(cust);

            return DataContext.SaveChanges() > 0;
        }

        public bool AddCustomerAddress(CustomerAddressViewModel address)
        {
            var custAddress = new CustomerAddress()
            {
                AddressLine1 = address.addressLine1,
                AddressLine2 = address.addressLine2,
                Country = address.country,
                CustomerId = address.customer_Id,
                Landmark = address.landmark,
                State = address.state
            };

            DataContext.CustomerAddresses.Add(custAddress);
            return DataContext.SaveChanges() > 0;
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return from c in DataContext.Customers
                   select new CustomerViewModel
                   {
                       customerId = c.CustomerId,
                       email = c.Email,
                       firstName = c.FirstName,
                       lastName = c.LastName,
                       mobile = c.Mobile,
                       password = c.Password,
                       customerAddresses = DataContext.CustomerAddresses.Where(x => x.CustomerId == c.CustomerId).Select(x => new CustomerAddressViewModel
                       {
                           customer_Id = x.CustomerId,
                           state = x.State,
                           country = x.Country,
                           landmark = x.Landmark,
                           addressLine1 = x.AddressLine1,
                           addressLine2 = x.AddressLine2
                       }).ToList()

                   };
        }
    }
}
