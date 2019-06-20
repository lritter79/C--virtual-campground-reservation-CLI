using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Capstone.DAL;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            IParkSqlDAO parkSqlDAO = new ParkSqlDAO(@"Server=.\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;");
            ICampgroundSqlDAO campgroundSqlDAO = new CampgroundSqlDAO(@"Server=.\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;");
            ICampsiteSqlDAO campsiteSqlDAO = new CampsiteSqlDAO(@"Server=.\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;");
            IReservationSqlDAO reservationsSqlDAO = new ReservationSqlDAO(@"Server=.\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;");

            //parkSqlDAO.GetParks();
            
        }
    }
}
