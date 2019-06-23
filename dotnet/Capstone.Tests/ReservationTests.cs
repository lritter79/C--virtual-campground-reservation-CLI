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
    public class ReservationTests: DatabaseTests
    {

        [TestMethod]
        public void ConstructsReservationsProperly()
        {
            //Assign
            ReservationSqlDAO reservationSqlDAO = new ReservationSqlDAO(ConnectionString);
            IList<Reservation> reservations = reservationSqlDAO.GetReservations();

            //Assert
            Assert.AreEqual(BlackLodgeSiteId, reservations[0].Site_Id);
            Assert.AreEqual("Dale Cooper", reservations[0].Name);
            Assert.AreEqual("2/26/1991", reservations[0].From_Date.ToShortDateString());
            Assert.AreEqual("4/26/1991", reservations[0].To_Date.ToShortDateString());
            Assert.AreEqual("4/27/1991", reservations[0].Create_Date.ToShortDateString());
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
