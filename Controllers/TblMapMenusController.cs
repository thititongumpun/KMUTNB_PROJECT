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
    public class TblMapMenusController : Controller
    {
        private readonly DataContext _context;

        public TblMapMenusController(DataContext context)
        {
            _context = context;
        }

        // GET: TblMapMenus
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblMapMenu.Include(t => t.MainMenu).Include(t => t.SubMenu);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblMapMenus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapMenu = await _context.TblMapMenu
                .Include(t => t.MainMenu)
                .Include(t => t.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMapMenu == null)
            {
                return NotFound();
            }

            return View(tblMapMenu);
        }

        // GET: TblMapMenus/Create
        public IActionResult Create()
        {
            ViewData["MainMenuId"] = new SelectList(_context.TblMainMenu, "Id", "Id");
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id");
            ViewData["MainMenuMenuNameTh"] = new SelectList(_context.TblMainMenu, "Id", "MenuNameTh");
            ViewData["SubMenuMenuNameTh"] = new SelectList(_context.TblSubmenu, "Id", "MenuNameTh");
            return View();
        }

        // POST: TblMapMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MainMenuId,SubMenuId,No,ActiveFlag")] TblMapMenu tblMapMenu)
        {
            if (ModelState.IsValid)
            {
                tblMapMenu.Id = Guid.NewGuid();
                _context.Add(tblMapMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainMenuId"] = new SelectList(_context.TblMainMenu, "Id", "Id", tblMapMenu.MainMenuId);
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapMenu.SubMenuId);
            ViewData["MainMenuMenuNameTh"] = new SelectList(_context.TblMainMenu, "Id", "MenuNameTh", tblMapMenu.MainMenu.MenuNameTh);
            ViewData["SubMenuMenuNameTh"] = new SelectList(_context.TblSubmenu, "Id", "MenuNameTh", tblMapMenu.SubMenu.MenuNameTh);
            return View(tblMapMenu);
        }

        // GET: TblMapMenus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewData["MainMenuMenuNameTh"] = new SelectList(_context.TblMainMenu, "Id", "MenuNameTh");
            ViewData["SubMenuMenuNameTh"] = new SelectList(_context.TblSubmenu, "Id", "MenuNameTh");
            if (id == null)
            {
                return NotFound();
            }

            var tblMapMenu = await _context.TblMapMenu.FindAsync(id);
            if (tblMapMenu == null)
            {
                return NotFound();
            }
            ViewData["MainMenuId"] = new SelectList(_context.TblMainMenu, "Id", "Id", tblMapMenu.MainMenuId);
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapMenu.SubMenuId);
            return View(tblMapMenu);
        }

        // POST: TblMapMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MainMenuId,SubMenuId,No,ActiveFlag")] TblMapMenu tblMapMenu)
        {
            if (id != tblMapMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMapMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMapMenuExists(tblMapMenu.Id))
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
            ViewData["MainMenuId"] = new SelectList(_context.TblMainMenu, "Id", "Id", tblMapMenu.MainMenuId);
            ViewData["SubMenuId"] = new SelectList(_context.TblSubmenu, "Id", "Id", tblMapMenu.SubMenuId);
            ViewData["MainMenuMenuNameTh"] = new SelectList(_context.TblMainMenu, "Id", "MenuNameTh", tblMapMenu.MainMenu.MenuNameTh);
            ViewData["SubMenuMenuNameTh"] = new SelectList(_context.TblSubmenu, "Id", "MenuNameTh", tblMapMenu.SubMenu.MenuNameTh);
            return View(tblMapMenu);
        }

        // GET: TblMapMenus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapMenu = await _context.TblMapMenu
                .Include(t => t.MainMenu)
                .Include(t => t.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMapMenu == null)
            {
                return NotFound();
            }

            return View(tblMapMenu);
        }

        // POST: TblMapMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblMapMenu = await _context.TblMapMenu.FindAsync(id);
            _context.TblMapMenu.Remove(tblMapMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMapMenuExists(Guid id)
        {
            return _context.TblMapMenu.Any(e => e.Id == id);
        }
    }
}
