namespace CrudAppUsingADO
{
    public class ConnectionString
    {
        private static string cs = "server=DESKTOP-50EGI1K\\SQLEXPRESS; Database=CrudADOdb; Trusted_Connection=True";
        public static string dbcs {  get => cs; } 
    }
}
