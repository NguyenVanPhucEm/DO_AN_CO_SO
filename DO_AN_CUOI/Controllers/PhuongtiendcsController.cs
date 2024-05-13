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
    public class PhuongtiendcsController : Controller
    {
        private readonly DoAnContext _context;

        public PhuongtiendcsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Phuongtiendcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phuongtiendcs.ToListAsync());
        }

        // GET: Phuongtiendcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongtiendc = await _context.Phuongtiendcs
                .FirstOrDefaultAsync(m => m.Mapt == id);
            if (phuongtiendc == null)
            {
                return NotFound();
            }

            return View(phuongtiendc);
        }

        // GET: Phuongtiendcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phuongtiendcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mapt,Tenpt")] Phuongtiendc phuongtiendc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongtiendc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongtiendc);
        }

        // GET: Phuongtiendcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongtiendc = await _context.Phuongtiendcs.FindAsync(id);
            if (phuongtiendc == null)
            {
                return NotFound();
            }
            return View(phuongtiendc);
        }

        // POST: Phuongtiendcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mapt,Tenpt")] Phuongtiendc phuongtiendc)
        {
            if (id != phuongtiendc.Mapt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongtiendc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongtiendcExists(phuongtiendc.Mapt))
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
            return View(phuongtiendc);
        }

        // GET: Phuongtiendcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongtiendc = await _context.Phuongtiendcs
                .FirstOrDefaultAsync(m => m.Mapt == id);
            if (phuongtiendc == null)
            {
                return NotFound();
            }

            return View(phuongtiendc);
        }

        // POST: Phuongtiendcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongtiendc = await _context.Phuongtiendcs.FindAsync(id);
            if (phuongtiendc != null)
            {
                _context.Phuongtiendcs.Remove(phuongtiendc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongtiendcExists(int id)
        {
            return _context.Phuongtiendcs.Any(e => e.Mapt == id);
        }
    }
}
