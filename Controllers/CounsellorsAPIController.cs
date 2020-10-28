using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathfinderManagement.Data;
using PathfinderManagement.Models;

namespace PathfinderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounsellorsAPIController : ControllerBase
    {
        private readonly PfDbContext _context;

        public CounsellorsAPIController(PfDbContext context)
        {
            _context = context;
        }

        // GET: api/CounsellorsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Counsellors>>> GetCounsellors()
        {
            return await _context.Counsellors.ToListAsync();
        }

        // GET: api/CounsellorsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Counsellors>> GetCounsellors(int id)
        {
            var counsellors = await _context.Counsellors.FindAsync(id);

            if (counsellors == null)
            {
                return NotFound();
            }

            return counsellors;
        }

        // PUT: api/CounsellorsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounsellors(int id, Counsellors counsellors)
        {
            if (id != counsellors.Id)
            {
                return BadRequest();
            }

            _context.Entry(counsellors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounsellorsExists(id))
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

        // POST: api/CounsellorsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Counsellors>> PostCounsellors(Counsellors counsellors)
        {
            _context.Counsellors.Add(counsellors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounsellors", new { id = counsellors.Id }, counsellors);
        }

        // DELETE: api/CounsellorsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Counsellors>> DeleteCounsellors(int id)
        {
            var counsellors = await _context.Counsellors.FindAsync(id);
            if (counsellors == null)
            {
                return NotFound();
            }

            _context.Counsellors.Remove(counsellors);
            await _context.SaveChangesAsync();

            return counsellors;
        }

        private bool CounsellorsExists(int id)
        {
            return _context.Counsellors.Any(e => e.Id == id);
        }
    }
}
