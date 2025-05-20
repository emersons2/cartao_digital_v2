using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet("Customers")]
    public List<Customer> GetCustomers()
    {
        var customerService = new CustomerService();
        return customerService.GetCustomers();
    }

    [HttpPost]
    public Customer CreateCustomer(
        string fullName,
        DateTime birthDate,
        string documentNumber
    )
    {
        var customerService = new CustomerService();
        return customerService.CreateCustomer(fullName, birthDate, documentNumber);
    }
}