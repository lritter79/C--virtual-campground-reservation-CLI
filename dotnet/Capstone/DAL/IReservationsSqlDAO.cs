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
        /// returns a list of the reservations for a specific campsite
        /// </summary>
        /// <param name="site_id"></param>
        /// <returns></returns>
        IList<Reservation> GetReservationsBySiteAndDate(int site_id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int BookReservation(Reservation reservation);




    }
}
