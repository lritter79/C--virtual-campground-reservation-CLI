using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampsiteSqlDAO
    {
        /// <summary>
        /// Returns a list of campsites from the DB
        /// </summary>
        /// <returns></returns>
        IList<Campsite> GetCampsites();

        /// <summary>
        /// returns a list of the campsites in a specific campground
        /// </summary>
        /// <param name="campground_id"></param>
        /// <returns></returns>
        IList<Campsite> GetCampSitesByCampgrounds(int campground_id);

        IList<Campsite> GetSiteAndReservationDate(int site_id, DateTime start, DateTime end);
        

        

    }
}
