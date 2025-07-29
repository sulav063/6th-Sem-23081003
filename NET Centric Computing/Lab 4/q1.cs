using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adjust this connection string based on your server instance name
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=lab4;Trusted_Connection=True;";

            Console.WriteLine("=== Connected Architecture ===");
            ConnectedArchitecture(connectionString);

            Console.WriteLine("\n=== Disconnected Architecture ===");
            DisconnectedArchitecture(connectionString);

            Console.ReadLine();
        }

        static void ConnectedArchitecture(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Salary: {reader["Salary"]}");
                }

                reader.Close(); // Important to close reader
            }
        }

        static void DisconnectedArchitecture(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Employees");

                DataTable dt = ds.Tables["Employees"];

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Salary: {row["Salary"]}");
                }
            }
        }
    }
}
