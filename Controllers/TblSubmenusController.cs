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
    public class TblSubmenusController : Controller
    {
        private readonly DataContext _context;

        public TblSubmenusController(DataContext context)
        {
            _context = context;
        }

        // GET: TblSubmenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblSubmenu.ToListAsync());
        }

        // GET: TblSubmenus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubmenu = await _context.TblSubmenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSubmenu == null)
            {
                return NotFound();
            }

            return View(tblSubmenu);
        }

        // GET: TblSubmenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblSubmenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuNo,MenuNameTh,MenuNameEn,ServiceAddress,OfficeId,ServiceId,Version,Activeflag,ServiceQty,ServiceFormatType")] TblSubmenu tblSubmenu)
        {
            if (ModelState.IsValid)
            {
                tblSubmenu.Id = Guid.NewGuid();
                _context.Add(tblSubmenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSubmenu);
        }

        // GET: TblSubmenus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubmenu = await _context.TblSubmenu.FindAsync(id);
            if (tblSubmenu == null)
            {
                return NotFound();
            }
            return View(tblSubmenu);
        }

        // POST: TblSubmenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MenuNo,MenuNameTh,MenuNameEn,ServiceAddress,OfficeId,ServiceId,Version,Activeflag,ServiceQty,ServiceFormatType")] TblSubmenu tblSubmenu)
        {
            if (id != tblSubmenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSubmenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSubmenuExists(tblSubmenu.Id))
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
            return View(tblSubmenu);
        }

        // GET: TblSubmenus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubmenu = await _context.TblSubmenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSubmenu == null)
            {
                return NotFound();
            }

            return View(tblSubmenu);
        }

        // POST: TblSubmenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblSubmenu = await _context.TblSubmenu.FindAsync(id);
            _context.TblSubmenu.Remove(tblSubmenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSubmenuExists(Guid id)
        {
            return _context.TblSubmenu.Any(e => e.Id == id);
        }
    }
}
