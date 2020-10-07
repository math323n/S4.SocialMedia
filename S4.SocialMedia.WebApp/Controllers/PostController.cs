using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S4.SocialMedia.DataAccess;
using S4.SocialMedia.Entities.Models;
using S4.SocialMedia.Entities.Models.Context;

namespace S4.SocialMedia.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly PostRepository repo;

        public PostController(PostRepository postRepository)
        {
            repo = postRepository;
        }

        // GET: AspNetPosts
        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> socialMediaContext = await repo.GetAllAsync();
            return View(socialMediaContext);
        }

        // GET: AspNetPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Post post = await repo.GetByIdAsync(id);

            if(post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: AspNetPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkPostId,FkUserId,Title,Image,Description,CreateDate,UpdateDate,IsEdited")] Post post)
        {
            if(ModelState.IsValid)
            {
                post.CreateDate = DateTime.Now;
                post.FkUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await repo.AddAsync(post);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: AspNetPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Post post = await repo.GetByIdAsync(id);

            if(post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: AspNetPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkPostId,FkUserId,Title,Image,Description,CreateDate,UpdateDate,IsEdited")] Post post)
        {
            if(id != post.PkPostId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    Post originalPost = await repo.GetByIdAsync(id);

                    originalPost.IsEdited = true;
                    originalPost.CreateDate = DateTime.Now;

                    originalPost.Title = post.Title;
                    originalPost.Description = post.Description;
                    originalPost.Image = post.Image;

                    await repo.UpdateAsync(originalPost);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!await PostExists(post.PkPostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: AspNetPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Post posts = await repo.GetByIdAsync(id);

            if(posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: AspNetPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Post post = await repo.GetByIdAsync(id);

            await repo.DeleteAsync(post);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PostExists(int id)
        {
            return await repo.Exists(id);
        }
    }
}
