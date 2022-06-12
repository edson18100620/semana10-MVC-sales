using Newtonsoft.Json;
using Semana10SalesMVC.WEB.Models;

namespace Semana10SalesMVC.WEB.Service
{
    public class CustomerService
    {        
        //Get All Customers
        public static async Task<IEnumerable<CustomerModel>> GetAll()
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5047/api/Customer/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetAll");
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(apiResponse);
            return customers;
        }        
        
    }
}
