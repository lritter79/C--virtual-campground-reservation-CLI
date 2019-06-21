﻿using System;
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

                    SqlCommand cmd = new SqlCommand("SELECT * from campsites where site_id = @campgroundid;", conn);
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


                    //selects from the DB any campsites in the selected campground
                    //that do not have current reservations during that date range
                    //and the park is open during that month
                    SqlCommand cmd = new SqlCommand("SELECT TOP 5 * from site " +
                        "join campground on site.campground_id = campground.campground_id " +
                        "where campground.campground_id = @siteid and site_id not in (select site_id from reservation " +
                        "where campground.campground_id = @siteid and ((from_date >= @start and from_date <= @end) or " +
                        "(to_date <= @end and to_date >= @start ))) " +
                        "and ((MONTH(@start) >= campground.open_from_mm) and " +
                        "(MONTH(@end) <= campground.open_to_mm))" +
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
                //Add way to reset after getting thrown an invalid date
            }

            return sites;
        }


    }
}
