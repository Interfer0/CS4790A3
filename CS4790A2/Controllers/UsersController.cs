using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4790A3.Data;
using CS4790A3.Models;

namespace CS4790A3.Controllers
{
    public class UsersController : Controller
    {
        private readonly SiteContext _context;

        public UsersController(SiteContext context)
        {
            _context = context;
        }




        // GET: Users/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserID,userName,userEmail")] User user)
        {

            if (ModelState.IsValid)
            {              
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Sites","Home");
            }

            return View();
        }

    }
}
