using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag
{
    public class DataBase
    {
        public static string connectionString { get; } = @"Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;";
        public static List<List<object>> Select(string sqlExpression)
        {

            List<List<object>> result = new List<List<object>>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные (можно сразу типизировать)
                    {
                        result.Add(new List<object>());
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result[result.Count - 1].Add(reader.GetValue(i));
                        }
                    }
                }

                reader.Close();
                connection.Close();
            }
            return result;
        }

    }
}
