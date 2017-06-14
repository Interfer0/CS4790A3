using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class SiteList
    {
        private static List<Site> sites = new List<Site>();
        public static IEnumerable<Site> Sites { get { return sites; } }
        public static void AddResponse(Site site) { sites.Add(site); }
    }
}
