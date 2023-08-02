
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
    public class ProjectWorksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectWorksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectWorks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectWorks.Include(p => p.City).Include(p => p.District).Include(p => p.ProjectTypeNature).Include(p => p.Taluka).Include(p => p.Village);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectWorks == null)
            {
                return NotFound();
            }

            var projectWork = await _context.ProjectWorks
                .Include(p => p.City)
                .Include(p => p.District)
                .Include(p => p.ProjectTypeNature)
                .Include(p => p.Taluka)
                .Include(p => p.Village)
                .FirstOrDefaultAsync(m => m.WorkId == id);
            if (projectWork == null)
            {
                return NotFound();
            }

            return View(projectWork);
        }

        // GET: ProjectWorks/Create
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.Cities, "Id", "Id");
            ViewData["DistrictID"] = new SelectList(_context.Districts, "Id", "Id");
            ViewData["ProjectTypeNatureID"] = new SelectList(_context.ProjectTypeNatures, "Id", "Id");
            ViewData["Taluka_ID"] = new SelectList(_context.Talukas, "Id", "Id");
            ViewData["Village_ID"] = new SelectList(_context.Villages, "Id", "Id");
            return View();
        }

        // POST: ProjectWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkId,WorkName,ProjectTypeNatureID,ProjectSiteAddress,StreetName,DistrictID,Taluka_ID,CityID,Village_ID,SanctionDate,Total_Estimated_Cost")] ProjectWork projectWork)
        {
            if (ModelState.IsValid)
            {
                // Generate the unique code
                projectWork.WorkUniqueCode = GenerateUniqueCode();

                _context.Add(projectWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Populate the necessary dropdown lists
            ViewData["CityID"] = new SelectList(_context.Cities, "Id", "Id", projectWork.CityID);
            ViewData["DistrictID"] = new SelectList(_context.Districts, "Id", "Id", projectWork.DistrictID);
            ViewData["ProjectTypeNatureID"] = new SelectList(_context.ProjectTypeNatures, "Id", "Id", projectWork.ProjectTypeNatureID);
            ViewData["Taluka_ID"] = new SelectList(_context.Talukas, "Id", "Id", projectWork.Taluka_ID);
            ViewData["Village_ID"] = new SelectList(_context.Villages, "Id", "Id", projectWork.Village_ID);

            return View(projectWork);
        }
        // Helper method to generate a unique code
        private string GenerateUniqueCode()
        {
            // You can implement your own logic here to generate a unique code.
            // For example, you can use a combination of a prefix and a random number.
            // Here's a simple example using a random number:
            var random = new Random();
            var uniqueCode = "ABC" + random.Next(1000, 9999).ToString();
            return uniqueCode;
        }

        // GET: ProjectWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectWorks == null)
            {
                return NotFound();
            }

            var projectWork = await _context.ProjectWorks.FindAsync(id);
            if (projectWork == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "Id", "Id", projectWork.CityID);
            ViewData["DistrictID"] = new SelectList(_context.Districts, "Id", "Id", projectWork.DistrictID);
            ViewData["ProjectTypeNatureID"] = new SelectList(_context.ProjectTypeNatures, "Id", "Id", projectWork.ProjectTypeNatureID);
            ViewData["Taluka_ID"] = new SelectList(_context.Talukas, "Id", "Id", projectWork.Taluka_ID);
            ViewData["Village_ID"] = new SelectList(_context.Villages, "Id", "Id", projectWork.Village_ID);
            return View(projectWork);
        }

        // POST: ProjectWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkId,WorkName,WorkUniqueCode,ProjectTypeNatureID,ProjectSiteAddress,StreetName,DistrictID,Taluka_ID,CityID,Village_ID,SanctionDate,Total_Estimated_Cost")] ProjectWork projectWork)
        {
            if (id != projectWork.WorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectWorkExists(projectWork.WorkId))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "Id", "Id", projectWork.CityID);
            ViewData["DistrictID"] = new SelectList(_context.Districts, "Id", "Id", projectWork.DistrictID);
            ViewData["ProjectTypeNatureID"] = new SelectList(_context.ProjectTypeNatures, "Id", "Id", projectWork.ProjectTypeNatureID);
            ViewData["Taluka_ID"] = new SelectList(_context.Talukas, "Id", "Id", projectWork.Taluka_ID);
            ViewData["Village_ID"] = new SelectList(_context.Villages, "Id", "Id", projectWork.Village_ID);
            return View(projectWork);
        }

        // GET: ProjectWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectWorks == null)
            {
                return NotFound();
            }

            var projectWork = await _context.ProjectWorks
                .Include(p => p.City)
                .Include(p => p.District)
                .Include(p => p.ProjectTypeNature)
                .Include(p => p.Taluka)
                .Include(p => p.Village)
                .FirstOrDefaultAsync(m => m.WorkId == id);
            if (projectWork == null)
            {
                return NotFound();
            }

            return View(projectWork);
        }

        // POST: ProjectWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectWorks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectWorks'  is null.");
            }
            var projectWork = await _context.ProjectWorks.FindAsync(id);
            if (projectWork != null)
            {
                _context.ProjectWorks.Remove(projectWork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectWorkExists(int id)
        {
            return (_context.ProjectWorks?.Any(e => e.WorkId == id)).GetValueOrDefault();
        }
    }
}