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

            Assert.AreEqual(campGrounds.Count, 2);
        }

    


        [TestMethod]
        public void GetCampgroundsByParkTest()
        {
            //Arrange

            //Assert

            //Act
        }

    }
}
