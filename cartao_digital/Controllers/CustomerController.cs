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
    public IActionResult CreateCustomer(
        string fullName,
        int birthYear,
        int birthMonth,
        int birthDay,
        string documentNumber
    )
    {
        var customerService = new CustomerService();
        var customer = customerService.CreateCustomer(fullName, birthYear, birthMonth, birthDay, documentNumber);
        return Accepted(customer);
    }

    [HttpPut]
    public Customer UpdateCustomer([FromQuery] Customer customer)
    {
        var customerService = new CustomerService();
        return customerService.UpdateCustomer(customer);
    }

    [HttpDelete]
    public void DeleteCustomer(int customerId)
    {
        var customerService = new CustomerService();
        customerService.DeleteCustomer(customerId);
    }
}