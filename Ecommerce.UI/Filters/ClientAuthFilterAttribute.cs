using Ecommerce.Interfaces;
using Ecommerce.Repository;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ecommerce.UI.Filters
{
    public class ClientAuthFilterAttribute : ActionFilterAttribute
    {
     
        public override bool AllowMultiple { get { return false; } }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ConsumerRepository repo = new ConsumerRepository();

            if (HttpContext.Current.Request.Headers["X-Auth-Token"] == null)
            {
                
                actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = true, message = "X-Auth-Token is not present in your header" });
            }
            else
            {
                var tokenKey = HttpContext.Current.Request.Headers["X-Auth-Token"];
                if (!repo.AuthenticateConsumer(tokenKey))
                {
                    actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = true, message = "Invalid token" });

                }

            }
            
        }
    }
}