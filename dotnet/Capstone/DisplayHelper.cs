using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    public static class DisplayHelper
    {
        public static int DisplayParks(IList<Park> parks)
        {
            int i = 1;

            foreach (Park park in parks)
            {
                Console.WriteLine($"\t{i})  {park.Name} ");
                i++;
            }
            return i;
        }

        public static void DisplayParkInfo(Park park)
        {
            Console.WriteLine("Park Information Screen\n");
            Console.WriteLine(park.Name);
            Console.WriteLine("Location:".PadRight(20) + park.Location);
            Console.WriteLine("Established:".PadRight(20) + park.Establish_date);
            Console.WriteLine("Area".PadRight(20) + park.Area);
            Console.WriteLine("Annual Visitors:".PadRight(20) + park.Visitors);
            Console.WriteLine("\n" + park.Description);
        }

        public static int DisplayCampgrounds(IList<Campground> campgrounds)
        {

            int i = 1;
            Console.WriteLine("\n".PadRight(9) + "Name".PadRight(35) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Fee");

            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine($"#{i}".PadRight(8) + cg.Name.PadRight(35) + cg.Open_From.ToString().PadRight(10) + cg.Open_To.ToString().PadRight(10) + cg.Daily_fee.ToString("C"));
                i++;
            }
            return i-1;
        }

        public static int DisplaySitesWithCost(IList<Campsite> campsites, decimal estimatedCost, int choicenumber)
        {
            Console.WriteLine("\n".PadRight(9) + "Site Number".PadRight(20) + "Max. Occupancy".PadRight(20) + "Accessible".PadRight(20) + "Max. RV Length".PadRight(20) + "Utilities");
                        
            foreach (Campsite cs in campsites)
            {
                choicenumber++;
                Console.WriteLine($"{choicenumber})".PadRight(9) + $"{cs.Site_Number}".PadRight(20) + $"{cs.Max_Occupancy}".PadRight(20) + (cs.IsAccessible ? "yes" : "no").PadRight(20)+ $"{cs.Max_Rv_Length}".PadRight(20) + (cs.HasUtilities ? "yes" : "no"));
                
            }
            return choicenumber;
        }


        public static void DisplaySites(IList<Campsite> campsites)
        {
            Console.WriteLine("\n".PadRight(9) + "Site Number".PadRight(20) + "Max. Occupancy".PadRight(20) + "Accessible".PadRight(20) + "Max. RV Length".PadRight(20) + "Utilities");

            foreach (Campsite cs in campsites)
            {
                Console.WriteLine("\n".PadRight(9) + cs.Site_Number.ToString().PadRight(20) + cs.Max_Occupancy.ToString().PadRight(20) + (cs.IsAccessible ? "yes" : "no").PadRight(20) + cs.Max_Rv_Length.ToString().PadRight(20) + (cs.HasUtilities ? "yes" : "no"));
                
            }
        }


        public static void DisplayReservations(IList<Reservation> reservations)
        {
            Console.WriteLine("Site_Number".PadRight(10) + "Confirmation #".PadRight(20) +  "Start date".PadRight(15) + "End date".PadRight(15) + "Made on");

            foreach(Reservation res in reservations)
            {
                Console.WriteLine($"{res.Site_Id}".PadRight(10) + $"CGR{res.Reservation_Id}".PadRight(20) +  res.From_Date.ToShortDateString().PadRight(15) + res.To_Date.ToShortDateString().PadRight(15) + res.Create_Date.ToShortDateString());
               
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
