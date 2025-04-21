namespace OT.Assessment.Api.Models;

public class UserDTO : AuditDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required int Age { get; set; }
    public required string Phone { get; set; }    
    
    public Guid AccesLevelId { get; set; }
    public virtual required AccessLevelDTO AccesLevel { get; set; }
}