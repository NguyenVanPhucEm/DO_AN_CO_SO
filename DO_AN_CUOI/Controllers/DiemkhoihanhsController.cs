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
    public class DiemkhoihanhsController : Controller
    {
        private readonly DoAnContext _context;
        private readonly Diemkhoihanh _diemkhoihanh;
        public DiemkhoihanhsController(DoAnContext context, Diemkhoihanh diemkhoihanh1)
        {
            _context = context;
            _diemkhoihanh = diemkhoihanh1;
        }

        // GET: Diemkhoihanhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diemkhoihanhs.ToListAsync());
        }

        // GET: Diemkhoihanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemkhoihanh = await _context.Diemkhoihanhs
                .FirstOrDefaultAsync(m => m.Madkh == id);
            if (diemkhoihanh == null)
            {
                return NotFound();
            }

            return View(diemkhoihanh);
        }

        // GET: Diemkhoihanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diemkhoihanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madkh,Tendkh,Dc,Sdt")] Diemkhoihanh diemkhoihanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemkhoihanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diemkhoihanh);
        }

        // GET: Diemkhoihanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemkhoihanh = await _context.Diemkhoihanhs.FindAsync(id);
            if (diemkhoihanh == null)
            {
                return NotFound();
            }
            return View(diemkhoihanh);
        }

        // POST: Diemkhoihanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madkh,Tendkh,Dc,Sdt")] Diemkhoihanh diemkhoihanh)
        {
            if (id != diemkhoihanh.Madkh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemkhoihanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemkhoihanhExists(diemkhoihanh.Madkh))
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
            return View(diemkhoihanh);
        }

        // GET: Diemkhoihanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemkhoihanh = await _context.Diemkhoihanhs
                .FirstOrDefaultAsync(m => m.Madkh == id);
            if (diemkhoihanh == null)
            {
                return NotFound();
            }

            return View(diemkhoihanh);
        }

        // POST: Diemkhoihanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemkhoihanh = await _context.Diemkhoihanhs.FindAsync(id);
            if (diemkhoihanh != null)
            {
                _context.Diemkhoihanhs.Remove(diemkhoihanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemkhoihanhExists(int id)
        {
            return _context.Diemkhoihanhs.Any(e => e.Madkh == id);
        }
    }
}
