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
    public class KhachsansController : Controller
    {
        private readonly DoAnContext _context;

        public KhachsansController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Khachsans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Khachsans.ToListAsync());
        }

        // GET: Khachsans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachsan = await _context.Khachsans
                .FirstOrDefaultAsync(m => m.Maks == id);
            if (khachsan == null)
            {
                return NotFound();
            }

            return View(khachsan);
        }

        // GET: Khachsans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachsans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maks,Tenks,Dc")] Khachsan khachsan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachsan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachsan);
        }

        // GET: Khachsans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachsan = await _context.Khachsans.FindAsync(id);
            if (khachsan == null)
            {
                return NotFound();
            }
            return View(khachsan);
        }

        // POST: Khachsans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maks,Tenks,Dc")] Khachsan khachsan)
        {
            if (id != khachsan.Maks)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachsan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachsanExists(khachsan.Maks))
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
            return View(khachsan);
        }

        // GET: Khachsans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachsan = await _context.Khachsans
                .FirstOrDefaultAsync(m => m.Maks == id);
            if (khachsan == null)
            {
                return NotFound();
            }

            return View(khachsan);
        }

        // POST: Khachsans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachsan = await _context.Khachsans.FindAsync(id);
            if (khachsan != null)
            {
                _context.Khachsans.Remove(khachsan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachsanExists(int id)
        {
            return _context.Khachsans.Any(e => e.Maks == id);
        }
    }
}
