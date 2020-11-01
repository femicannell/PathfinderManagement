using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathfinderManagement.Data;
using PathfinderManagement.Models;

namespace PathfinderManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathfindersAPI : ControllerBase
    {
        private readonly PfDbContext _context;

        public PathfindersAPI(PfDbContext context)
        {
            _context = context;
        }

        // GET: api/PathfindersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pathfinders>>> GetPathfinders()
        {
            return await _context.Pathfinders.ToListAsync();
        }

        // GET: api/PathfindersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pathfinders>> GetPathfinders(int id)
        {
            var pathfinders = await _context.Pathfinders.FindAsync(id);

            if (pathfinders == null)
            {
                return NotFound();
            }

            return pathfinders;
        }

        // PUT: api/PathfindersAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPathfinders(int id, Pathfinders pathfinders)
        {
            if (id != pathfinders.Id)
            {
                return BadRequest();
            }

            _context.Entry(pathfinders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PathfindersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PathfindersAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pathfinders>> PostPathfinders(Pathfinders pathfinders)
        {
            _context.Pathfinders.Add(pathfinders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPathfinders", new { id = pathfinders.Id }, pathfinders);
        }

        // DELETE: api/PathfindersAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pathfinders>> DeletePathfinders(int id)
        {
            var pathfinders = await _context.Pathfinders.FindAsync(id);
            if (pathfinders == null)
            {
                return NotFound();
            }

            _context.Pathfinders.Remove(pathfinders);
            await _context.SaveChangesAsync();

            return pathfinders;
        }

        private bool PathfindersExists(int id)
        {
            return _context.Pathfinders.Any(e => e.Id == id);
        }
    }
}
