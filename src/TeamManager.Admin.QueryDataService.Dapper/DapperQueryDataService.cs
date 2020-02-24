using System.Data.SqlClient;

namespace TeamManager.Admin.QueryDataService.Dapper
{
    public class DapperQueryDataService
    {
        private readonly string connectionString;

        public DapperQueryDataService(string connectionString)
        {
            this.connectionString = connectionString ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
