using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    public static class DisplayHelper
    {
        public static void DisplayParks(IList<Park> parks)
        {
            int i = 1;

            foreach (Park park in parks)
            {
                Console.WriteLine($"\t{i})  {park.Name} ");
                i++;
            }

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

        public static void DisplayCampgrounds(IList<Campground> campgrounds)
        {
            //Console.Clear();
            //Console.WriteLine("Park Campgrounds");
            //Console.WriteLine(park_name);
            Console.WriteLine("\n".PadRight(9) + "Name".PadRight(20) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Fee");

            int i = 1;
            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine($"#{i}".PadRight(8) + cg.Name.PadRight(20) + cg.Open_From.ToString().PadRight(10) + cg.Open_To.ToString().PadRight(10) + cg.Daily_fee.ToString("C"));
                i++;
            }
        }

        public static void DisplaySites(IList<Campsite> campsites)
        {
            Console.WriteLine("\n".PadRight(9) + "Site Number".PadRight(20) + "Max. Occupancy".PadRight(20) + "Accessible".PadRight(20) + "Max. RV Length".PadRight(20) + "Utilities");

            
            foreach (Campsite cs in campsites)
            {
                Console.WriteLine("\n".PadRight(9) + cs.Site_Number.ToString().PadRight(20) + cs.Max_Occupancy.ToString().PadRight(20) + cs.IsAccessible.ToString().PadRight(20)+ cs.Max_Rv_Length.ToString().PadRight(20) + cs.HasUtilities.ToString());
                
            }
        }

      


        public static void DisplayReservations(IList<Reservation> reservations)
        {


        }

    }
}
