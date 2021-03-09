using Alpha_blog.Models;
using Alpha_blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha_blog.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;
        
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
