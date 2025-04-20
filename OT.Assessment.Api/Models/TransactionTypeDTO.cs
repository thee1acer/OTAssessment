namespace OT.Assessment.Models;
public class TransactionTypeDTO
{
    public Guid Id { get; set; }
    public required string TransactionTypeName { get; set; }
    public required string TransactionTypeDescription { get; set; }
}