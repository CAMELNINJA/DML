using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Medical_System
{
    
        public class DataBase
        {
            public static string connectionString { get; } = @"Host=localhost;Port=5433;Database=deliveryclub;User Id=postgres;Password=12345;";
            public static List<List<object>> Select(string sqlExpression)
            {

                List<List<object>> result = new List<List<object>>();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read()) 
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

