public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public List<Customer> GetCustomers(string? documentNumber, int? birthYear)
    {
        var customers = _customerRepository.GetCustomers()
            .Where(customer => (documentNumber == null || customer.DocumentNumber == documentNumber)
                && (birthYear == null || customer.BirthDate.Year == birthYear));

        return customers.ToList();
    }

    public Customer CreateCustomer(
        string fullName,
        int birthYear,
        int birthMonth,
        int birthDay,
        string documentNumber)
    {
        // Verificar se já existe algum cliente com o documento informado
        // LINQ expression
        var documentExists = _customerRepository.GetCustomers().Any(customer => customer.DocumentNumber == documentNumber);

        if (documentExists)
        {
            throw new Exception("Número de documento já utilizado");
        }

        var birthDate = new DateTime(birthYear, birthMonth, birthDay);

        var customer = new Customer
        {
            FullName = fullName,
            BirthDate = birthDate,
            DocumentNumber = documentNumber
        };

        return _customerRepository.Add(customer);
    }

    public Customer UpdateCustomer(Customer customer)
    {
        return _customerRepository.Update(customer);
    }

    public void DeleteCustomer(int customerId)
    {
        _customerRepository.Delete(customerId);
    }
}