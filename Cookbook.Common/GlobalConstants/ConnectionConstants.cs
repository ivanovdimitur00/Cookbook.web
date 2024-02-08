namespace Cookbook.Common.GlobalConstants
{
    public class ConnectionConstants
    {
        public const string DatabaseConnectionString = @"C:\Users\User\AppData\Roaming\Microsoft\UserSecrets" +
           @"\aspnet-Cookbook.Web-0562f6e0-f469-41dd-b124-74d205d848e2";

        public const string SecretsJSONFileName = "secrets.json";

        public const string SecretsJSONConnectionStringSection = "DefaultConnection:ConnectionString";
    }
}