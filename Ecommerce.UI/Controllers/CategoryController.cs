using Ecommerce.Interfaces;
using Ecommerce.UI.Filters;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Ecommerce.UI.Controllers
{
    [RoutePrefix("api/v1")]
    [ClientAuthFilterAttribute]
    public class CategoryController : ApiController
    {
        ICategoryRepository repo;
        public CategoryController(ICategoryRepository _repo)
        {
            this.repo = _repo;
        }

        [HttpGet]
        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var exMessage = string.Empty;
            try
            {

                var categories = repo.GetCategories().OrderBy(x => x.Datecreated);

                return Request.CreateResponse(HttpStatusCode.Found,
                    new
                    {
                        error = false,
                        count = categories.Count(),
                        results = categories.Select(x => new CategoryViewModel
                        {
                            cat_Id = x.CatID,
                            description =x.Description,
                            name =x.CategotyName,
                            slug =x.slug
                        }).ToList()
                    });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }

        [HttpPost]
        [Route("categories")]
        public HttpResponseMessage PostCategory([FromBody] CategoryViewModel cat)
        {
            var exceptionMessage = string.Empty;
            try
            {
                
                if (repo.AddCategory(cat))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new
                    {
                        error = false,
                        message = "Category created successfully"
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new
                    {
                        error = true,
                        message = "There was an error creating category"
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

        [Route("categories/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateCategory([FromBody] CategoryViewModel model, int id)
        {
            var exMessage = string.Empty;
            try
            {

                if (repo.UpdateCategory(model,id))
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
