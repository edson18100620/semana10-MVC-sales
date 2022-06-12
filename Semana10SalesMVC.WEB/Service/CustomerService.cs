using Newtonsoft.Json;
using Semana10SalesMVC.WEB.Models;
using System.Text;

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

        //Create new Customer
        public static async Task<bool> Insert(CustomerModel customer)
        {
            string urlBase = "http://localhost:5047/api/Customer/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Insert", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }

        //Update Customer
        public static async Task<bool> Update(int id, CustomerModel customer)
        {
            string urlBase = "http://localhost:5047/api/Customer/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
        //Delete Customer
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5047/api/Customer/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
    }
}
