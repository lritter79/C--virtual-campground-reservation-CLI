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

        public void GetParksTest()
        {
            //Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            //Act
            IList<Park> parks = dao.GetParks();
            //Assert
            Assert.IsTrue(parks.Count == 2);

        }

    }
}
