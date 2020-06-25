using MySqlConnector;
using System;

namespace JuntoTest
{
    public class DbContext : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DbContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
