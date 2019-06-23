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
    public class CampsiteTests: DatabaseTests
    {
        [TestMethod]
        public void ConstructsCampsitesProperly()
        {
            //Assign
            CampsiteSqlDAO campsiteSqlDAO = new CampsiteSqlDAO(ConnectionString);
            IList<Campsite> campsites = campsiteSqlDAO.GetCampsites();

            //Assert
            Assert.AreEqual(BlackLodgeCampgroundId, campsites[0].Campground_Id);
            Assert.AreEqual(9, campsites[0].Site_Number);
            Assert.AreEqual(100, campsites[0].Max_Occupancy);
            Assert.AreEqual(true, campsites[0].IsAccessible);
            Assert.AreEqual(0, campsites[0].Max_Rv_Length);
            Assert.AreEqual(true, campsites[0].HasUtilities);
        }
    }
}
