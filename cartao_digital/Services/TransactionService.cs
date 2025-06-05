public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICardService _cardService;

    public TransactionService(ITransactionRepository transactionRepository, ICardService cardService)
    {
        _transactionRepository = transactionRepository;
        _cardService = cardService;
    }

    public List<Transaction> GetTransactions(int cardId, DateTime startDate, DateTime endDate)
    {
        var transactions = _transactionRepository.GetCardTransactions(cardId);

        return transactions
            .Where(t => t.TransactionDateTime >= startDate && t.TransactionDateTime <= endDate).ToList();
    }

    public Transaction PostTransaction(Transaction transaction)
    {
        if (!_cardService.CheckCardIsValid(transaction.CardId))
        {
            throw new Exception("O cartão informado é inválido");
        }

        if (string.IsNullOrWhiteSpace(transaction.Description))
        {
            throw new Exception("A transação precisa ter uma descrição");
        }

        if (transaction.Value <= 0)
        {
            throw new Exception("A transação precisa ter valor positivo");
        }

        transaction.TransactionDateTime = DateTime.Now;
        var newTransaction = _transactionRepository.Add(transaction);

        return newTransaction;
    }
}