using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private string connectionSTR = "Data Source=LAPTOP-G7HG4LHI\\SQLEXPRESS;Initial Catalog=SuShi10;Integrated Security=True;Trust Server Certificate=True";

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

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }

        public DataTable ExecuteStoredProcedure(string storedProcName, SqlParameter[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }

            return data;
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

        public void AddParameters(SqlCommand command, object[] parameter)
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
