namespace OT.Assessment.Database.Helpers;

public class ConnectionString
{
    public required string Server { get; set; }
    public required string DatabaseName { get; set; }
    public required string User { get; set; }
    public required string Password { get; set; }
}
