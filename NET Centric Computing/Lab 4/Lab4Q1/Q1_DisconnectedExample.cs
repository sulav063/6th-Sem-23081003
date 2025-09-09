using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab4
{
    public class Q1_Disconnected
    {
        public static void Run()
        {
            Console.WriteLine("Q1: Disconnected Architecture");

            string conStr = "Server=(localdb)\\MSSQLLocalDB;Database=Lab4DB;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                // SqlDataAdapter works without keeping the connection open
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM People", conn);
                DataTable table = new DataTable();

                // Fill DataTable from database (connection opens and closes internally)
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row["Id"]} - {row["Name"]} ({row["Age"]})");
                }
            }
        }
    }
}
