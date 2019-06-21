using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundSqlDAOTests: DatabaseTests
    {
        [TestMethod]
        public void GetCampgroundsTest()
        {

            //Arrange
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            //Act
            IList<Campground> campGrounds = dao.GetCampgrounds();
            //Assert

            Assert.AreEqual(3, campGrounds.Count);
        }

    


        [TestMethod]
        public void GetCampgroundsByParkTest()
        {
            //Arrange
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            //Assert
            IList<Campground> campGrounds = dao.GetCampgroundsByPark(TwinPeaksParkId);
            //Act
            Assert.AreEqual(2, campGrounds.Count);
        }

    }
}
