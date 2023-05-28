using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    internal static class Program
    {
        static void Main()
        {
            try
            {
                string connectionString =
                   @"Data Source=DESKTOP-4EUM035;Initial Catalog=DATABASE Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);
                    connection.Open();
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }
    }
}
