using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
   public class ProductReviewViewModel
    {
        public long reviewId { get; set; }
        public long customerId { get; set; }
        public double rating { get; set; }
        public string comment { get; set; }
        public int productId { get; set; }
        public string customerName { get; set; }
    }
}
