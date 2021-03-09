using Alpha_blog.Models;
using Alpha_blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Alpha_blog.Data.Repository;

namespace Alpha_blog.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository _repo;
        
        public HomeController(IRepository repo)
        {
            _repo = repo;
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
            _repo.AddPost(post);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
