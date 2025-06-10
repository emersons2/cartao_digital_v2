using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public IActionResult GetTransactions(int cardId, DateTime startDate, DateTime endDate)
    {
        var transactions = _transactionService.GetTransactions(cardId, startDate, endDate);

        if (transactions.Any())
        {
            return Ok(transactions);
        }

        return Ok();
    }

    [HttpGet("File")]
    public IActionResult GetTransactionsFile(int cardId, DateTime startDate, DateTime endDate)
    {
        var file = _transactionService.GetTransactionsFile(cardId, startDate, endDate);

        if (file == null)
        {
            return NoContent();
        }

        return file;
    }

    [HttpPost]
    public IActionResult PostTransaction([FromBody]PostTransactionRequest request)
    {
        var newTransaction = _transactionService.PostTransaction(request);
        return Accepted(newTransaction);
    }
}