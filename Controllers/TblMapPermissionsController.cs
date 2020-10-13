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
    public class TblMapPermissionsController : Controller
    {
        private readonly DataContext _context;

        public TblMapPermissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblMapPermissions
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblMapPermission.Include(t => t.MapMenu).Include(t => t.Officer);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblMapPermissions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapPermission = await _context.TblMapPermission
                .Include(t => t.MapMenu)
                .Include(t => t.Officer)
                .FirstOrDefaultAsync(m => m.PermissionId == id);
            if (tblMapPermission == null)
            {
                return NotFound();
            }

            return View(tblMapPermission);
        }

        // GET: TblMapPermissions/Create
        public IActionResult Create()
        {
            ViewData["MapMenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id");
            ViewData["No"] = new SelectList(_context.TblMapMenu, "Id", "No");
            ViewData["OfficerId"] = new SelectList(_context.TblOfficer, "OfficerId", "OfficerId");
            ViewData["Username"] = new SelectList(_context.TblOfficer, "OfficerId", "Username");
            return View();
        }

        // POST: TblMapPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionId,OfficerId,MapMenuId,ActiveFlag")] TblMapPermission tblMapPermission)
        {
            if (ModelState.IsValid)
            {
                tblMapPermission.PermissionId = Guid.NewGuid();
                _context.Add(tblMapPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MapMenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblMapPermission.MapMenuId);
            ViewData["No"] = new SelectList(_context.TblMapMenu, "Id", "No", tblMapPermission.MapMenu.No);
            ViewData["OfficerId"] = new SelectList(_context.TblOfficer, "OfficerId", "OfficerId", tblMapPermission.OfficerId);
            ViewData["Username"] = new SelectList(_context.TblOfficer, "OfficerId", "Username", tblMapPermission.Officer.Username);
            return View(tblMapPermission);
        }

        // GET: TblMapPermissions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewData["No"] = new SelectList(_context.TblMapMenu, "Id", "No");
            ViewData["Username"] = new SelectList(_context.TblOfficer, "OfficerId", "Username");
            if (id == null)
            {
                return NotFound();
            }

            var tblMapPermission = await _context.TblMapPermission.FindAsync(id);
            if (tblMapPermission == null)
            {
                return NotFound();
            }
            ViewData["MapMenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblMapPermission.MapMenuId);
            ViewData["OfficerId"] = new SelectList(_context.TblOfficer, "OfficerId", "OfficerId", tblMapPermission.OfficerId);
            return View(tblMapPermission);
        }

        // POST: TblMapPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PermissionId,OfficerId,MapMenuId,ActiveFlag")] TblMapPermission tblMapPermission)
        {
            if (id != tblMapPermission.PermissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMapPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMapPermissionExists(tblMapPermission.PermissionId))
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
            ViewData["MapMenuId"] = new SelectList(_context.TblMapMenu, "Id", "Id", tblMapPermission.MapMenuId);
            ViewData["No"] = new SelectList(_context.TblMapMenu, "Id", "No", tblMapPermission.MapMenu.No);
            ViewData["OfficerId"] = new SelectList(_context.TblOfficer, "OfficerId", "OfficerId", tblMapPermission.OfficerId);
            ViewData["Username"] = new SelectList(_context.TblOfficer, "OfficerId", "Username", tblMapPermission.Officer.Username);
            return View(tblMapPermission);
        }

        // GET: TblMapPermissions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMapPermission = await _context.TblMapPermission
                .Include(t => t.MapMenu)
                .Include(t => t.Officer)
                .FirstOrDefaultAsync(m => m.PermissionId == id);
            if (tblMapPermission == null)
            {
                return NotFound();
            }

            return View(tblMapPermission);
        }

        // POST: TblMapPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblMapPermission = await _context.TblMapPermission.FindAsync(id);
            _context.TblMapPermission.Remove(tblMapPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMapPermissionExists(Guid id)
        {
            return _context.TblMapPermission.Any(e => e.PermissionId == id);
        }
    }
}
