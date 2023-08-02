
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AllRightConsultant.Data;
using AllRightConsultant.Models;
using static System.Collections.Specialized.BitVector32;

namespace AllRightConsultant.Controllers
{
    public class WorkLabourCessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkLabourCessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkLabourCesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkLabourCesss.Include(w => w.ProjectWork);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkLabourCesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkLabourCesss == null)
            {
                return NotFound();
            }

            var workLabourCess = await _context.WorkLabourCesss
                .Include(w => w.ProjectWork)
                .FirstOrDefaultAsync(m => m.MajorworkID == id);
            if (workLabourCess == null)
            {
                return NotFound();
            }

            return View(workLabourCess);
        }

        // GET: WorkLabourCesses/Create
        public IActionResult Create()
        {
            ViewData["WorkId"] = new SelectList(_context.ProjectWorks, "WorkId", "ProjectSiteAddress");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkLabourCess workLabourCess)
        {
            if (ModelState.IsValid)
            {
                // Calculate 1% Labor Cess for the given major work before saving the record
                workLabourCess.Per1LabourCess = workLabourCess.ConstructionCost * 0.01m; // Convert 0.01 to decimal

                _context.Add(workLabourCess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["WorkId"] = new SelectList(_context.ProjectWorks, "WorkId", "ProjectSiteAddress", workLabourCess.WorkId);
            return View(workLabourCess);
        }

        // GET: WorkLabourCesses/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workLabourCess = await _context.WorkLabourCesss.FindAsync(id);
            if (workLabourCess == null)
            {
                return NotFound();
            }

            ViewData["WorkId"] = new SelectList(_context.ProjectWorks, "WorkId", "ProjectSiteAddress", workLabourCess.WorkId);
            return View(workLabourCess);
        }

        // POST: WorkLabourCesses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MajorworkID,WorkId,Financialyear,PerConstruction,ConstructionCost")] WorkLabourCess workLabourCess)
        {
            if (id != workLabourCess.MajorworkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Calculate 1% Labor Cess before saving the updated record
                workLabourCess.Per1LabourCess = workLabourCess.ConstructionCost * 0.01m; // Convert 0.01 to decimal

                try
                {
                    _context.Update(workLabourCess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkLabourCessExists(workLabourCess.MajorworkID))
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
            ViewData["WorkId"] = new SelectList(_context.ProjectWorks, "WorkId", "ProjectSiteAddress", workLabourCess.WorkId);
            return View(workLabourCess);
        }

        // GET: WorkLabourCesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkLabourCesss == null)
            {
                return NotFound();
            }

            var workLabourCess = await _context.WorkLabourCesss
                .Include(w => w.ProjectWork)
                .FirstOrDefaultAsync(m => m.MajorworkID == id);
            if (workLabourCess == null)
            {
                return NotFound();
            }

            return View(workLabourCess);
        }

        // POST: WorkLabourCesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkLabourCesss == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WorkLabourCesss'  is null.");
            }
            var workLabourCess = await _context.WorkLabourCesss.FindAsync(id);
            if (workLabourCess != null)
            {
                _context.WorkLabourCesss.Remove(workLabourCess);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkLabourCessExists(int id)
        {
            return (_context.WorkLabourCesss?.Any(e => e.MajorworkID == id)).GetValueOrDefault();
        }
    }
}