using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IParkSqlDAO
    {
        //get a list of Parks from the DB 
        IList<Park> GetParks();



        
    }
}
