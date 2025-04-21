namespace OT.Assessment.Database.Models;

public class User : Audit
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required int Age { get; set; }
    public required string Phone { get; set; }    
    
    public Guid AccesLevelId { get; set; }
    public virtual required AccessLevel AccesLevel { get; set; }
    

    public Guid AccountId { get; set; }
    public virtual required Account Account { get; set; }
}