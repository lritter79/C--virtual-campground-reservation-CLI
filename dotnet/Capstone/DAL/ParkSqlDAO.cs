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

        /// <summary>
        /// returns a list of all the parks in the DB
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetParks()
        {
            List<Park> Parks = new List<Park>();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from park order by name;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Parks.Add(new Park(reader));
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
