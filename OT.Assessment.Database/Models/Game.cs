namespace OT.Assessment.Database.Models;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public required string ThemeName { get; set; }
    public virtual required Theme Theme { get; set; }

    public Guid ProviderId { get; set; }
    public virtual required Provider Provider { get; set; }      
}