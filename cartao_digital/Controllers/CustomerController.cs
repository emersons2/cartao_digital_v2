using Microsoft.AspNetCore.Mvc;

/// <summary>
///  Provê serviços para cadastro de clientes
/// </summary>
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Obtem lista de clientes cadastrados.
    /// </summary>
    /// <param name="documentNumber">Filtro opcional de número de documento</param>
    /// <param name="birthYear">Filtro opcional de ano de nascimento</param>
    /// <returns>Lista de clientes cadastrados de acordo com filtro. Retorna todos os clientes se nenhum filtro for passado.</returns>
    [HttpGet("Customers")]
    public List<Customer> GetCustomers(string? documentNumber, int? birthYear)
    {
        return _customerService.GetCustomers(documentNumber, birthYear);
    }

    /// <summary>
    /// Cadastro de novo cliente
    /// </summary>
    /// <param name="fullName">Nome completo do cliente</param>
    /// <param name="birthYear">Ano do nascimento (em formato de 4 dígitos)</param>
    /// <param name="birthMonth">Mês do nascimento (ex: 1 para Janeiro; 8 para agosto)</param>
    /// <param name="birthDay">Dia do nascimento</param>
    /// <param name="documentNumber">Documento de identificação do cliente</param>
    /// <returns>Dados do cliente criado com novo Id</returns>
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

    /// <summary>
    /// Atualização de cliente
    /// </summary>
    /// <param name="customer">Objeto JSON representando o cliente com dados atualizados</param>
    /// <returns>Dados do cliente atualizados</returns>
    [HttpPut]
    public Customer UpdateCustomer([FromBody] Customer customer)
    {
        return _customerService.UpdateCustomer(customer);
    }

    /// <summary>
    /// Remove cliente existente
    /// </summary>
    /// <param name="customerId">Id do cliente a ser removido.</param>
    [HttpDelete]
    public void DeleteCustomer(int customerId)
    {
        _customerService.DeleteCustomer(customerId);
    }
}