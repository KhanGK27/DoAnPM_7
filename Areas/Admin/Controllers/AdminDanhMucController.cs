using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDanhMucController : Controller
    {
        private readonly BanDienThoaiContext _context;

        public AdminDanhMucController(BanDienThoaiContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDanhMuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucSps.ToListAsync());
        }

        // GET: Admin/AdminDanhMuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSps
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSp == null)
            {
                return NotFound();
            }

            return View(danhMucSp);
        }

        // GET: Admin/AdminDanhMuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDanhMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm,AnhDm,MoTaDm,TrangThai")] DanhMucSp danhMucSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucSp);
        }

        // GET: Admin/AdminDanhMuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSps.FindAsync(id);
            if (danhMucSp == null)
            {
                return NotFound();
            }
            return View(danhMucSp);
        }

        // POST: Admin/AdminDanhMuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDm,TenDm,AnhDm,MoTaDm,TrangThai")] DanhMucSp danhMucSp)
        {
            if (id != danhMucSp.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucSpExists(danhMucSp.MaDm))
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
            return View(danhMucSp);
        }

        // GET: Admin/AdminDanhMuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSps
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSp == null)
            {
                return NotFound();
            }

            return View(danhMucSp);
        }

        // POST: Admin/AdminDanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhMucSp = await _context.DanhMucSps.FindAsync(id);
            _context.DanhMucSps.Remove(danhMucSp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucSpExists(int id)
        {
            return _context.DanhMucSps.Any(e => e.MaDm == id);
        }
    }
}
