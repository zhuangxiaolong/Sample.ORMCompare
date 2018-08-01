using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Sample.Domain;
using Sample.Repositoy.Interface;

namespace Sample.Repository.Dapper
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        public UserInfo Find(int id)
        {
            string sql = "select * from tUser where Id = @Id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Query<UserInfo>(
                    sql,
                    new
                    {
                        Id = id

                    }).FirstOrDefault();
                return result;

            }
        }

        public IEnumerable<UserInfo> List()
        {
            string sql = "select * from tUser";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Query<UserInfo>(sql);
                return result;
            }
        }
    }
}
