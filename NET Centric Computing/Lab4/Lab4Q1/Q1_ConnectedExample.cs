// Q1_ConnectedExample.cs
using System;
using System.Data.SqlClient;

namespace Lab4
{
    public class Q1_Connected
    {
        public static void Run()
        {
            Console.WriteLine("Q1: Connected Architecture");
            string conStr = "Server=(localdb)\\MSSQLLocalDB;Database=Lab4DB;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM People", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} - {reader["Name"]} ({reader["Age"]})");
                }
            }
        }
    }
}
