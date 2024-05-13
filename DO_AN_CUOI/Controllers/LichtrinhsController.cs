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
    public class LichtrinhsController : Controller
    {
        private readonly DoAnContext _context;

        public LichtrinhsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Lichtrinhs
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Lichtrinhs.Include(l => l.MaddNavigation).Include(l => l.MaksNavigation).Include(l => l.MatourNavigation);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Lichtrinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichtrinh = await _context.Lichtrinhs
                .Include(l => l.MaddNavigation)
                .Include(l => l.MaksNavigation)
                .Include(l => l.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Malt == id);
            if (lichtrinh == null)
            {
                return NotFound();
            }

            return View(lichtrinh);
        }

        // GET: Lichtrinhs/Create
        public IActionResult Create()
        {
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd");
            ViewData["Tenks"] = new SelectList(_context.Khachsans, "Maks", "Tenks");
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour");
            return View();
        }

        // POST: Lichtrinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Malt,Maks,Madd,Matour,Thongtinchitiet")] Lichtrinh lichtrinh)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(lichtrinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", lichtrinh.Madd);
            ViewData["Tenks"] = new SelectList(_context.Khachsans, "Maks", "Tenks", lichtrinh.Maks);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", lichtrinh.Matour);
            return View(lichtrinh);
        }

        // GET: Lichtrinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichtrinh = await _context.Lichtrinhs.FindAsync(id);
            if (lichtrinh == null)
            {
                return NotFound();
            }
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", lichtrinh.Madd);
            ViewData["Tenks"] = new SelectList(_context.Khachsans, "Maks", "Tenks", lichtrinh.Maks);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", lichtrinh.Matour);
            return View(lichtrinh);
        }

        // POST: Lichtrinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Malt,Maks,Madd,Matour,Thongtinchitiet")] Lichtrinh lichtrinh)
        {
            if (id != lichtrinh.Malt)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichtrinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichtrinhExists(lichtrinh.Malt))
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
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", lichtrinh.Madd);
            ViewData["Tenks"] = new SelectList(_context.Khachsans, "Maks", "Tenks", lichtrinh.Maks);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", lichtrinh.Matour);
            return View(lichtrinh);
        }

        // GET: Lichtrinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichtrinh = await _context.Lichtrinhs
                .Include(l => l.MaddNavigation)
                .Include(l => l.MaksNavigation)
                .Include(l => l.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Malt == id);
            if (lichtrinh == null)
            {
                return NotFound();
            }

            return View(lichtrinh);
        }

        // POST: Lichtrinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichtrinh = await _context.Lichtrinhs.FindAsync(id);
            if (lichtrinh != null)
            {
                _context.Lichtrinhs.Remove(lichtrinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichtrinhExists(int id)
        {
            return _context.Lichtrinhs.Any(e => e.Malt == id);
        }
    }
}
