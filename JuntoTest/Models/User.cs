using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace JuntoTest.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }

        internal DbContext Db { get; set; }

        public User()
        {

        }

        internal User(DbContext db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand;
            cmd.CommandText = @"INSERT INTO `user` ('u_name', 'u_password', 'u_role') VALUES (@username, @userpassword, @userrole);";

            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            UserId = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand;
            cmd.CommandText = @"UPDATE  `user` SET 'u_name' = @username, 'u_password' = @userpassword, `u_role` = @userrole) WHERE 'u_id' = @userid;";
            
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand;
            cmd.CommandText = @"DELETE FROM 'user' WHERE 'u_id' = @userid;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();

        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userid",
                DbType = DbType.Int32,
                Value = UserId,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = UserName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userpassword",
                DbType = DbType.String,
                Value = UserPassword,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userrole",
                DbType = DbType.String,
                Value = UserRole,
            });
        }
    }
}
