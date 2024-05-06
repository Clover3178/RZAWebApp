using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RZAWebApp.Data;
using RZAWebApp.Models;

namespace RZAWebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var articles = from article in _context.Articles
                           select article;

            if(!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(article => article.Tags.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    articles = articles.OrderBy(article => article.CreationDate);
                    break;

                case "date_desc":
                    articles = articles.OrderByDescending(article => article.CreationDate);
                    break;

                default:
                    articles = articles.OrderByDescending(article => article.CreationDate);
                    break;
            }
            return View(await articles.AsNoTracking().ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // GET: Articles/Create
        [Authorize(Roles = "Admin,Writer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Writer")]
        public async Task<IActionResult> Create([Bind("ArticleID,ArticleTitle,ArticleContent,WrittenBy,CreationDate,ImageID,Tags,TotalViews")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articles);
        }

        // GET: Articles/Edit/5
        [Authorize(Roles = "Admin,Writer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Writer")]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleID,ArticleTitle,ArticleContent,WrittenBy,CreationDate,ImageID,Tags,TotalViews")] Articles articles)
        {
            if (id != articles.ArticleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(articles.ArticleID))
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
            return View(articles);
        }

        // GET: Articles/Delete/5
        [Authorize(Roles = "Admin,Writer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .FirstOrDefaultAsync(m => m.ArticleID == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Writer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articles = await _context.Articles.FindAsync(id);
            if (articles != null)
            {
                _context.Articles.Remove(articles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }
    }
}
