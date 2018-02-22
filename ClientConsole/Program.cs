using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AddProduct();
        }


        static async void AddProduct()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:41797/api/v1/")
            };


            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Token", "e-key_9c8d2bb6-2673-4a98-a7df-b661083816c263654122");

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("category_Id", "1"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("productName", "Test Name"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("productDescription", "Thehjisd jkj jassdkba sd"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("shortDescription", "Thehjisd jkj jassdkba sd"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("productPrice", "25000"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("oldPrice", "0"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("quantityInStock", "2"));
            bodyKeyValues.Add(new KeyValuePair<string, string>("showOnPromoPage", "true"));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);
            var response = await client.PostAsync("products", formContent);

            var json = await response.Content.ReadAsStringAsync();
            
        }
    }
}
