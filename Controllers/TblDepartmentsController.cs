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
    public class TblDepartmentsController : Controller
    {
        private readonly DataContext _context;

        public TblDepartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblDepartment.ToListAsync());
        }

        // GET: TblDepartments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartment
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            return View(tblDepartment);
        }

        // GET: TblDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentCode,DepartmentName,ActiveFlag")] TblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                tblDepartment.DepartmentId = Guid.NewGuid();
                _context.Add(tblDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblDepartment);
        }

        // GET: TblDepartments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartment.FindAsync(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }
            return View(tblDepartment);
        }

        // POST: TblDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DepartmentId,DepartmentCode,DepartmentName,ActiveFlag")] TblDepartment tblDepartment)
        {
            if (id != tblDepartment.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDepartmentExists(tblDepartment.DepartmentId))
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
            return View(tblDepartment);
        }

        // GET: TblDepartments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepartment = await _context.TblDepartment
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            return View(tblDepartment);
        }

        // POST: TblDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblDepartment = await _context.TblDepartment.FindAsync(id);
            _context.TblDepartment.Remove(tblDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDepartmentExists(Guid id)
        {
            return _context.TblDepartment.Any(e => e.DepartmentId == id);
        }
    }
}
