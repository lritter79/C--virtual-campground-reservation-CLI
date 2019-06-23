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
    public class CampgroundTests: DatabaseTests
    {
        [TestMethod]
        public void ConstructsCampgroundProperly()
        {
            //assign
            CampgroundSqlDAO campgroundSqlDAO = new CampgroundSqlDAO(ConnectionString);
            IList<Campground> campgrounds = campgroundSqlDAO.GetCampgrounds();


            //assert
            Assert.AreEqual(TwinPeaksParkId, campgrounds[0].Park_Id);
            Assert.AreEqual("Black Lodge", campgrounds[0].Name);
            Assert.AreEqual(01, campgrounds[0].Open_From);
            Assert.AreEqual(09, campgrounds[0].Open_To);
            Assert.AreEqual(420.00M, campgrounds[0].Daily_fee);


            //cmdText = $"INSERT INTO campground VALUES ({TwinPeaksParkId}, 'Black Lodge', 01, 09, 420.00);SELECT SCOPE_IDENTITY();";


        }

    }
}
