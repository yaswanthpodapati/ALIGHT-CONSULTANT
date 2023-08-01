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
    public class TalukasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TalukasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Talukas
        public async Task<IActionResult> Index()
        {
              return _context.Talukas != null ? 
                          View(await _context.Talukas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Talukas'  is null.");
        }

        // GET: Talukas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Talukas == null)
            {
                return NotFound();
            }

            var taluka = await _context.Talukas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taluka == null)
            {
                return NotFound();
            }

            return View(taluka);
        }

        // GET: Talukas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Talukas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TalukaName")] Taluka taluka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taluka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taluka);
        }

        // GET: Talukas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Talukas == null)
            {
                return NotFound();
            }

            var taluka = await _context.Talukas.FindAsync(id);
            if (taluka == null)
            {
                return NotFound();
            }
            return View(taluka);
        }

        // POST: Talukas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TalukaName")] Taluka taluka)
        {
            if (id != taluka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taluka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalukaExists(taluka.Id))
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
            return View(taluka);
        }

        // GET: Talukas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Talukas == null)
            {
                return NotFound();
            }

            var taluka = await _context.Talukas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taluka == null)
            {
                return NotFound();
            }

            return View(taluka);
        }

        // POST: Talukas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Talukas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Talukas'  is null.");
            }
            var taluka = await _context.Talukas.FindAsync(id);
            if (taluka != null)
            {
                _context.Talukas.Remove(taluka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalukaExists(int id)
        {
          return (_context.Talukas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
