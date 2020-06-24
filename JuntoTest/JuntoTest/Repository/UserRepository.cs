using JuntoTest.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Dapper;

namespace JuntoTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<user> GetAll()
        {
            using (MySqlConnection connection = new
                MySqlConnection(_connectionString))
            {
                return connection.Query<user>("SELECT * from user order by id asc");
            }
        }
    }
}