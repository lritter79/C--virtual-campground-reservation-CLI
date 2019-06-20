using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkSqlDAO
    {
        private string ConnectionString;

        public ParkSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;

        }

        public IList<Park> GetParks()
        {
            List<Park> Parks = new List<Park>();

            try
            {
                using(SqlConnection conn = new SqlConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from park order by name;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                    }


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                throw;
            }

            return Parks;
        }
    }
}
