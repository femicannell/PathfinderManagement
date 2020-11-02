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
    public class PathfindersController : Controller
    {
        private readonly PfDbContext _context;

        public PathfindersController(PfDbContext context)
        {
            _context = context;
        }

        // GET: Pathfinders
        public async Task<IActionResult> Index()
        {
            var pathfinders = _context.Pathfinders.Select(s => new PathfindersDTO()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Group = s.Group,
                //Counsellor = s.Counsellor
            }).ToListAsync();
            //old code
            //await _context.StaffNames.ToListAsync()
            return View(await pathfinders);
        }

        // GET: Pathfinders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pathfinders = await _context.Pathfinders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pathfinders == null)
            {
                return NotFound();
            }

            return View(pathfinders);
        }

        // GET: Pathfinders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pathfinders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Group")] Pathfinders pathfinders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pathfinders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pathfinders);
        }

        // GET: Pathfinders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pathfinders = await _context.Pathfinders.FindAsync(id);
            if (pathfinders == null)
            {
                return NotFound();
            }
            return View(pathfinders);
        }

        // POST: Pathfinders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Group")] Pathfinders pathfinders)
        {
            if (id != pathfinders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pathfinders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PathfindersExists(pathfinders.Id))
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
            return View(pathfinders);
        }

        // GET: Pathfinders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pathfinders = await _context.Pathfinders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pathfinders == null)
            {
                return NotFound();
            }

            return View(pathfinders);
        }

        // POST: Pathfinders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pathfinders = await _context.Pathfinders.FindAsync(id);
            _context.Pathfinders.Remove(pathfinders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PathfindersExists(int id)
        {
            return _context.Pathfinders.Any(e => e.Id == id);
        }
    }
}
