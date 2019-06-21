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
        public void GetCampSitesByCampgrounds()
        {
            //Arrange

            //Act

            //Asserts
        }
    }
}
