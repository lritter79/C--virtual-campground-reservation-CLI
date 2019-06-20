using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Campsite
    {

        public Campsite() { }

        public Campsite(SqlDataReader reader)
        {
            Site_Id = Convert.ToInt32(reader["site_id"]);
            Campground_Id = Convert.ToInt32(reader["campground_id"]);
            Site_Number = Convert.ToInt32(reader["site_number"]);
            Max_Occupancy = Convert.ToInt32(reader["max_occupancy"]);
            IsAccessible = Convert.ToBoolean(reader["accessible"]);
            Max_Rv_Length = Convert.ToInt32(reader["max_rv_length"]);
            HasUtilities = Convert.ToBoolean(reader["utilities"]);


        }

        public int Site_Id { get; }
        public int Campground_Id { get; }
        public int Site_Number { get; }
        public int Max_Occupancy { get; }
        public bool IsAccessible { get; }
        public int Max_Rv_Length { get; }
        public bool HasUtilities { get; }



    }
}
