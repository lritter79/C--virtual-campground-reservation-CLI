using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationSqlDAO
    {

        private string ConnectionString = "";

        public ReservationSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// books a reservation into the database, returns the confirmation number
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public int BookReservation(Reservation reservation)
        {
            int confirmation = 0;

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT into reservation values(@siteid, @name, @from, @till, @created); SELECT SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@siteid", reservation.Site_Id);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@from", reservation.From_Date);
                    cmd.Parameters.AddWithValue("@till", reservation.To_Date);
                    cmd.Parameters.AddWithValue("@created", reservation.Create_Date);

                    confirmation = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return confirmation;
        }

        /// <summary>
        /// gets a list of all reservations
        /// </summary>
        /// <returns></returns>
        public IList<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from reservation order by name, from_date;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reservations.Add(new Reservation(reader));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return reservations;
        }

        /// <summary>
        /// gets a list of all reservations for a specific park in the next 30 days
        /// </summary>
        /// <param name="park_id"></param>
        /// <returns></returns>
        public IList<Reservation> GetReservationsNext30ByPark(int park_id)
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand($"select * from reservation where site_id in(select site_id from site where site.campground_id in (select campground_id from campground where campground.park_id = @parkid))" +
                        $" and from_date >= GETDATE() and from_date <= DATEADD(day, 30, GETDATE()) order by from_date;", conn);
                    cmd.Parameters.AddWithValue("@parkid", park_id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reservations.Add(new Reservation(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return reservations;
        }
    }
}
