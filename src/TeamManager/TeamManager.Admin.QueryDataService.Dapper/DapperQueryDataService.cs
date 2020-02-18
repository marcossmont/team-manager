using System.Data.SqlClient;

namespace TeamManager.Admin.QueryDataService.Dapper
{
    public class DapperQueryDataService
    {
        internal readonly SqlConnection _connection;

        public DapperQueryDataService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
    }
}
