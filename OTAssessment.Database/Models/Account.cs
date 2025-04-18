namespace OT.Assessment.Database.Models;

public class Account
{
    public Guid Id { get; set; }
    public bool AccountBalance { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
}