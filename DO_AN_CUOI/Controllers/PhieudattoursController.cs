using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DO_AN_CUOI.Models;

namespace DO_AN_CUOI.Controllers
{
    public class PhieudattoursController : Controller
    {
        private readonly DoAnContext _context;

        public PhieudattoursController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Phieudattours
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Phieudattours.Include(p => p.MakhNavigation).Include(p => p.MakmNavigation).Include(p => p.ManvNavigation).Include(p => p.MatourNavigation);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Phieudattours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudattour = await _context.Phieudattours
                .Include(p => p.MakhNavigation)
                .Include(p => p.MakmNavigation)
                .Include(p => p.ManvNavigation)
                .Include(p => p.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Mapdt == id);
            if (phieudattour == null)
            {
                return NotFound();
            }

            return View(phieudattour);
        }

        // GET: Phieudattours/Create
        public IActionResult Create()
        {
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh");
            ViewData["Tenkm"] = new SelectList(_context.Khuyenmais, "Makm", "Tenkm");
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv");
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour");
            return View();
        }

        // POST: Phieudattours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mapdt,Matour,Makh,Makm,Manv,Song,Ngaydat,Tongtien,Dvt")] Phieudattour phieudattour)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(phieudattour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", phieudattour.Makh);
            ViewData["Tenkm"] = new SelectList(_context.Khuyenmais, "Makm", "Tenkm", phieudattour.Makm);
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv", phieudattour.Manv);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", phieudattour.Matour);
            return View(phieudattour);
        }

        // GET: Phieudattours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudattour = await _context.Phieudattours.FindAsync(id);
            if (phieudattour == null)
            {
                return NotFound();
            }
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", phieudattour.Makh);
            ViewData["Tenkm"] = new SelectList(_context.Khuyenmais, "Makm", "Tenkm", phieudattour.Makm);
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv", phieudattour.Manv);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", phieudattour.Matour);
            return View(phieudattour);
        }

        // POST: Phieudattours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mapdt,Matour,Makh,Makm,Manv,Song,Ngaydat,Tongtien,Dvt")] Phieudattour phieudattour)
        {
            if (id != phieudattour.Mapdt)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieudattour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudattourExists(phieudattour.Mapdt))
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
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", phieudattour.Makh);
            ViewData["Tenkm"] = new SelectList(_context.Khuyenmais, "Makm", "Tenkm", phieudattour.Makm);
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv", phieudattour.Manv);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", phieudattour.Matour);
            return View(phieudattour);
        }

        // GET: Phieudattours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudattour = await _context.Phieudattours
                .Include(p => p.MakhNavigation)
                .Include(p => p.MakmNavigation)
                .Include(p => p.ManvNavigation)
                .Include(p => p.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Mapdt == id);
            if (phieudattour == null)
            {
                return NotFound();
            }

            return View(phieudattour);
        }

        // POST: Phieudattours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieudattour = await _context.Phieudattours.FindAsync(id);
            if (phieudattour != null)
            {
                _context.Phieudattours.Remove(phieudattour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieudattourExists(int id)
        {
            return _context.Phieudattours.Any(e => e.Mapdt == id);
        }
    }
}
