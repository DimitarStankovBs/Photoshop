using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Photoshop.Data;
using Photoshop.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Photoshop.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Photos.Include(b => b.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Photo = await _context.Photos
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Photo == null)
            {
                return NotFound();
            }

            return View(Photo);
        }

        // GET: Photos/Create - when send data to view
        [Authorize]
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title");
            return View();
        }

        // POST: Photos/Create - when receive data fron view
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize()]
        public async Task<IActionResult> Create([Bind("Title,ImageUrl,GenreId,Id,Price")] Photo Photo)
        {
            if (ModelState.IsValid)
            {
                Photo.Id = Guid.NewGuid();
                _context.Add(Photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

       
        // GET: Photos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Photo = await _context.Photos.FindAsync(id);
            if (Photo == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

        // POST: Photos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,ImageUrl,GenreId,Id, Price")] Photo Photo)
        {
            if (id != Photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(Photo.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

        // GET: Photos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Photo = await _context.Photos
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Photo == null)
            {
                return NotFound();
            }

            return View(Photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Photo = await _context.Photos.FindAsync(id);
            _context.Photos.Remove(Photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(Guid id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }

        // GET: Photos/Buy
        [Authorize]
        public async Task<IActionResult> Buy(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Photo = await _context.Photos.FindAsync(id);
            if (Photo == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

        // POST: Photos/Buy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(Guid id, [Bind("Title,ImageUrl,GenreId,Id, Price, BuyerName, BuyerAddress, BuyerPhone, PurchseDate")] Photo Photo)
        {
            if (id != Photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(Photo.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Title", Photo.GenreId);
            return View(Photo);
        }

    }
}
