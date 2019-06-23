using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkTests: DatabaseTests
    {
        [TestMethod]
        public void ConstructsParksProperly()
        {
            //assign
            ParkSqlDAO parkSqlDAO = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = parkSqlDAO.GetParks();

            string description = "Watch out for bears stealing picinic baskets.";

            //assert
            Assert.AreEqual("Jellystone", parks[0].Name);
            Assert.AreEqual("Wyoming", parks[0].Location);
            Assert.AreEqual("2/26/1990", parks[0].Establish_date.ToShortDateString());
            Assert.AreEqual("2112", parks[0].Area);
            Assert.AreEqual(119, parks[0].Visitors);
            Assert.AreEqual(description, parks[0].Description);
        }
    }
}
