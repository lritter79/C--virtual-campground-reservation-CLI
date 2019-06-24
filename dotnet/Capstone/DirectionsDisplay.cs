using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Capstone
{
    public static class DirectionsDisplay
    {
        /// <summary>
        /// Takes in a camp ID and opens a web browser with directions to that Campground from 
        /// the users location based on IP address per google maps default
        /// </summary>
        /// <param name="camp_id"></param>
        public static void OpenBrowser(int camp_id)
        {
            string[] maps = new string[]
            {
                "https://cutt.ly/DdnOUX",
                "https://cutt.ly/tdb3pu",
                "https://cutt.ly/PdnZkl",
                "https://cutt.ly/idmAfM",
                "https://cutt.ly/idmAfM",
                "https://cutt.ly/idmAfM",
                "https://cutt.ly/NdQ8Lq"
            };
            System.Diagnostics.Process.Start("cmd.exe", $"/C start {maps[camp_id]}");
        }
    }
}
