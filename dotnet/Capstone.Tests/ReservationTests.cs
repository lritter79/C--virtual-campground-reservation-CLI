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
        public void Returns_Count_plus_1_when_adding_new_reservation()
        {
            //Arrange
            Reservation test = new Reservation();

            //Assert

            //Act
            //Assert.AreEqual();
        }
    }
}
