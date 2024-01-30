using admin.Models;
using admin.Repositories;

namespace admin.Service
{
    public class ServiceCustomer
    {
        private readonly CustomerRepository _customerRepository;
        public ServiceCustomer()
        {
            _customerRepository = new CustomerRepository();
        }
        //Ajout un client
        public Customer AddCustomer(Customer customerToAdd)
        {
            var newcustomer = _customerRepository.AddCustomer(customerToAdd);
            return newcustomer;
        }
        // afficher la liste des clients
        public List<Customer> GetCustomers() 
        { 
            return _customerRepository.GetCustomers();
        }

    }
}
