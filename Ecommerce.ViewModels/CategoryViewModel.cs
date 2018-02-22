using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class CategoryViewModel
    {
        public int cat_Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
    }
}
