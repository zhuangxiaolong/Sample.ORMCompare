using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Sample.Domain;
using Sample.Repositoy.Interface;

namespace Sample.Repository.Dapper
{
    public class MusicRepository: BaseRepository,IMusicRepository
    {
        public MusicInfo Find(int id)
        {
            string sql = "select * from tMusic where Id = @Id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Query<MusicInfo>(
                    sql,
                    new
                    {
                        Id = id

                    }).FirstOrDefault();
                return result;

            }
        }

        public IEnumerable<MusicInfo> List()
        {
            string sql = "select * from tMusic";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Query<MusicInfo>(sql);
                return result;
            }
        }
    }
}
