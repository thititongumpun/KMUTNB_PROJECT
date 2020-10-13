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
    public class TblMainMenusController : Controller
    {
        private readonly DataContext _context;

        public TblMainMenusController(DataContext context)
        {
            _context = context;
        }

        // GET: TblMainMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblMainMenu.ToListAsync());
        }

        // GET: TblMainMenus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMainMenu = await _context.TblMainMenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMainMenu == null)
            {
                return NotFound();
            }

            return View(tblMainMenu);
        }

        // GET: TblMainMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMainMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuNo,MenuNameTh,MenuShortNameTh,MenuNameEn,OfficeId,PageAddress,Activeflag")] TblMainMenu tblMainMenu)
        {
            if (ModelState.IsValid)
            {
                tblMainMenu.Id = Guid.NewGuid();
                _context.Add(tblMainMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMainMenu);
        }

        // GET: TblMainMenus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMainMenu = await _context.TblMainMenu.FindAsync(id);
            if (tblMainMenu == null)
            {
                return NotFound();
            }
            return View(tblMainMenu);
        }

        // POST: TblMainMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MenuNo,MenuNameTh,MenuShortNameTh,MenuNameEn,OfficeId,PageAddress,Activeflag")] TblMainMenu tblMainMenu)
        {
            if (id != tblMainMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMainMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMainMenuExists(tblMainMenu.Id))
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
            return View(tblMainMenu);
        }

        // GET: TblMainMenus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMainMenu = await _context.TblMainMenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMainMenu == null)
            {
                return NotFound();
            }

            return View(tblMainMenu);
        }

        // POST: TblMainMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblMainMenu = await _context.TblMainMenu.FindAsync(id);
            _context.TblMainMenu.Remove(tblMainMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMainMenuExists(Guid id)
        {
            return _context.TblMainMenu.Any(e => e.Id == id);
        }
    }
}
