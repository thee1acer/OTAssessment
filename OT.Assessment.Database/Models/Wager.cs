namespace OT.Assessment.Database.Models;

public class Wager
{
    public Guid Id { get; set; }
    public required string Theme { get; set; }
    public required string Provider { get; set; }
    public required string GameName { get; set; }
    public required Guid TransactionId { get; set; }
    public required Guid BrandId { get; set; }
    public required Guid AccountId { get; set; }
    public required string UserName { get; set; }
    public required Guid ExternalReferenceId { get; set; }
    public required Guid TransactionTypeId { get; set; }
    public required double Amount { get; set; }
    public required DateTime CreatedDateTime { get; set; }
    public required int NumberOfBets { get; set; }
    public required string CountryCode { get; set; }
    public required string SessionData { get; set; }
    public required long Duration { get; set; }
}