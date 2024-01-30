using System.Text;
using System.Text.Json;
using admin.Models;

namespace admin.Repositories
{
    public class CustomerRepository
    {
        private string _baseUrl = "http://localhost:2440/api";
        public Customer GetCustomer(int id)
        {
            string url = $"{_baseUrl}/customers/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var customerJson = response.Content.ReadAsStringAsync().Result;
            Customer customer = JsonSerializer.Deserialize<Customer>(customerJson);

            return customer;
        }
        //  Ajouter un Client 
        public Customer AddCustomer(Customer customerToAdd)
        {
            string url = $"{_baseUrl}/customers/Add";
            HttpClient client = new HttpClient();
            var customerJson = JsonSerializer.Serialize(customerToAdd);
            var content = new StringContent(customerJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var newCustomerJson = response.Content.ReadAsStringAsync().Result;
            Customer newCustomer = JsonSerializer.Deserialize<Customer>(newCustomerJson);

            return newCustomer;
        }
        // Afficher la liste de client 
        public List<Customer> GetCustomers()
        {
            string url = $"{_baseUrl}/customers";
            HttpClient client = new HttpClient();
            var reponse = client.GetAsync(url).Result;
            var customerJson = reponse.Content.ReadAsStringAsync().Result;

            List<Customer> newCustomer = JsonSerializer.Deserialize<List<Customer>>(customerJson);

            return newCustomer;
        }
    }
}
