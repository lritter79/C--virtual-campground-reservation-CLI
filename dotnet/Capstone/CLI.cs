using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    public class ReservationSystemCLI
    {

        private IParkSqlDAO parkSqlDAO;
        private ICampgroundSqlDAO campgroundSqlDAO;
        private ICampsiteSqlDAO campsiteSqlDAO;
        private IReservationSqlDAO reservationSqlDAO;

        private IList<Park> Parks;


        public ReservationSystemCLI(IParkSqlDAO parkSqlDAO, ICampgroundSqlDAO campgroundSqlDAO, ICampsiteSqlDAO campsiteSqlDAO, IReservationSqlDAO reservationSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
            this.campgroundSqlDAO = campgroundSqlDAO;
            this.campsiteSqlDAO = campsiteSqlDAO;
            this.reservationSqlDAO = reservationSqlDAO;
        }

        //public IList<Park> parks = parkSqlDAO.GetParks();

        /// <summary>
        /// This is the main interface for the reservation system
        /// </summary>
        /// <param name=""></param>
        public void ReservationInterface()
        {
            bool done = false;

            Parks = parkSqlDAO.GetParks();

            while (!done)
            {

                PrintHeader();

                DisplayParks(Parks);

                int choice = CLIHelper.GetInteger("\nPlease Enter the Park you would like information for (Or enter 0 to quit): ");

                if(choice != 0)
                {
                    Console.Clear();
                    DisplayParkInfo(Parks[choice-1]);





                }
                else
                {
                    done = true;
                }


            }
            





        }


        public void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("View Parks Interface");
            Console.WriteLine("Select a Park for Further Details\n");            
            
        }


        public void DisplayParks(IList<Park> parks)
        {
            int i = 1;

            foreach(Park park in parks)
            {
                Console.WriteLine($"\t{i})  {park.Name} ");
                i++;
            }
        }


        public void DisplayParkInfo(Park park)
        {
            Console.WriteLine("Park Information Screen\n");
            Console.WriteLine(park.Name);
            Console.WriteLine("Location:".PadRight(20) + park.Location);
            Console.WriteLine("Established:".PadRight(20) + park.Establish_date);
            Console.WriteLine("Area".PadRight(20) + park.Area);
            Console.WriteLine("Annual Visitors:".PadRight(20) + park.Visitors);
            Console.WriteLine("\n" + park.Description);

            int infoChoice = CLIHelper.GetInteger("\nSelect an option:\n\t1) View Campgrounds\n\t2)Search For Reservation\n\t3) Return to Previous Menu\n\nEnter Choice: ");

            if(infoChoice == 1)
            {
                DisplayCampgrounds(park.Park_id, park.Name);

            }

        }


        public void DisplayCampgrounds(int park_id, string park_name)
        {
            IList<Campground> campgrounds = campgroundSqlDAO.GetCampgroundsByPark(park_id);

            Console.Clear();
            Console.WriteLine("Park Campgrounds");
            Console.WriteLine(park_name);
            Console.WriteLine("\n".PadRight(9) + "Name".PadRight(20) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Fee");

            int i = 0;
            foreach(Campground cg in campgrounds)
            {
                Console.WriteLine($"#{i}".PadRight(8) + cg.Name.PadRight(20) + cg.Open_From.ToString().PadRight(10) + cg.Open_To.ToString().PadRight(10) + cg.Daily_fee.ToString("C"));
                i++;
            }

            int cgChoice = CLIHelper.GetInteger("\nSelect an option:\n\t1) Search for Available Reservation\n\t2) Return to Previous Menu\n\nEnter Choice: ");

        }

    }
}
