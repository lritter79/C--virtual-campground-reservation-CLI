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

        /// <summary>
        /// returns a list of all the campgrounds in the DB
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Returns a list of the campgrounds in a specific park
        /// </summary>
        /// <param name="park_id"></param>
        /// <returns></returns>
        public IList<Campground> GetCampgroundsByPark(int park_id)
        {
            List<Campground> Camps = new List<Campground>();


            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from campground where park_id = @parkid order by name;", conn);
                    cmd.Parameters.AddWithValue("@parkid", park_id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Camps.Add(new Campground(reader));
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return Camps;
        }
    }
}
