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
    public class ConsumerRepository : BaseRepository<EcommerceEntities>, IConsumerRepository
    {
        public bool AddConsumer(ConsumerViewModel consumer)
        {
            var newConsumer = new Consumer()
            {
                ConsumerName =consumer.name,
                IsLocked =false,
                ConsumerKey = CommonHelpers.GenerateRandomString(50)
            };

            DataContext.Consumers.Add(newConsumer);

            return DataContext.SaveChanges() > 0;
        }

        public bool AuthenticateConsumer(string key)
        {
            return DataContext.Consumers.Any(x => x.ConsumerKey.ToLower() == key.ToLower() && x.IsLocked == false);
        }
    }
}
