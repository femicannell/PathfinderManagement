using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PathfinderManagement.Data;
using PathfinderManagement.Models;

namespace PathfinderManagement.Controllers
{
    public class CounsellorsController : Controller
    {
        private readonly PfDbContext _context;

        public CounsellorsController(PfDbContext context)
        {
            _context = context;
        }

        // GET: Counsellors
        public async Task<IActionResult> Index()
        {
            var counsellors = _context.Counsellors.Select(s => new CounsellorsDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Rank = s.Rank,
                Group = s.Group,
                GroupSize = s.GroupSize
            }).ToListAsync();
            //old code
            //await _context.StaffNames.ToListAsync()
            return View(await counsellors);
        }

        // GET: Counsellors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counsellors = await _context.Counsellors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counsellors == null)
            {
                return NotFound();
            }

            return View(counsellors);
        }

        // GET: Counsellors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counsellors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rank,Group,GroupSize")] Counsellors counsellors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counsellors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(counsellors);
        }

        // GET: Counsellors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counsellors = await _context.Counsellors.FindAsync(id);
            if (counsellors == null)
            {
                return NotFound();
            }
            return View(counsellors);
        }

        // POST: Counsellors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rank,Group,GroupSize")] Counsellors counsellors)
        {
            if (id != counsellors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counsellors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounsellorsExists(counsellors.Id))
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
            return View(counsellors);
        }

        // GET: Counsellors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counsellors = await _context.Counsellors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counsellors == null)
            {
                return NotFound();
            }

            return View(counsellors);
        }

        // POST: Counsellors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var counsellors = await _context.Counsellors.FindAsync(id);
            _context.Counsellors.Remove(counsellors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CounsellorsExists(int id)
        {
            return _context.Counsellors.Any(e => e.Id == id);
        }
    }
}
