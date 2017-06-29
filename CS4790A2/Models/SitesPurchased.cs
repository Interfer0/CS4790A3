using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class SitesPurchased
    {

        public  int SitesPurchasedID { get; set; }

        public int UserID { get; set; }

        public int SiteID { get; set; }

        public User user { get; set; }
        public Site site { get; set; }
       
    }
}
