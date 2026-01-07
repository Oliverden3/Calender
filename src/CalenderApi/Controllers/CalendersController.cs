using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalenderApi.DB;
using CalenderApi.DB.Models;

namespace CalenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CalendersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Calenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calender>>> GetCalenders()
        {
            return await _context.Calenders.ToListAsync();
        }

        // GET: api/Calenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calender>> GetCalender(Guid id)
        {
            var calender = await _context.Calenders.FindAsync(id);

            if (calender == null)
            {
                return NotFound();
            }

            return calender;
        }

        // PUT: api/Calenders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalender(Guid id, Calender calender)
        {
            if (id != calender.Id)
            {
                return BadRequest();
            }

            _context.Entry(calender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalenderExists(id))
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

        // POST: api/Calenders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calender>> PostCalender(Calender calender)
        {
            _context.Calenders.Add(calender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalender", new { id = calender.Id }, calender);
        }

        // DELETE: api/Calenders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalender(Guid id)
        {
            var calender = await _context.Calenders.FindAsync(id);
            if (calender == null)
            {
                return NotFound();
            }

            _context.Calenders.Remove(calender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalenderExists(Guid id)
        {
            return _context.Calenders.Any(e => e.Id == id);
        }
    }
}
