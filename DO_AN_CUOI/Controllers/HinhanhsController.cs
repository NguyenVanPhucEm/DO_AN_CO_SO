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
    public class HinhanhsController : Controller
    {
        private readonly DoAnContext _context;

        public HinhanhsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Hinhanhs
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Hinhanhs.Include(h => h.MaddNavigation);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Hinhanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanhs
                .Include(h => h.MaddNavigation)
                .FirstOrDefaultAsync(m => m.Mah == id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            return View(hinhanh);
        }

        // GET: Hinhanhs/Create
        public IActionResult Create()
        {
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd");
            return View();
        }

        // POST: Hinhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mah,Madd,UrlHa")] Hinhanh hinhanh)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(hinhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Thông tin hình ảnh không hợp lệ.");
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", hinhanh.Madd);
            return View(hinhanh);

        }


        // GET: Hinhanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanhs.FindAsync(id);
            if (hinhanh == null)
            {
                return NotFound();
            }
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", hinhanh.Madd);
            return View(hinhanh);
        }

        // POST: Hinhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mah,Madd,UrlHa")] Hinhanh hinhanh)
        {
            if (id != hinhanh.Mah)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhanhExists(hinhanh.Mah))
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
            ViewData["Tendd"] = new SelectList(_context.Diemdens, "Madd", "Tendd", hinhanh.Madd);
            return View(hinhanh);
        }

        // GET: Hinhanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanhs
                .Include(h => h.MaddNavigation)
                .FirstOrDefaultAsync(m => m.Mah == id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            return View(hinhanh);
        }

        // POST: Hinhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hinhanh = await _context.Hinhanhs.FindAsync(id);
            if (hinhanh != null)
            {
                _context.Hinhanhs.Remove(hinhanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhanhExists(int id)
        {
            return _context.Hinhanhs.Any(e => e.Mah == id);
        }
    }
}
