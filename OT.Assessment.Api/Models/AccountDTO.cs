namespace OT.Assessment.Models;

public class AccountDTO
{
    public Guid Id { get; set; }
    public bool AccountBalance { get; set; }
    public Guid UserId { get; set; }
    public required UserDTO User { get; set; }
}