namespace OT.Assessment.Database.Models;

public class Account
{
    public Guid Id { get; set; }
    public bool Balance { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}