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

                DisplayHelper.DisplayParks(Parks);

                int choice = CLIHelper.GetInteger("\nPlease Enter the Park you would like information for (Or enter 0 to quit): ");

                if(choice != 0)
                {
                    ParkInfoMenu(choice - 1);

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

        public void ParkInfoMenu(int park_id)
        {
            Console.Clear();
            bool done = false;

            while (!done)
            {


                DisplayHelper.DisplayParkInfo(Parks[park_id]);
                int infoChoice = CLIHelper.GetInteger("\nSelect an option:\n\t1) View Campgrounds\n\t2) Show all available Campsites for this Park\n\t" +
                    "3) Diplay Reservations in this park for the next 30 days \n\t4) Return to Previous Menu\n\nEnter Choice: ");

                if (infoChoice == 1)
                {
                    DisplayCampgrounds(Parks[park_id].Park_id, Parks[park_id].Name);
                }
                else if (infoChoice == 2)
                {
                    DateTime[] dateRange = CLIHelper.GetDateRange("Please enter your planned arrival date: ", "Please enter your planned departure date : ");

                    DisplayOpenSitesEntirePark(Parks[park_id].Park_id, dateRange[0], dateRange[1]);
                    //IList<Campsite> sitesByPark = campsiteSqlDAO.GetAvailabeSitesByParkWithoutDate(Parks[park_id].Park_id);
                    //DisplayHelper.DisplaySites(sitesByPark);
                }
                else if (infoChoice == 3)
                {
                    IList < Reservation > reservations = reservationSqlDAO.GetReservationsNext30ByPark(park_id+1);
                    DisplayHelper.DisplayReservations(reservations);
                }
                else
                {
                    done = true;
                }
            }
        }


        public void DisplayCampgrounds(int park_id, string park_name)
        {
            IList<Campground> campgrounds = campgroundSqlDAO.GetCampgroundsByPark(park_id);
            bool done = false;

            while (!done)
            {


                Console.Clear();
                Console.WriteLine("Park Campgrounds");
                Console.WriteLine(park_name);

                DisplayHelper.DisplayCampgrounds(campgrounds);

                int cgChoice = CLIHelper.GetInteger("\nSelect a Campground to reserve (or enter 0 to return):  ");

                if (cgChoice != 0)
                {

                    DateTime[] dateRange = CLIHelper.GetDateRange("Please enter your planned arrival date: ", "Please enter your planned departure date : ");
                    DisplayOpenSites(campgrounds[cgChoice - 1].Campground_Id, dateRange[0], dateRange[1], campgrounds[cgChoice - 1].Daily_fee);
                }
                else
                {
                    done = true;
                }
            }
        }

        public void DisplayOpenSites(int camp_id, DateTime start, DateTime end, decimal dailyCost)
        {
            decimal estimatedCost = dailyCost * Math.Ceiling( (decimal)(end - start).TotalDays);
                        
            IList<Campsite> sites = campsiteSqlDAO.GetAvailableSitesFilteredByDate(camp_id, start, end);

            bool done = false;

            while (!done)
            {

                Console.Clear();
                Console.WriteLine("\n\nResults Matching your Criteria:\n");
                if (sites.Count == 0)
                {
                    string searchAgain = CLIHelper.GetString("There are no campsites open during that time, would you like to try different dates? ");
                    if (searchAgain.ToLower().StartsWith("n"))
                    {
                        done = true;
                    }
                }
                else
                {
                    DisplayHelper.DisplaySitesWithCost(sites, estimatedCost, 0);

                    MakeReservation(sites, start, end);

                    done = true;
                }
            }
        }

        public int DisplayOpenSitesEntirePark(int park_id, DateTime start, DateTime end)
        {
            int i = 0;
            IList<Campground> campgrounds = campgroundSqlDAO.GetCampgroundsByPark(park_id);
            List<Campsite> allSites = new List<Campsite>();

            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine($"\nAvailable sites in {cg.Name}:");

                IList<Campsite> sites = campsiteSqlDAO.GetAvailableSitesFilteredByDate(cg.Campground_Id, start, end);
                i = DisplayHelper.DisplaySitesWithCost(sites, cg.Daily_fee, i);
                allSites.AddRange(sites);
                
            }

            MakeReservation(allSites, start, end);

            return i;
        }

        public void MakeReservation (IList<Campsite> sites, DateTime start, DateTime end)
        {
            Reservation newRes = new Reservation();
            int confirmation = 0;

            int choice = CLIHelper.GetInteger("\nPlease Enter the number of the site you would like to reserve (Enter 0 to Cancel): ");
            if (choice != 0)
            {
                newRes.Site_Id = sites[choice-1].Site_Id;
                newRes.Name = CLIHelper.GetString("\nPlease enter the name to enter the reservation under: ");
                newRes.From_Date = start;
                newRes.To_Date = end;
                newRes.Create_Date = DateTime.Now;

                confirmation = reservationSqlDAO.BookReservation(newRes);
                Console.WriteLine("\n\nYour reservation has been completed, your confirmation # is CGR" + confirmation);
                Console.WriteLine("\nPlease make sure to save this for your records.  Press enter to return to the previous Menu.");
                Console.ReadLine();
            }
        }

    }
}
