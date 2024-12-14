using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { return instance ??= new DataProvider(); }
            private set { instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = "Server=LAPTOP-AS0HAHNQ;Database=YourDatabaseName;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameter);
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object result = null;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameter);
                    result = command.ExecuteScalar();
                }
            }

            return result;
        }

        private void AddParameters(SqlCommand command, object[] parameter)
        {
            if (parameter == null) return;

            // Truyền tham số theo thứ tự
            foreach (var param in parameter)
            {
                if (param is SqlParameter sqlParameter)
                {
                    command.Parameters.Add(sqlParameter);
                }
                else
                {
                    throw new ArgumentException("All parameters must be SqlParameter objects.");
                }
            }
        }
    }
}
