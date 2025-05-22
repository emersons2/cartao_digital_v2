public static class CustomerRepository
{
    private static List<Customer> Customers { get; } = [];

    private static int customerId = 1;

    public static List<Customer> GetCustomers()
    {
        return Customers;
    }

    public static Customer Add(Customer customer)
    {
        customer.CustomerId = customerId;
        Customers.Add(customer);
        customerId++;

        return customer;
    }

    public static void Update(Customer customer)
    {
        var existingCustomer = Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

        if (existingCustomer is null)
        {
            throw new Exception("Not found.");
        }

        existingCustomer.BirthDate = customer.BirthDate;
        existingCustomer.DocumentNumber = customer.DocumentNumber;
        existingCustomer.FullName = customer.FullName;
    }

    public static void Delete(int customerId)
    {
        var existingCustomer = Customers.FirstOrDefault(x => x.CustomerId == customerId);

        if (existingCustomer is null)
        {
            throw new Exception("Not found.");
        }

        Customers.Remove(existingCustomer);
    }
}
