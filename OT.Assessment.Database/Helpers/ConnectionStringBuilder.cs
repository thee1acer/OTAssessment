namespace OT.Assessment.Database.Helpers;

public class ConnectionStringBuilder
{
    public static string BuildConnectionString(ConnectionString connectionDetails)
    {
        return @$"
            Server=tcp:{connectionDetails.Server},1433;
            Initial Catalog={connectionDetails.DatabaseName};
            Persist Security Info=False;
            User ID={connectionDetails.User};
            Password={connectionDetails.Password};
            MultipleActiveResultSets=False;
            Encrypt=False;
            TrustServerCertificate=False;
            Connection Timeout=30;
        ";
    }
}

