using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using CS4790A3.Services;
using CS4790A3.Models;
using Newtonsoft.Json;
using CS4790A3.Data;

namespace CS4790A3.Controllers
{
    public class CartController : Controller
    {
        private readonly SiteContext _context;

        public CartController(SiteContext context)
        {
            _context = context;

        }

        public IActionResult AddItem(int item)
        {

            Cart crt = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("usersCart"));
            //Debug.WriteLine("Items in the cart: " + HttpContext.Session.GetString("usersCart"));
            if (!crt.sites.Contains(item))
                crt.sites.Add(item);
            HttpContext.Session.SetString("usersCart", JsonConvert.SerializeObject(crt));
            //Debug.WriteLine("Items in the cart: " + HttpContext.Session.GetString("usersCart"));
            return Redirect("../Home/Sites");
        }


        public ViewResult Cart()
        {
            Cart crt = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("usersCart"));
            var Sites = _context.Sites.Where(r => crt.sites.Contains(r.SiteID));
            ViewData["Sites"] = Sites.ToList<Site>();
            ViewData["Total"] = Sites.GroupBy(o => o.siteCost);
            
            return View();
        }

    }
}