using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet("Customers")]
    public List<Customer> GetCustomers(string? documentNumber, int? birthYear)
    {
        var customerService = new CustomerService();
        return customerService.GetCustomers(documentNumber, birthYear);
    }

    [HttpPost]
    public Customer CreateCustomer(
        string fullName,
        int birthYear,
        int birthMonth,
        int birthDay,
        string documentNumber
    )
    {
        var customerService = new CustomerService();
        return customerService.CreateCustomer(fullName, birthYear, birthMonth, birthDay, documentNumber);
    }
}