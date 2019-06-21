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


        //IList<Reservation> GetReservationsByName(string reservationName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int BookReservation(Reservation reservation);




    }
}
