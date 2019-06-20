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
    public class ReservationCLITests: DatabaseTests
    {
        [TestMethod]
        public void MakeReservationsTest()
        {
            //Assert MakeReservations Works
        }


        public void Does_Not_Show_Sites_With_Conflicting_Reservations()
        {


        }

    }
}
