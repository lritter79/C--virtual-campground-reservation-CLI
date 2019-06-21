using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IList<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from reservations order by name, from_date;", conn);

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

    }
}
