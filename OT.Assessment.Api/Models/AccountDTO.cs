namespace OT.Assessment.Api.Models;

public class AccountDTO
{
    public Guid Id { get; set; }
    public bool Balance { get; set; }

    public Guid UserId { get; set; }
    public virtual UserDTO User { get; set; }
}