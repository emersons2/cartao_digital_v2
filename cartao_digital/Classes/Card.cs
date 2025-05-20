public class Card
{
    public int CardId { get; set; }

    public string CardNumber { get; set; }

    public int VerificationCode { get; set; }

    public DateTime DueDate { get; set; }

    public int CustomerId { get; set; }
}