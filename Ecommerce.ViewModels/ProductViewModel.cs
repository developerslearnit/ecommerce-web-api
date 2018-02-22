using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.productImages = new List<ProductImagesViewModel>();
        }
        public int Id { get; set; }
        public int category_Id { get; set; }
        public string category { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string shortDescription { get; set; }
        public decimal productPrice { get; set; }
        public decimal oldPrice { get; set; }
        public long quantityInStock { get; set; }
        public bool showOnPromoPage { get; set; }
        public string  slug { get; set; }
        public int reviewCount { get; set; }
        public double rating { get; set; }
        public List<ProductImagesViewModel> productImages { get; set; }
    }

    public class ProductImagesViewModel
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        
    }

    public class ProductImageModel
    {
        public int image_Id { get; set; }
        public string image_Path { get; set; }
        public int productId { get; set; }

    }
}
