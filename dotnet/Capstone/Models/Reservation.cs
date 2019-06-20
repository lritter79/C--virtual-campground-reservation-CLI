using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Reservation
    {
        public Reservation() { }

        public Reservation(SqlDataReader reader)
        {
            Reservation_Id = Convert.ToInt32(reader["reservation_id"]);
            Site_Id = Convert.ToInt32(reader["site_id"]);
            Name = Convert.ToString(reader["name"]);
            From_Date = Convert.ToDateTime(reader["from_date"]);
            To_Date = Convert.ToDateTime(reader["to_date"]);
            Create_Date = Convert.ToDateTime(reader["create_date"]);
        }


        public int Reservation_Id { get; }
        public int Site_Id { get; }
        public string Name { get; }
        public DateTime From_Date { get; }
        public DateTime To_Date { get; }
        public DateTime Create_Date { get; }


    }
}
