﻿using System;
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


            


            throw new NotImplementedException();
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

        //public IList<Reservation> GetReservationsBySiteAndDate(int site_id, DateTime start, DateTime end)
        //{





        //    throw new NotImplementedException();
        //}
    }
}
