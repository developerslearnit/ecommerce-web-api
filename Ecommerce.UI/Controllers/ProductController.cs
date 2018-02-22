using Ecommerce.Common;
using Ecommerce.Interfaces;
using Ecommerce.UI.Filters;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace Ecommerce.UI.Controllers
{
    [RoutePrefix("api/v1")]
    [ClientAuthFilterAttribute]
    public class ProductController : ApiController
    {
        IProductRespository repo;
        public ProductController(IProductRespository _repo)
        {
            this.repo = _repo;
        }

        [Route("products")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            var exMessage = string.Empty;
            try
            {
                var products = repo.GetProducts();

                return Request.CreateResponse(HttpStatusCode.Found,
                    new
                    {
                        error = false,
                        count = products.Count(),
                        results = products
                    });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }


        [Route("products")]
        [HttpPost]
        public HttpResponseMessage SaveProduct([FromBody] ProductModel model)
        {

            var exMessage = string.Empty;
            try
            {

                if (repo.AddProduct(model))
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

        [Route("products/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateProducts([FromBody] ProductModel model, int id)
        {

            var req = this.Request;

            var exMessage = string.Empty;
            try
            {

                if (repo.UpdateProduct(model, id))
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


        [Route("product/{slug}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(string slug)
        {
            var exMessage = string.Empty;
            try
            {
                var product = repo.GetProduct(slug);

                return Request.CreateResponse(HttpStatusCode.Found,
                    new
                    {
                        error = false,
                        results =new {
                            product = product,
                            reviews=repo.GetProductReviews().Where(x=>x.productId==product.Id).ToList()
                        }

                    });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }

        [Route("product/related/{slug}")]
        [HttpGet]
        public HttpResponseMessage GetRelatedProduct(string slug)
        {
            var exMessage = string.Empty;
            try
            {
                var currentProductId = repo.GetProduct(slug).Id.ToString();
                var product = repo.GetRelatedProducts(slug).Where(x => !x.Id.ToString().Contains(currentProductId));

                return Request.CreateResponse(HttpStatusCode.Found,
                    new
                    {
                        error = false,
                        results = product
                    });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.Found, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }

        [HttpPost]
        public HttpResponseMessage UploadImage()
        {
            var exMessage = string.Empty;
            try
            {
                string uploadPath = "~/content/upload";
                HttpPostedFile file = null;
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    file = HttpContext.Current.Request.Files.Get("file");
                }
                // Check if we have a file
                if (null == file)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        error = true,
                        message = "Image file not found"
                    });

                // Make sure the file has content
                if (!(file.ContentLength > 0))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        error = true,
                        message = "Image file not found"
                    });

                if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadPath)))
                {
                    // If it doesn't exist, create the directory
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadPath));
                }

                //Upload File
                file.SaveAs(HttpContext.Current.Server.MapPath($"{uploadPath}/{file.FileName}"));


            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = true, message = exMessage == string.Empty ? "An unknown error occured" : exMessage });
        }




        [Route("product/image")]
        [HttpPost]
        public HttpResponseMessage AddProductImage()
        {

            var exMessage = string.Empty;
            try
            {
                HttpPostedFile file = null;
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    file = HttpContext.Current.Request.Files.Get("file");
                    int productId = int.Parse(HttpContext.Current.Request.Params.Get("productId"));


                    string filePath = ImageUploadHelper.UploadFile(file);

                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        var imageModel = new ProductImageModel()
                        {
                            productId = productId,
                            image_Path = filePath
                        };

                        if (repo.AddProductImage(imageModel))
                        {
                            return Request.CreateResponse(HttpStatusCode.Created,
                           new
                           {
                               error = false
                           });
                        }
                    }


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



        [Route("products/review")]
        [HttpPost]
        public HttpResponseMessage AddReview([FromBody] ProductReviewModel model)
        {

            var exMessage = string.Empty;
            try
            {

                if (repo.AddProductReview(model))
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
