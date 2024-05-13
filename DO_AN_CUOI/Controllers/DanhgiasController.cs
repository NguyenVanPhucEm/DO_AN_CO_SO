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
    public class DanhgiasController : Controller
    {
        private readonly DoAnContext _context;

        public DanhgiasController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Danhgias
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Danhgia.Include(d => d.MakhNavigation).Include(d => d.MatourNavigation);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Danhgias/Details/5
        public async Task<IActionResult> Details(int? makh, int? matour)
        {
            if (makh == null || matour == null)
            {
                return NotFound();
            }

            var danhgia = await _context.Danhgia
                .Include(d => d.MakhNavigation)
                .Include(d => d.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Makh == makh && m.Matour == matour);
            if (danhgia == null)
            {
                return NotFound();
            }

            return View(danhgia);
        }

        // GET: Danhgias/Create
        public IActionResult Create()
        {
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh");
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour");
            return View();
        }

        // POST: Danhgias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Matour,Noidungdanhgia,Sosao,Thoigiandanhgia")] Danhgia danhgia)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(danhgia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", danhgia.Makh);
            ViewData["Tetour"] = new SelectList(_context.Tours, "Matour", "Tentour", danhgia.Matour);
            return View(danhgia);
        }

        // GET: Danhgias/Edit/5
        public async Task<IActionResult> Edit(int? makh, int? matour)
        {
            if (makh == null || matour == null)
            {
                return NotFound();
            }

            var danhgia = await _context.Danhgia.FindAsync(makh,matour);
            if (danhgia == null)
            {
                return NotFound();
            }
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", danhgia.Makh);
            ViewData["Tentour"] = new SelectList(_context.Tours, "Matour", "Tentour", danhgia.Matour);
            return View(danhgia);
        }

        // POST: Danhgias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int makh, int matour, [Bind("Makh,Matour,Noidungdanhgia,Sosao,Thoigiandanhgia")] Danhgia danhgia)
        {
            if (makh != danhgia.Makh || matour != danhgia.Matour)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhgia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhgiaExists(danhgia.Makh, danhgia.Matour))
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
            ViewData["Tenkh"] = new SelectList(_context.Khachhangs, "Makh", "Tenkh", danhgia.Makh);
            ViewData["Makh"] = new SelectList(_context.Tours, "Matour", "Tentour", danhgia.Matour);
            return View(danhgia);
        }

        // GET: Danhgias/Delete/5
        public async Task<IActionResult> Delete(int makh, int matour)
        {
            if (makh == null || matour == null)
            {
                return NotFound();
            }

            var danhgia = await _context.Danhgia
                .Include(d => d.MakhNavigation)
                .Include(d => d.MatourNavigation)
                .FirstOrDefaultAsync(m => m.Makh == makh && m.Matour == matour);
            if (danhgia == null)
            {
                return NotFound();
            }

            return View(danhgia);
        }

        // POST: Danhgias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int makh, int matour)
        {
            var danhgia = await _context.Danhgia.FindAsync(makh, matour);
            if (danhgia != null)
            {
                _context.Danhgia.Remove(danhgia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhgiaExists(int makh, int matour)
        {
            return _context.Danhgia.Any(e => e.Makh == makh && e.Matour== matour);
        }
    }
}
