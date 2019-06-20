using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone.Models
{
    public class Reservation
    {
        public int Reservation_Id { get; }
        public int Site_Id { get; }
        public string Name { get; }
        public DateTime From_Date { get; }
        public DateTime To_Date { get; }
        public DateTime Create_Date { get; }


    }
}
