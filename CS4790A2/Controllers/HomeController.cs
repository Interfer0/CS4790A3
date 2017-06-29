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
using Microsoft.AspNetCore.Http;
using CS4790A3.Services;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using ImageMagick;

namespace CS4790A3
    .Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteContext _context;
        private IHostingEnvironment _env;
     

        public HomeController(SiteContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
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
            ViewData["LandTypeParm"] = String.IsNullOrEmpty(sortOrder) ? "land_type" : "";
            ViewData["SubmittedParm"] = String.IsNullOrEmpty(sortOrder) ? "submitted_by" : "";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }

            else
            {
                searchString = CurrentFilter;
            }

            var sites = _context.Sites.Where(s => 
            (s.siteAvailable == true || s.siteAvailable.Equals(null)) 
            || HttpContext.Session.GetInt32("UserLevel") == 100);
                /*from s in _context.Sites
                           select s;*/

            if (!String.IsNullOrEmpty(searchString))
            {
                sites = sites.Where(
                    s => s.siteName.Contains(searchString) && 
                ((s.siteAvailable == true || s.siteAvailable.Equals(null)) || HttpContext.Session.GetInt32("UserLevel") == 100)
                );              
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sites = sites.OrderByDescending(s => s.siteName);
                    break;
                case "land_type":
                    sites = sites.OrderBy(s => s.siteLandType);
                    break;
                default:
                    sites = sites.OrderBy(s => s.siteName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Site>.CreateAsync(sites
                .AsNoTracking(),
                page ?? 1, pageSize));


        }

        [HttpGet]
        public ViewResult SiteForm()
        {
            if (!UserService.checkSecurityLevel(HttpContext.Session.GetInt32("UserLevel"), 100))
                return View("../Account/Login");

            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");

                return View();
            
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SiteForm([Bind("SiteID,UserID,siteName,siteDescription,siteLandType,siteUses,siteWater,siteGas,siteOffroad,siteLong,siteLat,siteLevel")] Site site)
        {
            
            
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        
                        var file = Image;
                        
                        var uploads = Path.Combine(_env.WebRootPath, "images\\sites");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');

                            System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                using (var image = new MagickImage(Path.Combine(uploads, file.FileName)))
                                {
                                    image.Resize(100, 0);
                                    image.Strip();
                                    image.Quality = 90;

                                    image.Write(Path.Combine(uploads, "thumb" + file.FileName));

                                }
                                site.imglocation = file.FileName;
                                site.imgthumblocation = "thumb" + file.FileName;
                            }


                        }
                    }
                }

                _context.Add(site);
                await _context.SaveChangesAsync();
                var site2 = await _context.Sites
                    .SingleOrDefaultAsync(m => m.SiteID == site.SiteID);
                return View("SiteView",site2);
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");
            return View();
        }

        public async Task<ViewResult> SiteView(int id)
        {
            Debug.WriteLine("siteID " + id);

            var site = await _context.Sites
                .SingleOrDefaultAsync(m => m.SiteID == id);
 

            Debug.WriteLine("siteID " + site.SiteID);
            return View("SiteView", site);
        }

        public async Task<ViewResult> SiteEdit(int id)
        {
            if(!UserService.checkSecurityLevel(HttpContext.Session.GetInt32("UserLevel"), 100))
                return View("../Account/Login");
            
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");
            var site = await _context.Sites
                .SingleOrDefaultAsync(m => m.SiteID == id);

            return View("SiteEdit", site);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SiteEdit(int id, [Bind("SiteID," +
            "siteName," +
            "siteDescription," +
            "siteLandType," +
            "siteUses," +
            "siteWater," +
            "siteGas," +
            "siteOffroad," +
            "siteLong," +
            "siteLat," +
            "siteLevel," +
            "siteCost," +
            "imglocation, " +
            "siteAvailable, " +
            "UserID")] Site site)
        {
            if (id != site.SiteID)
                return NotFound();
            if (!UserService.checkSecurityLevel(HttpContext.Session.GetInt32("UserLevel"), 100))
                return View("../Account/Login");


            if (ModelState.IsValid)
            {
                try
                {
                    var test = Request.Form;
                    var files = HttpContext.Request.Form.Files;
                    foreach (var Image in files)
                    {
                        
                        if (Image != null && Image.Length > 0)
                        {

                            var file = Image;
                            var uploads = Path.Combine(_env.WebRootPath, "images\\sites");

                            if (file.Length > 0)
                            {
                                var fileName = ContentDispositionHeaderValue.Parse
                                    (file.ContentDisposition).FileName.Trim('"');

                                System.Console.WriteLine(fileName);
                                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    using (var image = new MagickImage(Path.Combine(uploads, file.FileName)))
                                    {                                                                               
                                        image.Resize(100, 0);                                        
                                        image.Strip();
                                        image.Quality = 90;
                                        
                                        image.Write(Path.Combine(uploads, "thumb" + file.FileName));

                                    }
                                    site.imglocation = file.FileName;
                                    site.imgthumblocation = "thumb" + file.FileName;
                                }


                            }
                        }
                    }


                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "userName");
            return View("SiteView",site);
        }
        

        private bool SiteExists(int siteID)
        {
            return _context.Sites.Any(e => e.SiteID == siteID);
        }

        public IActionResult Error()
        {
            return View();
        }

        
    }
}
