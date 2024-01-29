using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // Ajouter dans la base de donnée
        [Route("Add")]
        [HttpPost]
        public Customer AddCustomer(Customer customer)
        {
            CustomerService customerService = new CustomerService(new MydataBase());
            customerService.AddCustomer(customer);
            return customer;
        }

        /// Liste des customer
        [Route("")]
        [HttpGet]
        public List<Customer> GetCustomers() 
        {
            CustomerService customersService = new CustomerService(new MydataBase());
            var customerList = customersService.GetCustomers();
            return customerList;
        }
    }
}
