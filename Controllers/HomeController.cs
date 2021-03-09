using Alpha_blog.Models;
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
        public IActionResult Edit(Post post)
        {
            return RedirectToAction("Index");
        }
    }
}
