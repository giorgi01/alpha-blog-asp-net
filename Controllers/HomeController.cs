﻿using Alpha_blog.Models;
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
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)return View(new Post());
            
            var post = _repo.GetPost((int)id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if(await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            return View(post);
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            return View(_repo.GetPost(id));
        }
    }
}
