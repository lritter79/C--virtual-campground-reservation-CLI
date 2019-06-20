using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampgroundSqlDAO
    {
        //returns a list of the Campgrounds from the DB
        IList<Campground> GetCampgrounds();
    }
}
