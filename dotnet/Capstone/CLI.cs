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

            int i = 1;
            foreach(Campground cg in campgrounds)
            {
                Console.WriteLine($"#{i}".PadRight(8) + cg.Name.PadRight(20) + cg.Open_From.ToString().PadRight(10) + cg.Open_To.ToString().PadRight(10) + cg.Daily_fee.ToString("C"));
                i++;
            }

            int cgChoice = CLIHelper.GetInteger("\nSelect a Campground to reserve (or enter 0 to return):  ");

            if (cgChoice != 0)
            {
                DateTime reservationStart = CLIHelper.GetDateTime("When is your planned arrival date? ");
                DateTime reservationEnd = CLIHelper.GetDateTime("When is your planned departure date? ");

                DisplayOpenSites(campgrounds[cgChoice-1].Campground_Id, reservationStart, reservationEnd, campgrounds[cgChoice-1].Daily_fee);



            }

        }

        public void DisplayOpenSites(int camp_id, DateTime start, DateTime end, decimal dailyCost)
        {
            decimal estimatedCost = dailyCost * Math.Ceiling( (decimal)(end - start).TotalDays);

            IList<Campsite> sites = campsiteSqlDAO.GetSiteAndReservationDate(camp_id, start, end);

            Reservation newRes = new Reservation();
            int confirmation = 0;
            bool done = false;

            while (!done)
            {


                Console.WriteLine("\n\nResults Matching your Criteria:\n");
                if (sites.Count == 0)
                {
                    string searchAgain = CLIHelper.GetString("There are no campsites open during that time, would you like to try different dates? ");
                    if (searchAgain.ToLower().StartsWith("y"))
                    {
                        DateTime reservationStart = CLIHelper.GetDateTime("When is your planned arrival date? ");
                        DateTime reservationEnd = CLIHelper.GetDateTime("When is your planned departure date? ");

                        sites = campsiteSqlDAO.GetSiteAndReservationDate(camp_id, reservationStart, reservationEnd);


                    }
                    else
                    {
                        done = true;
                    }


                }
                else
                {






                    Console.WriteLine("Site No.".PadRight(10) + "Max Occup.".PadRight(20) + "Accessible?".PadRight(20) + "Max RV Length".PadRight(20) + "Utility".PadRight(20) + "Cost");
                    foreach (Campsite cs in sites)
                    {
                        Console.WriteLine(cs.Site_Id.ToString().PadRight(10) + cs.Max_Occupancy.ToString().PadRight(20) +
                            cs.IsAccessible.ToString().PadRight(20) + cs.Max_Rv_Length.ToString().PadRight(20) +
                            cs.HasUtilities.ToString().PadRight(20) + estimatedCost.ToString("C"));
                    }

                    newRes.Site_Id = CLIHelper.GetInteger("\nPlease Enter the number of the site you would like to reserve (Enter 0 to Cancel): ");
                    if (newRes.Site_Id != 0)
                    {
                        newRes.Name = CLIHelper.GetString("\nPlease enter the name to enter the reservation under: ");
                        newRes.From_Date = start;
                        newRes.To_Date = end;
                        newRes.Create_Date = DateTime.Now;

                        confirmation = reservationSqlDAO.BookReservation(newRes);
                        Console.WriteLine("\n\nYour reservation has been completed, your confirmation # is CGR" + confirmation);
                        Console.WriteLine("\nPlease make sure to save this for your records.  Press enter to return to the previous Menu.");
                        Console.ReadLine();
                    }
                    done = true;
                }

            }
            

           
            
        }

        

    }
}
