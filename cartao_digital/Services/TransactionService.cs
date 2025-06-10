using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;

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

    public FileContentResult GetTransactionsFile(int cardId, DateTime startDate, DateTime endDate)
    {
        // TODO: Filtrar por startDate e endDate
        var transactions = _transactionRepository.GetCardTransactions(cardId);

        if (transactions == null || transactions.Count == 0)
        {
            throw new Exception("Nenhuma transação encontrada");
        }

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("CodTransacao;DataHora;Descrição;Valor");

        foreach (var transaction in transactions)
        {
            stringBuilder.AppendLine($"{transaction.TransactionId};{transaction.TransactionDateTime:dd/MM/yyyy HH:mm:ss};{transaction.Description};{transaction.Value:F2}");
        }

        byte[] fileBytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
        var stream = new MemoryStream(fileBytes);

        return new FileContentResult(stream.ToArray(), "text/csv")
        {
            FileDownloadName = "extrato.csv"
        };
    }

    public async Task<Transaction> PostTransaction(PostTransactionRequest request)
    {
        var card = _cardService.GetCardForTransaction(request);

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new Exception("A transação precisa ter uma descrição");
        }

        if (request.Value <= 0)
        {
            throw new Exception("A transação precisa ter valor positivo");
        }

        var watch = new Stopwatch();
        watch.Start();

        var taskCentralBank = GetCentralBankApproval(request);
        var taskItau = GetItauApproval(request);

        await taskCentralBank;
        await taskItau;
        
        watch.Stop();
        Debug.WriteLine($"Tempo decorrido: {watch.Elapsed.Seconds}s");

        var newTransaction = new Transaction
        {
            CardId = card.CardId,
            Description = request.Description,
            Value = request.Value,
            TransactionDateTime = DateTime.Now
        };

        newTransaction = _transactionRepository.Add(newTransaction);

        return newTransaction;
    }

    private async Task GetCentralBankApproval(PostTransactionRequest request)
    {
        // Simulação de tempo de resposta da aprovação do Banco Central
        // Thread.Sleep(10000);
        await Task.Delay(10000);
    }

    private async Task GetItauApproval(PostTransactionRequest request)
    {
        // Simulação de tempo de resposta da aprovação do Banco Central
        await Task.Delay(5000);
    }
}