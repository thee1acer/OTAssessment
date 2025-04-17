namespace OT.Assessment.Database.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public bool Amount { get; set; }
    public int NumberOfBets { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public required TransactionType Type { get; set; }
    public required User User { get; set; }
}