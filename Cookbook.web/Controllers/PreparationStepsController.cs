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
    public class PreparationStepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreparationStepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PreparationSteps
        public async Task<IActionResult> Index()
        {
              return _context.PreparationSteps != null ? 
                          View(await _context.PreparationSteps.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PreparationSteps'  is null.");
        }

        // GET: PreparationSteps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PreparationSteps == null)
            {
                return NotFound();
            }

            var preparationStep = await _context.PreparationSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preparationStep == null)
            {
                return NotFound();
            }

            return View(preparationStep);
        }

        // GET: PreparationSteps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PreparationSteps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Description,CreatedBy,ModifiedBy,Id,CreatedOn,ModifiedOn")] PreparationStep preparationStep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preparationStep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preparationStep);
        }

        // GET: PreparationSteps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PreparationSteps == null)
            {
                return NotFound();
            }

            var preparationStep = await _context.PreparationSteps.FindAsync(id);
            if (preparationStep == null)
            {
                return NotFound();
            }
            return View(preparationStep);
        }

        // POST: PreparationSteps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Number,Description,CreatedBy,ModifiedBy,Id,CreatedOn,ModifiedOn")] PreparationStep preparationStep)
        {
            if (id != preparationStep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preparationStep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreparationStepExists(preparationStep.Id))
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
            return View(preparationStep);
        }

        // GET: PreparationSteps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PreparationSteps == null)
            {
                return NotFound();
            }

            var preparationStep = await _context.PreparationSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preparationStep == null)
            {
                return NotFound();
            }

            return View(preparationStep);
        }

        // POST: PreparationSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PreparationSteps == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PreparationSteps'  is null.");
            }
            var preparationStep = await _context.PreparationSteps.FindAsync(id);
            if (preparationStep != null)
            {
                _context.PreparationSteps.Remove(preparationStep);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreparationStepExists(string id)
        {
          return (_context.PreparationSteps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
