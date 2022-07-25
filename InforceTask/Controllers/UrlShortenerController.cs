using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InforceTask.Models;
using InforceTask.Helper;
using InforceTask.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using InforceTask.Services;

namespace InforceTask.Controllers
{
    public class UrlShortenerController : Controller
    {
        private readonly MainDbContext _context;
        private readonly IHttpContextAccessorService _httpContextAccessor;

        public UrlShortenerController(MainDbContext context, IHttpContextAccessorService httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: UrlShortener
        public async Task<IActionResult> Index()
        {
            return View(await _context.Urls.ToListAsync());
        }

        // GET: UrlShortener/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortUrl = await _context.Urls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return View(shortUrl);
        }

        // GET: UrlShortener/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UrlShortener/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginalUrl,ShortedUrl,CreatedAt,CreatedBy")] ShortUrl shortUrl)
        {
            if (ModelState.IsValid)
            {
                var urlCode = shortUrl.Code = UrlShortenerHelper.Generate();

                shortUrl.ShortedUrl = "http://localhost:49477/" + urlCode;

                shortUrl.CreatedAt = DateTimeOffset.UtcNow.ToString();

                shortUrl.CreatedBy = _httpContextAccessor.GetUser();


                _context.Add(shortUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shortUrl);
        }

        [HttpGet]
        [Route("/UrlShortener/RedirectTo/{id}")]
        public IActionResult RedirectTo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _context.Urls.Find(id);

            if (url == null)
            {
                return NotFound();
            }
            return Redirect(url.OriginalUrl);
        }

        // GET: UrlShortener/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortUrl = await _context.Urls.FindAsync(id);
            if (shortUrl == null)
            {
                return NotFound();
            }
            return View(shortUrl);
        }

        // POST: UrlShortener/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OriginalUrl,ShortedUrl,Code")] ShortUrl shortUrl)
        {
            if (id != shortUrl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shortUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShortUrlExists(shortUrl.Id))
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
            return View(shortUrl);
        }

        // GET: UrlShortener/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortUrl = await _context.Urls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return View(shortUrl);
        }

        // POST: UrlShortener/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shortUrl = await _context.Urls.FindAsync(id);
            _context.Urls.Remove(shortUrl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShortUrlExists(int id)
        {
            return _context.Urls.Any(e => e.Id == id);
        }
    }
}
