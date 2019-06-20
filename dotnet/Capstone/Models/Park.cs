using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Park
    {
        public int Park_id { get; }
        public string Name { get; }
        public string location { get; }
        public DateTime Establish_date { get; }
        public string Area { get;  }
        public int Visitors { get; }
        public string Description { get; }



    }
}
