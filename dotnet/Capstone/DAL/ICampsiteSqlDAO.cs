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

        IList<Campsite> GetAvailableSitesFilteredByDate(int site_id, DateTime start, DateTime end);

        /// <summary>
        /// returns campsites within a park
        /// </summary>
        /// <param name="park_id"></param>
        /// <returns></returns>
        IList<Campsite> GetAvailabeSitesByParkWithoutDate(int park_id);

        IList<Campsite> GetAvailabeSitesByPark(int park_id, DateTime start, DateTime end);

        




    }
}
