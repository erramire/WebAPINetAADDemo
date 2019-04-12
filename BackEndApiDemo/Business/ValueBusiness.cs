using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackEndApiDemo.Business
{
    public class ValueBusiness
    {
        private string _stringConnection;
        public ValueBusiness(string stringConnection) {
            _stringConnection = stringConnection;

        }

        public string[] GetAllValues() {
            List<string> Results= new List<string>();
            using (SqlConnection connection= new SqlConnection(_stringConnection))
            {
                if (ConfigurationManager.AppSettings["Mode"] != "Development")
                {
                    connection.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
                }
                SqlCommand command = new SqlCommand("Select Descript from Values_tbl;",connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string val = reader["Descript"].ToString();
                            Results.Add(val);
                        }
                    }
                    
                    reader.Close();
                }
            }

            return Results.ToArray<string>();
        }
    }
}