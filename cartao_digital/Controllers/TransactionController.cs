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

    [HttpPost]
    public IActionResult PostTransaction(Transaction transaction)
    {
        var newTransaction = _transactionService.PostTransaction(transaction);
        return Accepted(newTransaction);
    }
}