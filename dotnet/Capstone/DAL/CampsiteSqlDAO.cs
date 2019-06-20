using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampsiteSqlDAO : ICampsiteSqlDAO
    {
        private string ConnectionString = "";


        public CampsiteSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;

        }

        public IList<Campsite> GetCampsites()
        {
            List<Campsite> campsites = new List<Campsite>();


            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from campsites order by name;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        campsites.Add(new Campsite(reader));
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return campsites;
        }

        public IList<Campsite> GetCampSitesByCampgrounds(int campground_id)
        {
            List<Campsite> campsites = new List<Campsite>();


            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from campsites where site_id = @campgroundid order by name;", conn);
                    cmd.Parameters.AddWithValue("@campgroundid", campground_id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        campsites.Add(new Campsite(reader));
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return campsites;
        }
    }
}
