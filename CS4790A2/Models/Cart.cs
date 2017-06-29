using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class Cart
    {
        public int CartID { get; set; }

        public List<int> sites = new List<int>();

        public List<int> getSites()
        {
            return sites;
        }

        public void setSites(List<int> list)
        {
            sites = list;
        }

       

    }

}
