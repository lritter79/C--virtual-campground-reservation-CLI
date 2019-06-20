using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Campground
    {
        public Campground() { }

        public Campground(SqlDataReader reader)
        {
            Campground_Id = Convert.ToInt32(reader["campground_id"]);
            Park_Id = Convert.ToInt32(reader["park_id"]);
            Name = Convert.ToString(reader["name"]);
            Open_From = Convert.ToDateTime(reader["open_from_mm"]);
            Open_To = Convert.ToDateTime(reader["open_to_mm"]);
            Daily_fee = Convert.ToDecimal(reader["daily_fee"]);

        }

        public int Campground_Id { get; }
        public int Park_Id { get; }
        public string Name { get; }
        public DateTime Open_From { get; }
        public DateTime Open_To { get; }
        public decimal Daily_fee { get; }


    }
}
