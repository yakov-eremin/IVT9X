using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace lab4
{
    public class Program
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["lab4DB"].ConnectionString;

        private static SqlConnection sqlConnection = null;

        static void Main(string[] args)
        {
            Requests requests = new Requests();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string command = string.Empty;
            while (true)
            {
                Console.WriteLine("1.Показать всех друзей");
                Console.WriteLine("2.Добавить друга");
                Console.WriteLine("3.Удалить друга");
                Console.WriteLine("4.Выйти");
                Console.Write("> ");
                command = Console.ReadLine();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                if (command.ToLower().Equals("1"))
                {
                    requests.Select();
                }

                if (command.ToLower().Equals("2"))
                {
                    Console.WriteLine($"Введите SQL запрос (insert into friends (name, surname, date, year) values (N'', N'', '', '')");
                    Console.Write("> ");
                    string insert = Console.ReadLine();
                    requests.Insert(insert);
                }
                if (command.ToLower().Equals("3"))
                {
                    Console.WriteLine($"Введите SQL запрос (delete from friends where id='')");
                    Console.Write("> ");
                    string delete = Console.ReadLine();
                    requests.Delete(delete);
                }

                if (command.ToLower().Equals("4"))
                {
                    requests.Exit();
                    break;
                }
            }
        }
    }
}