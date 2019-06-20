using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Campground
    {
        public int Campground_Id { get; }
        public int Park_Id { get; }
        public string Name { get; }
        public DateTime Open_From { get; }
        public DateTime Open_to { get; }
        public decimal Daily_fee { get; }


    }
}
