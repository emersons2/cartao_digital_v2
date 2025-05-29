public interface ICustomerRepository
{
    List<Customer> GetCustomers();

    Customer Add(Customer customer);

    Customer Update(Customer customer);

    void Delete(int customerId);
}