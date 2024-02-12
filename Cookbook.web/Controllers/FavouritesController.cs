using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.DataAccess;
using Data.DataModels.Entities;

namespace Cookbook.web.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favourites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Favourites.Include(f => f.ApplicationUser).Include(f => f.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Favourites/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites
                .Include(f => f.ApplicationUser)
                .Include(f => f.Recipe)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (favourites == null)
            {
                return NotFound();
            }

            return View(favourites);
        }

        // GET: Favourites/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,RecipeId")] Favourites favourites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favourites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", favourites.ApplicationUserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", favourites.RecipeId);
            return View(favourites);
        }

        // GET: Favourites/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites.FindAsync(id);
            if (favourites == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", favourites.ApplicationUserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", favourites.RecipeId);
            return View(favourites);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicationUserId,RecipeId")] Favourites favourites)
        {
            if (id != favourites.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favourites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouritesExists(favourites.ApplicationUserId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", favourites.ApplicationUserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id", favourites.RecipeId);
            return View(favourites);
        }

        // GET: Favourites/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites
                .Include(f => f.ApplicationUser)
                .Include(f => f.Recipe)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (favourites == null)
            {
                return NotFound();
            }

            return View(favourites);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Favourites == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Favourites'  is null.");
            }
            var favourites = await _context.Favourites.FindAsync(id);
            if (favourites != null)
            {
                _context.Favourites.Remove(favourites);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouritesExists(string id)
        {
          return (_context.Favourites?.Any(e => e.ApplicationUserId == id)).GetValueOrDefault();
        }
    }
}
