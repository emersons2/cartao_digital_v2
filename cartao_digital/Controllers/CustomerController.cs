using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("Customers")]
    public List<Customer> GetCustomers(string? documentNumber, int? birthYear)
    {
        return _customerService.GetCustomers(documentNumber, birthYear);
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
        var customer = _customerService.CreateCustomer(fullName, birthYear, birthMonth, birthDay, documentNumber);
        return Accepted(customer);
    }

    [HttpPut]
    public Customer UpdateCustomer([FromQuery] Customer customer)
    {
        return _customerService.UpdateCustomer(customer);
    }

    [HttpDelete]
    public void DeleteCustomer(int customerId)
    {
        _customerService.DeleteCustomer(customerId);
    }
}