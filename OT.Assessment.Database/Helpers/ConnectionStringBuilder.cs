namespace OT.Assessment.Database.Helpers;

public class ConnectionStringBuilder
{
    public static string BuildConnectionString(ConnectionString connectionDetails)
    {
        return @$"
            Server=tcp:{connectionDetails.Server};
            Initial Catalog={connectionDetails.DatabaseName};
            Persist Security Info=False;
            User ID={connectionDetails.User};
            Password={connectionDetails.Password};
            Max Pool Size=500;
            MultipleActiveResultSets=False;
            Encrypt=False;
            TrustServerCertificate=False;
        ";
    }
}

