using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Sample.Domain;
using Sample.Repositoy.Interface;

namespace Sample.Repository.ADONET
{

    public class MusicRepository : BaseRepository, IMusicRepository_ADONET
    {
        public MusicInfo Find(int id)
        {
            string sql = "select * from tMusic where Id = @Id";

            var item = new MusicInfo();
            using (SqlConnection conn = new SqlConnection(ConnectionString))

            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                comm.Parameters.Add(new SqlParameter("Id", id));
                if (conn.State != ConnectionState.Open) conn.Open();
                using (IDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PropertyInfo property = item.GetType().GetProperty(reader.GetName(i));

                            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
                            {
                                ReflectionHelper.SetValue(property.Name, reader.GetValue(i), item);
                            }
                        }
                    }
                }
            }
            return item;
        }

        public IEnumerable<MusicInfo> List()
        {
            string sql = "select * from tMusic";

            var employees = new List<MusicInfo>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))

            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;
                if (conn.State != ConnectionState.Open) conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new MusicInfo();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PropertyInfo property = item.GetType().GetProperty(reader.GetName(i));

                            if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
                            {
                                ReflectionHelper.SetValue(property.Name, reader.GetValue(i), item);
                            }
                        }
                        employees.Add(item);
                    }
                }
            }

            return employees;
        }
    }
}
