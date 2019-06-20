using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Campsite
    {

        public int Site_Id { get; }
        public int Campground_Id { get; }
        public int Site_Number { get; }
        public int Max_Occupancy { get; }
        public bool IsAccessible { get; }
        public int Max_Rv_Length { get; }
        public bool HasUtilities { get; }



    }
}
