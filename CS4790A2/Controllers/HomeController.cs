using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS4790A3.Models;

namespace CS4790A3
    .Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About CrowdCamp";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "CrowdCamp Site Contacts";

            return View();
        }

        public ViewResult Sites()
        {
            return View(SiteList.Sites);
        }

        [HttpGet]
        public ViewResult SiteForm()
        {
            return View();
        }

            
        [HttpPost]
        public ViewResult SiteForm(Site site)
        {
            if(ModelState.IsValid) {
                SiteList.AddResponse(site);
                return View("SiteView", site);
            }else{
                return View();
            }

        }

        public ViewResult SiteView(Site site)
        {
            return View("SiteView", site);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
