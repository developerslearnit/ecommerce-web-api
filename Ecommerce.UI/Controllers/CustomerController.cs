using Ecommerce.Interfaces;
using Ecommerce.UI.Filters;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce.UI.Controllers
{
    [RoutePrefix("api/v1")]
    [ClientAuthFilterAttribute]
    public class CustomerController : ApiController
    {
        ICustomerRepository repo;
        public CustomerController(ICustomerRepository _repo)
        {
            this.repo = _repo;
        }

        [HttpGet]
        [Route("customers")]
        public HttpResponseMessage GetCustomers()
        {
            var exMessage = string.Empty;
            try
            {

                var customers = repo.GetCustomers().OrderBy(x=>x.customerId);

                return Request.CreateResponse(HttpStatusCode.Found,
                    new
                    {
                        error = false,
                        count = customers.Count(),
                        results = customers
                    });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }

        [HttpPost]
        [Route("customers")]
        public HttpResponseMessage PostCustomer([FromBody] CustomerModel cust)
        {
            var exceptionMessage = string.Empty;
            try
            {

                if (repo.AddCustomer(cust))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new
                    {
                        error = false,
                        message = "customer created successfully"
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new
                    {
                        error = true,
                        message = "There was an error creating customer"
                    });

                }
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.Created, new
            {
                error = true,
                message = exceptionMessage
            });
        }


        [HttpPost]
        [Route("customers/login")]
        public HttpResponseMessage CustomerLogin([FromBody] LoginModel login)
        {
            var exMessage = string.Empty;
            try
            {

                var customers = repo.GetCustomers().Where(x => x.email==login.email && x.password==login.password);
                if (customers.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.Found,
                        new
                        {
                            error = false,
                            result = customers.Select(s=>new
                            {
                                customerId=s.customerId,
                                email=s.email,
                                firstname=s.firstName,
                                lastname=s.lastName,
                                addresses=s.customerAddresses
                            }).First()
                        });
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }
    }
}
