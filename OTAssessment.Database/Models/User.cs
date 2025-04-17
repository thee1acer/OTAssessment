namespace OT.Assessment.Database.Models;

public class User: Audit
{
    public int Id { get; set; }
    public required string ApplicationUserName { get; set; }
    public required string ApplicationUserSurname { get; set; }
    public required string ApplicationUserEmail { get; set; }
}