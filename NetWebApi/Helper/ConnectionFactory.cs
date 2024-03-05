using Microsoft.EntityFrameworkCore.Infrastructure;
using NetWebApi.Interfaces;

namespace NetWebApi.Helper
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly DBConnection _dbConnection;

        public ConnectionFactory(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DBConnection GetDatabase()
        {
            return _dbConnection;
        }
    }
}
