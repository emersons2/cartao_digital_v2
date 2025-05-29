public class CustomerRepository
{
    private readonly JsonDatabase<Customer> _jsonDb = new JsonDatabase<Customer>();

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
    }

    public void Delete(int customerId)
    {
        var customers = _jsonDb.GetData().Where(c => c.CustomerId != customerId).ToList();
        _jsonDb.SaveChanges(customers);
    }
}
