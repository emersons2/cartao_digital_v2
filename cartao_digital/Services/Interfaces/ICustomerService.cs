public interface ICustomerService
{
    List<Customer> GetCustomers(string? documentNumber, int? birthYear);

    Customer CreateCustomer(string fullName, int birthYear, int birthMonth, int birthDay, string documentNumber);

    Customer UpdateCustomer(Customer customer);

    void DeleteCustomer(int customerId);
}