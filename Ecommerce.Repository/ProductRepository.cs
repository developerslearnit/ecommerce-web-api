using Ecommerce.Common;
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
    public class ProductRepository : BaseRepository<EcommerceEntities>,
        IProductRespository
    {
        public bool AddProduct(ProductModel model)
        {          

            DataContext.Products.Add(new Product()
            {
                Name = model.productName,
                Price =model.productPrice,
                CategoryId = model.category_Id,
                Description = model.productDescription,
                ShortDescription =model.shortDescription,
                OldPrice =model.oldPrice,
                QuantityInStock =model.quantityInStock,
                ShowOnPromoPage =model.showOnPromoPage,
                ProductSlug = CommonHelpers.GenerateSlug(model.productName)
                
            });

            return DataContext.SaveChanges() > 0;
        }

        public bool AddProductImage(ProductImageModel productImage)
        {
            var _productImage = new ProductImage()
            {
                ImagePath = productImage.image_Path,
                ProductId = productImage.productId                
            };
            DataContext.ProductImages.Add(_productImage);
            return DataContext.SaveChanges() > 0;
        }

        public bool AddProductReview(ProductReviewModel productReview)
        {
            var prodrev = new ProductReview()
            {
                Comment = productReview.Comment,
                CustomerId = productReview.CustomerId,
                DateCreated = DateTime.Now,
                ProductId=productReview.ProductId,
                Rating=productReview.Rating,
            };

            var prod = DataContext.Products.Find(productReview.ProductId);
            prod.ReviewCount += 1;
            prod.ProductRating += productReview.Rating;

            DataContext.ProductReviews.Add(prodrev);
            return DataContext.SaveChanges() > 0;
        }

        public ProductViewModel GetProduct(string productSlug)
        {
            return GetProducts().Where(x => x.slug == productSlug).FirstOrDefault();
        }

        public IQueryable<ProductReviewViewModel> GetProductReviews()
        {
            return from cust in DataContext.Customers
                   join prodrev in DataContext.ProductReviews
                   on cust.CustomerId equals prodrev.CustomerId
                   select new ProductReviewViewModel
                   {
                       customerId = cust.CustomerId,
                       comment = prodrev.Comment,
                       customerName = cust.FirstName,
                       productId = prodrev.ProductId,
                       rating = prodrev.Rating,
                       reviewId = prodrev.ReviewId,
                   };
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            return from p in DataContext.Products
                   join cat in DataContext.Categories on p.CategoryId equals cat.CatID
                   select new ProductViewModel
                   {
                       category_Id = p.CategoryId,
                       category = cat.CategotyName,
                       Id = p.ProductID,
                       oldPrice = p.OldPrice,
                       productDescription = p.Description,
                       productName = p.Name,
                       productPrice = p.Price,
                       quantityInStock = p.QuantityInStock,
                       shortDescription = p.ShortDescription,
                       showOnPromoPage = p.ShowOnPromoPage,
                       slug = p.ProductSlug,
                       rating =p.ProductRating,
                       reviewCount =p.ReviewCount,
                       productImages = DataContext.ProductImages.Where(pr=>pr.ProductId ==p.ProductID)
                       .Select(x => new ProductImagesViewModel { ImageId = x.ImageId, ImagePath = x.ImagePath }).ToList()
                   };
        }

        public IQueryable<ProductViewModel> GetRelatedProducts(string productSlug)
        {
            var targetProduct = DataContext.Products.Where(x => x.ProductSlug == productSlug);
            if(targetProduct != null)
            {
                var product = targetProduct.First();
                return GetProducts().Where(x => x.category_Id == product.CategoryId);
            }
            return null;
        }

        public bool UpdateProduct(ProductModel model, int id)
        {
            var result = false;
            try
            {
                var targetProduct = DataContext.Products.Find(id);
                if (targetProduct != null)
                {
                    targetProduct.Name = model.productName;
                    targetProduct.Price = model.productPrice;
                    targetProduct.CategoryId = model.category_Id;
                    targetProduct.Description = model.productDescription;
                    targetProduct.ShortDescription = model.shortDescription;
                    targetProduct.OldPrice = model.oldPrice;
                    targetProduct.QuantityInStock = model.quantityInStock;
                    targetProduct.ShowOnPromoPage = model.showOnPromoPage;
                    targetProduct.ProductSlug = CommonHelpers.GenerateSlug(model.productName);
                    DataContext.SaveChanges();
                    result = true;
                }

                result = false;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
         
        }

        public bool UpdateProductRating(int id,double rating)
        {
            var result = false;
            try
            {
                var targetProduct = DataContext.Products.Find(id);
                if (targetProduct != null)
                {
                    targetProduct.ProductRating = rating;
                    DataContext.SaveChanges();
                    result = true;
                }

                result = false;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateProductReviewCount(int id)
        {
            var result = false;
            try
            {
                var targetProduct = DataContext.Products.Find(id);
                if (targetProduct != null)
                {
                    targetProduct.ReviewCount +=1;
                    DataContext.SaveChanges();
                    result = true;
                }

                result = false;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
