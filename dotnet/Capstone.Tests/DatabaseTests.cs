using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        protected string ConnectionString = "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;";
        private TransactionScope transaction;
        protected int ParkId { get; set; }
        protected int BlackLodgeCampgroundId { get; set; }
        protected int WhiteLodgeCampgroundId { get; set; }
        protected int BlackLodgeCampsiteId { get; set; }
        protected int WhiteLodgeCampsiteId { get; set; }
        protected int BlackLodgeReservation { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            // limits the scope of tranaction so that the app could be used and tested simultaneously?
            transaction = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //Delete everything from our tables
                string cmdText = "delete from reservation; delete from site; delete from campground;delete from park; ";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();

                //Add row to park table
                cmdText = $"INSERT INTO park VALUES('Twin Peaks', 'Washington', '1990-02-26', 2112, 119,'Twin Peaks is an American mystery horror drama television series created by Mark Frost and David Lynch that premiered on April 8, 1990.'); SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                ParkId = Convert.ToInt32(command.ExecuteScalar());

                // Add campgrounds to park
                cmdText = $"INSERT INTO campground VALUES ({ParkId}, 'Black Lodge', 01, 09, 420.00);SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                BlackLodgeCampgroundId = Convert.ToInt32(command.ExecuteScalar());

                cmdText = $"INSERT INTO campground VALUES ({ParkId}, 'White Lodge', 01, 12, 240.00);SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                WhiteLodgeCampgroundId = Convert.ToInt32(command.ExecuteScalar());

                //Add sites to campgrounds
                cmdText = $"INSERT INTO site VALUES ({BlackLodgeCampgroundId}, 9, 100, 1, 0, 1);SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                BlackLodgeCampsiteId = Convert.ToInt32(command.ExecuteScalar());

                cmdText = $"INSERT INTO site VALUES ({WhiteLodgeCampgroundId}, 9, 10, 1, 1, 0);SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                WhiteLodgeCampsiteId = Convert.ToInt32(command.ExecuteScalar());

                //Add resevation to black lodge campsite
                cmdText = $"INSERT INTO site VALUES ({BlackLodgeCampgroundId}, 9, 100, 1, 0, 1);SELECT SCOPE_IDENTITY();";
                command = new SqlCommand(cmdText, connection);
                BlackLodgeReservation = Convert.ToInt32(command.ExecuteScalar());

            }
        }

        //[TestMethod]
        //public void GetData()
        //{
        //    transaction = new TransactionScope();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        int DepartmentIdCount = -1;
        //        int EmployeeIdCount = -1;
        //        int ProjectIdCount = -1;
        //        int Project_EmployeeIdCount = -1;

        //        string cmdText = "SELECT COUNT(name) FROM department";
        //        SqlCommand command = new SqlCommand(cmdText, connection);
        //        DepartmentIdCount = Convert.ToInt32(command.ExecuteScalar());

        //        cmdText = "SELECT COUNT(employee_id) FROM employee";
        //        command = new SqlCommand(cmdText, connection);
        //        EmployeeIdCount = Convert.ToInt32(command.ExecuteScalar());

        //        cmdText = "SELECT COUNT(project_id) FROM project";
        //        command = new SqlCommand(cmdText, connection);
        //        ProjectIdCount = Convert.ToInt32(command.ExecuteScalar());

        //        cmdText = "SELECT COUNT(project_id) FROM project_employee";
        //        command = new SqlCommand(cmdText, connection);
        //        Project_EmployeeIdCount = Convert.ToInt32(command.ExecuteScalar());

        //        Assert.AreEqual($"{DepartmentIdCount}{EmployeeIdCount}{ProjectIdCount}{Project_EmployeeIdCount}", "1211");
        //    }
        //}

       [TestCleanup]
       public void CleanUp()
       {
            // Roll back the transaction
            transaction.Dispose();
       }
    }
}
