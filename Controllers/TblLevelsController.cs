using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dded.db.Linkage;

namespace dded.Controllers
{
    public class TblLevelsController : Controller
    {
        private readonly DataContext _context;

        public TblLevelsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblLevel.ToListAsync());
        }

        // GET: TblLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLevel = await _context.TblLevel
                .FirstOrDefaultAsync(m => m.LevelId == id);
            if (tblLevel == null)
            {
                return NotFound();
            }

            return View(tblLevel);
        }

        // GET: TblLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelId,LevelName,ActiveFlag")] TblLevel tblLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLevel);
        }

        // GET: TblLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLevel = await _context.TblLevel.FindAsync(id);
            if (tblLevel == null)
            {
                return NotFound();
            }
            return View(tblLevel);
        }

        // POST: TblLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelId,LevelName,ActiveFlag")] TblLevel tblLevel)
        {
            if (id != tblLevel.LevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLevelExists(tblLevel.LevelId))
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
            return View(tblLevel);
        }

        // GET: TblLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLevel = await _context.TblLevel
                .FirstOrDefaultAsync(m => m.LevelId == id);
            if (tblLevel == null)
            {
                return NotFound();
            }

            return View(tblLevel);
        }

        // POST: TblLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLevel = await _context.TblLevel.FindAsync(id);
            _context.TblLevel.Remove(tblLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblLevelExists(int id)
        {
            return _context.TblLevel.Any(e => e.LevelId == id);
        }
    }
}
