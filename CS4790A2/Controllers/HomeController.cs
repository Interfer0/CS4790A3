using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS4790A3.Models;
using CS4790A3.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CS4790A3
    .Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteContext _context;

        public HomeController(SiteContext context)
        {
            _context = context;
        }

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

        public async Task<IActionResult> Sites(string sortOrder, string searchString, string CurrentFilter, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }

            else
            {
                searchString = CurrentFilter;
            }

            var sites = from s in _context.Sites
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sites = sites.Where(s => s.siteName.Contains(searchString));              
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sites = sites.OrderByDescending(s => s.siteName);
                    break;
                case "land_type":
                    sites = sites.OrderBy(s => s.siteLandType);
                    break;
                case "submitted_by":
                    sites = sites.OrderByDescending(s => s.User.userName);
                    break;
                default:
                    sites = sites.OrderBy(s => s.siteName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Site>.CreateAsync(sites
                .Include(c => c.User)
                .AsNoTracking(),
                page ?? 1, pageSize));


        }

        [HttpGet]
        public ViewResult SiteForm()
        {


            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");

                return View();
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SiteForm([Bind("SiteID,UserID,siteName,siteDescription,siteLandType,siteUses,siteWater,siteGas,siteOffroad,siteLong,siteLat,siteLevel")] Site site)
        {
            
            
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return View("SiteView",site);
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");
            return View();
        }

        public async Task<ViewResult> SiteView(int id)
        {
            Debug.WriteLine("siteID " + id);

            var site = await _context.Sites
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.SiteID == id);
 

            Debug.WriteLine("siteID " + site.SiteID);
            return View("SiteView", site);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
