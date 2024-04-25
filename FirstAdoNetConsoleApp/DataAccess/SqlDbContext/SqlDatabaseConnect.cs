using System.Data.SqlClient;

namespace FirstAdoNetConsoleApp.DataAccess.SqlDbContext
{
    public static class SqlDatabaseConnect
    {
        public static string Connect()
        {
            try
            {
                SqlConnectionStringBuilder sqlConnectionStr = new SqlConnectionStringBuilder();
                sqlConnectionStr.DataSource = "Localhost";
                sqlConnectionStr.InitialCatalog = "MyCourseDb";
                sqlConnectionStr.IntegratedSecurity = true;

                string connectionString = sqlConnectionStr.ConnectionString;
                return connectionString;
            }
            catch (Exception)
            {
                Console.WriteLine("Databazaya qoşularkən xəta baş verdi");
            }

            return null;
        }
    }
}
