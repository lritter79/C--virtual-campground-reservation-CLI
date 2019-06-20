using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass]    
    public class ParkSqlDAOTests: DatabaseTests
    {
        [TestMethod]
        [DataRow(1,"Twin Peaks")]
        public void GetParksTest(int ExpectedParkId, string ExpectedParkName)
        {
            //Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            //Act
            IList<Park> parks = dao.GetParks();
            //Assert
            Assert.AreEqual(ExpectedParkId, 1);
            Assert.AreEqual(ExpectedParkName, "Twin Peaks");
        }

    }
}
