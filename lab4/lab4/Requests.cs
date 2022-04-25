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
    public class Requests
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["FriendsDB"].ConnectionString;

        private static SqlConnection sqlConnection = null;
        public int Select()
        {
            string select = "select * from [Friends]";
            SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
            SqlDataReader sqlDataReader = null;
            sqlDataReader = sqlCommand.ExecuteReader();
            string today = "2003-12-11";
            while (sqlDataReader.Read())
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"{sqlDataReader["id"]}" + " " +
                $"{sqlDataReader["name"]}" + " " +
                $"{sqlDataReader["surname"]}" + " " +
                $"{sqlDataReader["date"]}" + " " +
                $"{sqlDataReader["year"]}" + " год");
                Console.WriteLine(new string('-', 50));
                if (today == (string)sqlDataReader["date"])
                {
                    Console.WriteLine($"Сегодня день рождения у " +
                    $"{sqlDataReader["name"]}" + " " + $"{sqlDataReader["surname"]}");
                }
            }

            while (sqlDataReader.Read())
            {
                if (today == (string)sqlDataReader["date"])
                {
                    Console.WriteLine($"Сегодня день рождения у " +
                    $"{sqlDataReader["name"]}" + " " + $"{sqlDataReader["surname"]}");
                }
            }

            if (sqlDataReader != null)
            {
                sqlDataReader.Close();
            }
            return 0;
        }

        public int Insert(string insert)
        {
            SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
            Console.WriteLine($"Добавлено: {sqlCommand.ExecuteNonQuery()} строк(а)");
            return 0;
        }

        public int Delete(string delete)
        {
            SqlCommand sqlCommand = new SqlCommand(delete, sqlConnection);
            Console.WriteLine($"Удалено: {sqlCommand.ExecuteNonQuery()} строк(а)");
            return 0;
        }

        public int Exit()
        {
            SqlDataReader sqlDataReader = null;
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            if (sqlDataReader != null)
            {
                sqlDataReader.Close();
            }
            return 0;
        }
    }
}