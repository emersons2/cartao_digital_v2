public class CustomerService
{
    public List<Customer> GetCustomers()
    {
        // TODO: Substituir o método BuildFakeCustomers pela consulta aos dados reais no banco de dados.
        return CustomerRepository.GetCustomers();
    }

    public Customer CreateCustomer(
        string fullName,
        DateTime birthDate,
        string documentNumber)
    {
        var customer = new Customer
        {
            FullName = fullName,
            BirthDate = birthDate,
            DocumentNumber = documentNumber
        };

        CustomerRepository.Add(customer);

        return customer;
    }
}