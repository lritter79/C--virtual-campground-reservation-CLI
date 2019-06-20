using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampsiteSqlDAO
    {
        //Returns a list of campsites from the DB
        IList<Campsite> GetCampsites();
    }
}
