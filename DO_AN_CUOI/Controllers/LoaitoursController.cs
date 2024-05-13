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
    public class LoaitoursController : Controller
    {
        private readonly DoAnContext _context;

        public LoaitoursController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Loaitours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loaitours.ToListAsync());
        }

        // GET: Loaitours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitour = await _context.Loaitours
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaitour == null)
            {
                return NotFound();
            }

            return View(loaitour);
        }

        // GET: Loaitours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaitours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maloai,Tenloai")] Loaitour loaitour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaitour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaitour);
        }

        // GET: Loaitours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitour = await _context.Loaitours.FindAsync(id);
            if (loaitour == null)
            {
                return NotFound();
            }
            return View(loaitour);
        }

        // POST: Loaitours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maloai,Tenloai")] Loaitour loaitour)
        {
            if (id != loaitour.Maloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaitour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaitourExists(loaitour.Maloai))
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
            return View(loaitour);
        }

        // GET: Loaitours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitour = await _context.Loaitours
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaitour == null)
            {
                return NotFound();
            }

            return View(loaitour);
        }

        // POST: Loaitours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaitour = await _context.Loaitours.FindAsync(id);
            if (loaitour != null)
            {
                _context.Loaitours.Remove(loaitour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaitourExists(int id)
        {
            return _context.Loaitours.Any(e => e.Maloai == id);
        }
    }
}
