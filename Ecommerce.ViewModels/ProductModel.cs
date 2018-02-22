using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    
   public class ProductModel
    {
        public int Id { get; set; }
        public int category_Id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string shortDescription { get; set; }
        public decimal productPrice { get; set; }
        public decimal oldPrice { get; set; }
        public long quantityInStock { get; set; }
        public bool showOnPromoPage { get; set; }
    }
}
