using Ecommerce.Data;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interfaces
{
    public interface IConsumerRepository
    {
        bool AddConsumer(ConsumerViewModel consumer);
        bool AuthenticateConsumer(string key);
    }
}
