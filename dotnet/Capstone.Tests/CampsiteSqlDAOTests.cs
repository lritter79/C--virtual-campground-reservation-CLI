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
    public class CampsiteSqlDAOTests : DatabaseTests
    {

        [TestMethod]
        public void GetCampsites()
        {
            //Arrange
            CampsiteSqlDAO dao = new CampsiteSqlDAO(ConnectionString);
            //Act
            IList<Campsite> test = dao.GetCampsites();
            //Assert
            Assert.IsTrue(test.Count == 2);
        }

        [TestMethod]
        public void GetCampSitesByCampgroundsTest()
        {
            //Arrange
            CampsiteSqlDAO dao = new CampsiteSqlDAO(ConnectionString);
            //Act
            IList<Campsite> test = dao.GetCampSitesByCampgrounds(WhiteLodgeCampgroundId);
            //Asserts
            Assert.IsTrue(test.Count == 1);
        }
        

        [TestMethod]
        public void GetSiteAndReservationDateTest()
        {
            //Arrange
            CampsiteSqlDAO dao = new CampsiteSqlDAO(ConnectionString);
            DateTime fromDate = new DateTime(1991, 2, 26, 12, 0, 0);
            DateTime toDate = new DateTime(1991, 4, 26, 12, 0, 0);
            //Act
            IList<Campsite> test = dao.GetAvailableSitesFilteredByDate(WhiteLodgeCampgroundId,fromDate, toDate);
            //Asserts
            Assert.IsTrue(test.Count == 1);
        }
        
        [TestMethod]
        public void GetAvailabeSitesByParkTest()
        {
            //Arrange
            CampsiteSqlDAO dao = new CampsiteSqlDAO(ConnectionString);
            DateTime fromDate = new DateTime(1991, 2, 27, 12, 0, 0);
            DateTime toDate = new DateTime(1991, 4, 24, 12, 0, 0);
            //Act
            IList<Campsite> test = dao.GetAvailabeSitesByPark(TwinPeaksParkId, fromDate, toDate);
            //Asserts
            Assert.IsTrue(test.Count == 2);
        }
    }
}
