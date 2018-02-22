using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.UI.Filters
{
    public class ClientAuthFilterAttribute1
    {
        public override bool AllowMultiple { get { return false; } }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ConsumerRepository repo = new ConsumerRepository();

            if (HttpContext.Current.Request.Headers["X-Auth-Token"] == null)
            {
                //actionContext.Request.Properties.Add(new KeyValuePair<string, object>("AuthenticationState", new AuthenticationStateModel { error = true, message = "X-Auth-Token is not present in your header" }));

                throw new HttpResponseException(actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = true, message = "X-Auth-Token is not present in your header" }));
            }
            else
            {
                var tokenKey = HttpContext.Current.Request.Headers["X-Auth-Token"];
                //var header = HttpContext.Current.Request.Headers["Authorization"]; for standard Authorization
                //validate this against what we have in our DB

                if (!repo.AuthenticateConsumer(tokenKey))
                {
                    actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = true, message = "Invalid token" });
                    //throw new HttpResponseException(actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = true, message = "Invalid token" }));
                }
                //if (repo.AuthenticateConsumer(tokenKey))
                //{
                //    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("AuthenticationState", new AuthenticationStateModel  { error = false, message = "" }));
                //    throw new HttpResponseException(actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = "X-Auth-Token is not present in your header" }));
                //}
                //else
                //{
                //    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("AuthenticationState", new AuthenticationStateModel { error = true, message = "Invalid token" }));
                //    throw new HttpResponseException(actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = "X-Auth-Token is not present in your header" }));
                //}



            }


        }
    }
}