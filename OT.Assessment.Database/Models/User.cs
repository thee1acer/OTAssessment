namespace OT.Assessment.Database.Models;

public class User: Audit
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
}