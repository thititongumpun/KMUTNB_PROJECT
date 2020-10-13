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
    public class TblOfficersController : Controller
    {
        private readonly DataContext _context;

        public TblOfficersController(DataContext context)
        {
            _context = context;
        }

        // GET: TblOfficers
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblOfficer.Include(t => t.Department).Include(t => t.Level);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblOfficers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOfficer = await _context.TblOfficer
                .Include(t => t.Department)
                .Include(t => t.Level)
                .FirstOrDefaultAsync(m => m.OfficerId == id);
            if (tblOfficer == null)
            {
                return NotFound();
            }

            return View(tblOfficer);
        }

        // GET: TblOfficers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentId");
            ViewData["DepartmentName"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentName");
            ViewData["LevelId"] = new SelectList(_context.TblLevel, "LevelId", "LevelId");
            ViewData["LevelName"] = new SelectList(_context.TblLevel, "LevelId", "LevelName");

            return View();
        }

        // POST: TblOfficers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficerId,Username,CitizenId,CardId,PinCode,DepartmentId,LevelId,Createdate,ActiveFlag")] TblOfficer tblOfficer)
        {
            if (ModelState.IsValid)
            {
                tblOfficer.OfficerId = Guid.NewGuid();
                _context.Add(tblOfficer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentId", tblOfficer.DepartmentId);
            ViewData["DepartmentName"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentName", tblOfficer.Department.DepartmentName);
            ViewData["LevelId"] = new SelectList(_context.TblLevel, "LevelId", "LevelId", tblOfficer.LevelId);
            ViewData["LevelName"] = new SelectList(_context.TblLevel, "LevelId", "LevelName", tblOfficer.Level.LevelName);
            return View(tblOfficer);
        }

        // GET: TblOfficers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewData["DepartmentName"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentName");
            ViewData["LevelName"] = new SelectList(_context.TblLevel, "LevelId", "LevelName");
            if (id == null)
            {
                return NotFound();
            }

            var tblOfficer = await _context.TblOfficer.FindAsync(id);
            if (tblOfficer == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentId", tblOfficer.DepartmentId);
            ViewData["LevelId"] = new SelectList(_context.TblLevel, "LevelId", "LevelId", tblOfficer.LevelId);


            return View(tblOfficer);
        }

        // POST: TblOfficers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OfficerId,Username,CitizenId,CardId,PinCode,DepartmentId,LevelId,Createdate,ActiveFlag")] TblOfficer tblOfficer)
        {
            if (id != tblOfficer.OfficerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblOfficer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblOfficerExists(tblOfficer.OfficerId))
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
            ViewData["DepartmentId"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentId", tblOfficer.DepartmentId);
            ViewData["DepartmentName"] = new SelectList(_context.TblDepartment, "DepartmentId", "DepartmentName", tblOfficer.Department.DepartmentName);
            ViewData["LevelId"] = new SelectList(_context.TblLevel, "LevelId", "LevelId", tblOfficer.LevelId);
            ViewData["LevelName"] = new SelectList(_context.TblDepartment, "LevelName", "LevelName", tblOfficer.Level.LevelName);
            return View(tblOfficer);
        }

        // GET: TblOfficers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOfficer = await _context.TblOfficer
                .Include(t => t.Department)
                .Include(t => t.Level)
                .FirstOrDefaultAsync(m => m.OfficerId == id);
            if (tblOfficer == null)
            {
                return NotFound();
            }

            return View(tblOfficer);
        }

        // POST: TblOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblOfficer = await _context.TblOfficer.FindAsync(id);
            _context.TblOfficer.Remove(tblOfficer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOfficerExists(Guid id)
        {
            return _context.TblOfficer.Any(e => e.OfficerId == id);
        }
    }
}
