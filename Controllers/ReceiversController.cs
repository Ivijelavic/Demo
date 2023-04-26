using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Api.Data;
using Demo.Api.Models;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiversController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public ReceiversController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Receivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receivers>>> GetReceivers()
        {
          if (_context.Receivers == null)
          {
              return NotFound();
          }
            return await _context.Receivers.ToListAsync();
        }

        // GET: api/Receivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receivers>> GetReceivers(int id)
        {
          if (_context.Receivers == null)
          {
              return NotFound();
          }
            var receivers = await _context.Receivers.FindAsync(id);

            if (receivers == null)
            {
                return NotFound();
            }

            return receivers;
        }

        // PUT: api/Receivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceivers(int id, Receivers receivers)
        {
            if (id != receivers.Id_User)
            {
                return BadRequest();
            }

            _context.Entry(receivers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiversExists(id))
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

        // POST: api/Receivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receivers>> PostReceivers(Receivers receivers)
        {
          if (_context.Receivers == null)
          {
              return Problem("Entity set 'DemoDbContext.Receivers'  is null.");
          }
            receivers.Id_User = null;
            _context.Receivers.Add(receivers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceivers", new { id = receivers.Id_User }, receivers);
        }

        // DELETE: api/Receivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceivers(int id)
        {
            if (_context.Receivers == null)
            {
                return NotFound();
            }
            var receivers = await _context.Receivers.FindAsync(id);
            if (receivers == null)
            {
                return NotFound();
            }

            _context.Receivers.Remove(receivers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiversExists(int id)
        {
            return (_context.Receivers?.Any(e => e.Id_User == id)).GetValueOrDefault();
        }
    }
}
