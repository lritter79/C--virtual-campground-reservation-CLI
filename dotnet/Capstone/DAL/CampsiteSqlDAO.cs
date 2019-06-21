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

        /// <summary>
        /// Gets a full list of all sites from the DB
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a list of the campsites that are in a specific campground
        /// </summary>
        /// <param name="campground_id"></param>
        /// <returns></returns>
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

        public IList<Campsite> GetSiteAndReservationDate(int site_id, DateTime start, DateTime end)
        {
            List<Campsite> sites = new List<Campsite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TOP 5 * from site where site_id in (select site_id from reservation " +
                        "where site_id = @siteid and from_date > @end or to_date < @start ) " +
                        "order by site_number;", conn);

                    cmd.Parameters.AddWithValue("@siteid", site_id);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        sites.Add(new Campsite(reader));
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return sites;
        }


    }
}
