using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AllRightConsultant.Data;
using AllRightConsultant.Models;

namespace AllRightConsultant.Controllers
{
    public class ProjectTypeNaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTypeNaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectTypeNatures
        public async Task<IActionResult> Index()
        {
              return _context.ProjectTypeNatures != null ? 
                          View(await _context.ProjectTypeNatures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProjectTypeNatures'  is null.");
        }

        // GET: ProjectTypeNatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectTypeNatures == null)
            {
                return NotFound();
            }

            var projectTypeNature = await _context.ProjectTypeNatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTypeNature == null)
            {
                return NotFound();
            }

            return View(projectTypeNature);
        }

        // GET: ProjectTypeNatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectTypeNatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectTypeNatureName")] ProjectTypeNature projectTypeNature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectTypeNature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectTypeNature);
        }

        // GET: ProjectTypeNatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectTypeNatures == null)
            {
                return NotFound();
            }

            var projectTypeNature = await _context.ProjectTypeNatures.FindAsync(id);
            if (projectTypeNature == null)
            {
                return NotFound();
            }
            return View(projectTypeNature);
        }

        // POST: ProjectTypeNatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectTypeNatureName")] ProjectTypeNature projectTypeNature)
        {
            if (id != projectTypeNature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectTypeNature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTypeNatureExists(projectTypeNature.Id))
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
            return View(projectTypeNature);
        }

        // GET: ProjectTypeNatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectTypeNatures == null)
            {
                return NotFound();
            }

            var projectTypeNature = await _context.ProjectTypeNatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTypeNature == null)
            {
                return NotFound();
            }

            return View(projectTypeNature);
        }

        // POST: ProjectTypeNatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectTypeNatures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectTypeNatures'  is null.");
            }
            var projectTypeNature = await _context.ProjectTypeNatures.FindAsync(id);
            if (projectTypeNature != null)
            {
                _context.ProjectTypeNatures.Remove(projectTypeNature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTypeNatureExists(int id)
        {
          return (_context.ProjectTypeNatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
