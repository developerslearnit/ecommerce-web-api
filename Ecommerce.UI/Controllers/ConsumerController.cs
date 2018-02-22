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
    public class ConsumerController : ApiController
    {
        IConsumerRepository repo;
        public ConsumerController(IConsumerRepository _repo)
        {
            this.repo = _repo;
        }

        [Route("consumers")]
        [HttpPost]
        public HttpResponseMessage SaveConsumer([FromBody] ConsumerViewModel model)
        {

            var exMessage = string.Empty;
            try
            {
                if (repo.AddConsumer(model))
                {
                    return Request.CreateResponse(HttpStatusCode.Created,
                   new
                   {
                       error = false
                   });
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest,
                   new
                   {
                       error = true
                   });


            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }
    }
}
