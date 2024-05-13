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
    public class DiemdensController : Controller
    {
        private readonly DoAnContext _context;

        public DiemdensController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Diemdens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diemdens.ToListAsync());
        }

        // GET: Diemdens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemden = await _context.Diemdens
                .FirstOrDefaultAsync(m => m.Madd == id);
            if (diemden == null)
            {
                return NotFound();
            }

            return View(diemden);
        }

        // GET: Diemdens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diemdens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madd,Tendd,Dc,Thongtindiemden")] Diemden diemden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diemden);
        }

        // GET: Diemdens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemden = await _context.Diemdens.FindAsync(id);
            if (diemden == null)
            {
                return NotFound();
            }
            return View(diemden);
        }

        // POST: Diemdens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madd,Tendd,Dc,Thongtindiemden")] Diemden diemden)
        {
            if (id != diemden.Madd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemdenExists(diemden.Madd))
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
            return View(diemden);
        }

        // GET: Diemdens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemden = await _context.Diemdens
                .FirstOrDefaultAsync(m => m.Madd == id);
            if (diemden == null)
            {
                return NotFound();
            }

            return View(diemden);
        }

        // POST: Diemdens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemden = await _context.Diemdens.FindAsync(id);
            if (diemden != null)
            {
                _context.Diemdens.Remove(diemden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemdenExists(int id)
        {
            return _context.Diemdens.Any(e => e.Madd == id);
        }
    }
}
