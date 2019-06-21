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
            Console.WriteLine("\n".PadRight(9) + "Name".PadRight(20) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Fee");

            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine($"#{i}".PadRight(8) + cg.Name.PadRight(20) + cg.Open_From.ToString().PadRight(10) + cg.Open_To.ToString().PadRight(10) + cg.Daily_fee.ToString("C"));
                i++;
            }
            return i-1;
        }

        public static int DisplaySitesWithCost(IList<Campsite> campsites, decimal estimatedCost)
        {
            int i = 0;
            Console.WriteLine("Site No.".PadRight(10) + "Max Occup.".PadRight(20) + "Accessible?".PadRight(20) + "Max RV Length".PadRight(20) + "Utility".PadRight(20) + "Cost");
            foreach (Campsite cs in campsites)
            {
                Console.WriteLine(cs.Site_Id.ToString().PadRight(10) + cs.Max_Occupancy.ToString().PadRight(20) +
                    cs.IsAccessible.ToString().PadRight(20) + cs.Max_Rv_Length.ToString().PadRight(20) +
                    cs.HasUtilities.ToString().PadRight(20) + estimatedCost.ToString("C"));
                i++;
            }
            return i;
        }

        public static void DisplayReservations(IList<Reservation> reservations)
        {


        }

    }
}
