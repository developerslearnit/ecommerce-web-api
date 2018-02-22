using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interfaces
{
    public interface IProductRespository
    {
        bool AddProduct(ProductModel model);
        bool UpdateProduct(ProductModel model,int id);
        IQueryable<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(string productSlug);
        IQueryable<ProductViewModel> GetRelatedProducts(string productSlug);
        //IQueryable<ProductViewModel> GetFeaturedProducts();
        bool UpdateProductReviewCount(int id);
        bool UpdateProductRating(int id, double rating);
        bool AddProductImage(ProductImageModel productImage);
        bool AddProductReview(ProductReviewModel productReview);
        IQueryable<ProductReviewViewModel> GetProductReviews();

    }
}
