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
    public class ToursController : Controller
    {
        private readonly DoAnContext _context;

        public ToursController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Tours.Include(t => t.MadkhNavigation).Include(t => t.MaloaiNavigation).Include(t => t.ManvNavigation).Include(t => t.MaptNavigation);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.MadkhNavigation)
                .Include(t => t.MaloaiNavigation)
                .Include(t => t.ManvNavigation)
                .Include(t => t.MaptNavigation)
                .FirstOrDefaultAsync(m => m.Matour == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            ViewData["Tendkh"] = new SelectList(_context.Diemkhoihanhs, "Madkh", "Tendkh");
            ViewData["Tenloai"] = new SelectList(_context.Loaitours, "Maloai", "Tenloai");
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv");
            ViewData["Tenpt"] = new SelectList(_context.Phuongtiendcs, "Mapt", "Tenpt");
            return View();
        }
        private async Task<string?> SaveImage(IFormFile anhAiien)
        {
            var savePath = Path.Combine("wwwroot/images", anhAiien.FileName); // Thay đổi đường dẫn theo cấu hình của bạn
        using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await anhAiien.CopyToAsync(fileStream);
            }
            return "/images/" + anhAiien.FileName;
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matour,Maloai,Madkh,Manv,Mapt,Tentour,Ngaykh,Ngaykt,Songay,Sodem,Soluongtoida,Sochodadat,Gia,Dvt,AnhAiien")] Tour tour, IFormFile AnhAiien)
        {
    

            if (!ModelState.IsValid)
            {
                if(AnhAiien != null)
                {
                    tour.AnhAiien = await SaveImage(AnhAiien);
                }
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tendkh"] = new SelectList(_context.Diemkhoihanhs, "Madkh", "Tendkh");
            ViewData["Tenloai"] = new SelectList(_context.Loaitours, "Maloai", "Tenloai");
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv");
            ViewData["Tenpt"] = new SelectList(_context.Phuongtiendcs, "Mapt", "Tenpt");
            return View();
        }

        
        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["Tendkh"] = new SelectList(_context.Diemkhoihanhs, "Madkh", "Tendkh", tour.Madkh);
            ViewData["Tenloai"] = new SelectList(_context.Loaitours, "Maloai", "Tenloai", tour.Maloai);
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv", tour.Manv);
            ViewData["Tenpt"] = new SelectList(_context.Phuongtiendcs, "Mapt", "Tenpt", tour.Mapt);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matour,Maloai,Madkh,Manv,Mapt,Tentour,Ngaykh,Ngaykt,Songay,Sodem,Soluongtoida,Sochodadat,Gia,Dvt,AnhAiien")] Tour tour)
        {
            if (id != tour.Matour)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Matour))
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
            ViewData["Tendkh"] = new SelectList(_context.Diemkhoihanhs, "Madkh", "Tendkh", tour.Madkh);
            ViewData["Tenloai"] = new SelectList(_context.Loaitours, "Maloai", "Tenloai", tour.Maloai);
            ViewData["Tennv"] = new SelectList(_context.Nhanviens, "Manv", "Tennv", tour.Manv);
            ViewData["Tenpt"] = new SelectList(_context.Phuongtiendcs, "Mapt", "Tenpt", tour.Mapt);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.MadkhNavigation)
                .Include(t => t.MaloaiNavigation)
                .Include(t => t.ManvNavigation)
                .Include(t => t.MaptNavigation)
                .FirstOrDefaultAsync(m => m.Matour == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.Matour == id);
        }
    }
}
