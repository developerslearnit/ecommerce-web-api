using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class ConsumerViewModel
    {
        public int consumer_Id { get; set; }
        public string name { get; set; }
        public string consumer_Key { get; set; }
        public bool is_Locked { get; set; }
    }

}
