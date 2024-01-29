namespace Api.Models
{
    public class CustomerService
    {
        public readonly MydataBase _context;

        public CustomerService(MydataBase context) 
        {
            _context = context;
        }

        //Ajout d'un customer 
        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        //List des customer
        public List<Customer> GetCustomers()
        {
            var customerList = _context.Customers.ToList();
            return customerList;
        }
    }
}
