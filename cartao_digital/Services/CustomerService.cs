public class CustomerService
{
    public List<Customer> GetCustomers()
    {
        // TODO: Substituir o método BuildFakeCustomers pela consulta aos dados reais no banco de dados.
        var customers = BuildFakeCustomers();
        return customers;
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

        // TODO: Salvar no banco de dados.

        return customer;
    }

    private List<Customer> BuildFakeCustomers()
    {
        var customers = new List<Customer>
        {
            new Customer
            {
                FullName = "João Silva",
                BirthDate = new DateTime(1990, 1, 15),
                DocumentNumber = "12345678-9"
            },
            new Customer
            {
                FullName = "Maria Silva",
                BirthDate = new DateTime(1989, 5, 20),
                DocumentNumber = "98765432-1"
            },
            new Customer
            {
                FullName = "Joana Silva",
                BirthDate = new DateTime(1997, 6, 5),
                DocumentNumber = "55669988-4"
            }
        };

        return customers;
    }
}