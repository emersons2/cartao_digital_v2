public class CustomerService
{
    public List<Customer> GetCustomers(string? documentNumber, int? birthYear)
    {
        var customers = CustomerRepository.GetCustomers()
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
        var documentExists = CustomerRepository.GetCustomers().Any(customer => customer.DocumentNumber == documentNumber);

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

        return CustomerRepository.Add(customer);
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

// public class CustomerService
// {
//     public List<Customer> GetCustomers()
//     {
//         // TODO: Substituir o método BuildFakeCustomers pela consulta aos dados reais no banco de dados.
//         return CustomerRepository.GetCustomers();
//     }

//     public Customer CreateCustomer(
//         string fullName,
//         DateTime birthDate,
//         string documentNumber)
//     {
//         var customer = new Customer
//         {
//             FullName = fullName,
//             BirthDate = birthDate,
//             DocumentNumber = documentNumber
//         };

//         CustomerRepository.Add(customer);

//         return customer;
//     }
// }