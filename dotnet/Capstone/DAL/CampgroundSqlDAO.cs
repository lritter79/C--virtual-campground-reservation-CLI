using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundSqlDAO
    {
        private string ConnectionString = "";

        public CampgroundSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;

        }

        public IList<Campground> GetCampgrounds()
        {
            List<Campground> Camps = new List<Campground>();


            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from campground order by name;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Camps.Add(new Campground(reader));
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return Camps;
        }
    }
}
