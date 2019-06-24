using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationSqlDAO
    {
        /// <summary>
        /// returns a list of reservations from the DB
        /// </summary>
        IList<Reservation> GetReservations();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int BookReservation(Reservation reservation);

        /// <summary>
        /// Returns a list of the reservations in a specific park for the next 30 days
        /// </summary>
        /// <param name="park_id"></param>
        /// <returns></returns>
        IList<Reservation> GetReservationsNext30ByPark(int park_id);
    }
}
