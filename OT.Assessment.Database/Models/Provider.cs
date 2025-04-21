namespace OT.Assessment.Database.Models;

public class Provider
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public virtual ICollection<Game>? Games { get; set; }
}