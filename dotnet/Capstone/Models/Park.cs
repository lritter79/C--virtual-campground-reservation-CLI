using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    


    public class Park
    {
        public Park() { }

        public Park(SqlDataReader reader)
        {
            Park_id = Convert.ToInt32(reader["park_id"]);
            Name = Convert.ToString(reader["name"]);
            Location = Convert.ToString(reader["location"]);
            Establish_date = Convert.ToDateTime(reader["establish_date"]);
            Area = Convert.ToString(reader["area"]);
            Visitors = Convert.ToInt32(reader["visitors"]);
            Description = Convert.ToString(reader["description"]);


        }

        public int Park_id { get; }
        public string Name { get; }
        public string Location { get; }
        public DateTime Establish_date { get; }
        public string Area { get;  }
        public int Visitors { get; }
        public string Description { get; }



    }
}
