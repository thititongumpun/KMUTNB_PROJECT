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
    public class TblLogsController : Controller
    {
        private readonly DataContext _context;

        public TblLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblLogs
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblLog.Include(t => t.Mapmenu);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLog
                .Include(t => t.Mapmenu)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (tblLog == null)
            {
                return NotFound();
            }

            return View(tblLog);
        }

        // GET: TblLogs/Create
        public IActionResult Create()
        {
            ViewData["MapmenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id");
            return View();
        }

        // POST: TblLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,CreateDate,MapmenuId,Data")] TblLog tblLog)
        {
            if (ModelState.IsValid)
            {
                tblLog.LogId = Guid.NewGuid();
                _context.Add(tblLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MapmenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblLog.MapmenuId);
            return View(tblLog);
        }

        // GET: TblLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLog.FindAsync(id);
            if (tblLog == null)
            {
                return NotFound();
            }
            ViewData["MapmenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblLog.MapmenuId);
            return View(tblLog);
        }

        // POST: TblLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LogId,CreateDate,MapmenuId,Data")] TblLog tblLog)
        {
            if (id != tblLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLogExists(tblLog.LogId))
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
            ViewData["MapmenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblLog.MapmenuId);
            return View(tblLog);
        }

        // GET: TblLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLog
                .Include(t => t.Mapmenu)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (tblLog == null)
            {
                return NotFound();
            }

            return View(tblLog);
        }

        // POST: TblLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblLog = await _context.TblLog.FindAsync(id);
            _context.TblLog.Remove(tblLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblLogExists(Guid id)
        {
            return _context.TblLog.Any(e => e.LogId == id);
        }
    }
}
