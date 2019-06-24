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

        /// <summary>
        /// returns a list of available campsites filtered by dates and other requested parameters
        /// </summary>
        /// <param name="site_id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="addedParameters"></param>
        /// <returns></returns>
        IList<Campsite> GetAvailableSitesFilteredByDate(int site_id, DateTime start, DateTime end, string addedParameters);

        /// <summary>
        /// returns campsites within a park
        /// </summary>
        /// <param name="park_id"></param>
        /// <returns></returns>
        IList<Campsite> GetAvailabeSitesByParkWithoutDate(int park_id);

        /// <summary>
        /// returns sites available in a park filtered by date
        /// </summary>
        /// <param name="park_id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        IList<Campsite> GetAvailabeSitesByPark(int park_id, DateTime start, DateTime end);
    }
}
