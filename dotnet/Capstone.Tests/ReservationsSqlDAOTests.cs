using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationsSqlDAOTests:DatabaseTests
    {
        [TestMethod]
        public void BookReservationsTest()
        {
            //initialize reservation
            Reservation alpha = new Reservation();

            //gets connections
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //opens connection
                connection.Open();
                //Arrange
                //querystring = the query we want to put into the SQL databse to get the values for the reservation
                string queryString = $"SELECT * FROM reservation WHERE reservation_id = {BlackLodgeReservationId}";
                //takes query string and makes it into a command that can be used in SQL
                SqlCommand command = new SqlCommand(queryString, connection);
                //gets the data returend by the query
                SqlDataReader reader = command.ExecuteReader();
                //the reader reads row by row, in this case only reading the one row
                while (reader.Read())
                {
                    alpha = new Reservation(reader);   
                }

            }

            ReservationSqlDAO beta = new ReservationSqlDAO(ConnectionString);

                //Act
                int testRes = beta.BookReservation(alpha);
                //Assert
                Assert.IsTrue(testRes != 0);
        }

        [TestMethod]
        public void GetReservationsTest()
        {
            //Arrange

            ReservationSqlDAO beta = new ReservationSqlDAO(ConnectionString);
            List<Reservation> resTest = new List<Reservation>();

            //Act


            resTest = new List<Reservation>(beta.GetReservations());

            //Assert
            Assert.IsTrue(resTest[0].Reservation_Id == BlackLodgeReservationId);


        }

        [TestMethod]
        public void Returns_Count_plus_1_when_adding_new_reservation()
        {
            //Arrange
            ReservationSqlDAO reservationSqlDAO = new ReservationSqlDAO(ConnectionString);

            Reservation test = new Reservation();
            test.Site_Id = BlackLodgeSiteId;
            test.Name = "testname";
            test.From_Date = DateTime.Now;
            test.To_Date = DateTime.Now.AddDays(5);
            test.Create_Date = DateTime.Now;

            //Act
            reservationSqlDAO.BookReservation(test);

            //Assert
            Assert.AreEqual(2, reservationSqlDAO.GetReservations().Count);


        }

    }
}
