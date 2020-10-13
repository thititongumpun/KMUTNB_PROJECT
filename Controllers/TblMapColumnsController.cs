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
    public class TblMapColumnsController : Controller
    {
        private readonly DataContext _context;

        public TblMapColumnsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblMapColumns
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblMapColumn.Include(t => t.SubMenu);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblMapColumns/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapColumn = await _context.TblMapColumn
                .Include(t => t.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMapColumn == null)
            {
                return NotFound();
            }

            return View(tblMapColumn);
        }

        // GET: TblMapColumns/Create
        public IActionResult Create()
        {
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id");
            ViewData["MenuNo"] = new SelectList(_context.TblSubmenu, "Id", "MenuNo");
            return View();
        }

        // POST: TblMapColumns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubMenuId,ColumnName,ColumnDesc,ColumnLevel,ActiveFlag,No,ColumnDateFormat,ColumnTimeFormat,ColumnTimestamp,ColumnDateTimeFormat,ColumnFileFormat,IsCitizenId,StartColor,ExternalLink,MoneyFormat,Underline")] TblMapColumn tblMapColumn)
        {
            if (ModelState.IsValid)
            {
                tblMapColumn.Id = Guid.NewGuid();
                _context.Add(tblMapColumn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapColumn.SubMenuId);
            ViewData["MenuNo"] = new SelectList(_context.TblSubmenu, "Id", "MenuNo", tblMapColumn.SubMenu.MenuNo);
            return View(tblMapColumn);
        }

        // GET: TblMapColumns/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewData["MenuNo"] = new SelectList(_context.TblSubmenu, "Id", "MenuNo");
            if (id == null)
            {
                return NotFound();
            }

            var tblMapColumn = await _context.TblMapColumn.FindAsync(id);
            if (tblMapColumn == null)
            {
                return NotFound();
            }
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapColumn.SubMenuId);
            return View(tblMapColumn);
        }

        // POST: TblMapColumns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SubMenuId,ColumnName,ColumnDesc,ColumnLevel,ActiveFlag,No,ColumnDateFormat,ColumnTimeFormat,ColumnTimestamp,ColumnDateTimeFormat,ColumnFileFormat,IsCitizenId,StartColor,ExternalLink,MoneyFormat,Underline")] TblMapColumn tblMapColumn)
        {
            if (id != tblMapColumn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMapColumn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMapColumnExists(tblMapColumn.Id))
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
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapColumn.SubMenuId);
            ViewData["MenuNo"] = new SelectList(_context.TblSubmenu, "Id", "MenuNo", tblMapColumn.SubMenu.MenuNo);
            return View(tblMapColumn);
        }

        // GET: TblMapColumns/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapColumn = await _context.TblMapColumn
                .Include(t => t.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMapColumn == null)
            {
                return NotFound();
            }

            return View(tblMapColumn);
        }

        // POST: TblMapColumns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblMapColumn = await _context.TblMapColumn.FindAsync(id);
            _context.TblMapColumn.Remove(tblMapColumn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMapColumnExists(Guid id)
        {
            return _context.TblMapColumn.Any(e => e.Id == id);
        }
    }
}
