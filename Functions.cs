using Microsoft.Azure.WebJobs;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJob2
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            // Create a new event listener.
            //using (SQLClientListener listener = new SQLClientListener())
            //{
                string connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Employees";
                    SqlCommand command = new SqlCommand(sql, connection);
                    Console.WriteLine(sql);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Read the data.
                    }
                    reader.Close();
                }
                //Hacky I know but should collect the query
            //}

            log.WriteLine(message);
        }
    }
}
