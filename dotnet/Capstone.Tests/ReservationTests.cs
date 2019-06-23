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


    }
}
