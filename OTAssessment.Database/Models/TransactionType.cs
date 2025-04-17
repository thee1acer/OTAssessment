namespace OT.Assessment.Database.Models;
public class TransactionType
{
    public Guid Id { get; set; }
    public required string TransactionTypeName { get; set; }
    public required string TransactionTypeDescription { get; set; }
}