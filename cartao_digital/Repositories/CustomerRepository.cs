public class CustomerRepository
{
    private readonly JsonDatabase<Customer> _jsonDb = new JsonDatabase<Customer>();

    // private static List<Customer> Customers { get; } = [];

    // private  int _customerId = 1;

    public List<Customer> GetCustomers()
    {
        return _jsonDb.GetData();
    }

    public Customer Add(Customer customer)
    {
        var customers = _jsonDb.GetData();
        customer.CustomerId = customers.Count > 0 ? customers.Max(c => c.CustomerId) + 1 : 1;
        customers.Add(customer);
        _jsonDb.SaveChanges(customers);

        return customer;
        
        // _customerId = 2;
        // customer.CustomerId = _customerId;
        // Customers.Add(customer);
        // _customerId++;

        // return customer;
    }

    public Customer Update(Customer customer)
    {
        var customers = _jsonDb.GetData();

        var index = customers.FindIndex(c => c.CustomerId == customer.CustomerId);
        if (index >= 0)
        {
            customers[index] = customer;
            _jsonDb.SaveChanges(customers);
        }

        return customer;
        
        // var existingCustomer = Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

        // if (existingCustomer is null)
        // {
        //     throw new Exception("Not found.");
        // }

        // existingCustomer.BirthDate = customer.BirthDate;
        // existingCustomer.DocumentNumber = customer.DocumentNumber;
        // existingCustomer.FullName = customer.FullName;

        // return existingCustomer;
    }

    public void Delete(int customerId)
    {
        var customers = _jsonDb.GetData().Where(c => c.CustomerId != customerId).ToList();
        _jsonDb.SaveChanges(customers);

        // var existingCustomer = Customers.FirstOrDefault(x => x.CustomerId == customerId);

        // if (existingCustomer is null)
        // {
        //     throw new Exception("Not found.");
        // }

        // Customers.Remove(existingCustomer);
    }
}
