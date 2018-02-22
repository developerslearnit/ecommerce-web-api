using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
  public  class ProductReviewModel
    {
        public long ReviewId { get; set; }
        public long CustomerId { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
    }
}
