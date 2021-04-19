using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyApp.Data;
using MoneyApp.Models;

namespace MoneyApp.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayCentresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PayCentresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PayCentres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayCentre>>> GetCentres()
        {
            var UserName = User.Identity.Name;
            return await _context.Centres.Include(m => m.Staff).ToListAsync();
        }

        // GET: api/PayCentres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayCentre>> GetPayCentre(int id)
        {
            var payCentre = await _context.Centres.FindAsync(id);

            if (payCentre == null)
            {
                return NotFound();
            }

            return payCentre;
        }

        // PUT: api/PayCentres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayCentre(int id, PayCentre payCentre)
        {
            if (id != payCentre.Id)
            {
                return BadRequest();
            }

            _context.Entry(payCentre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayCentreExists(id))
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

        // POST: api/PayCentres
        [HttpPost]
        public async Task<ActionResult<PayCentre>> PostPayCentre(PayCentre payCentre)
        {
            _context.Centres.Add(payCentre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayCentre", new { id = payCentre.Id }, payCentre);
        }

        // DELETE: api/PayCentres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PayCentre>> DeletePayCentre(int id)
        {
            var payCentre = await _context.Centres.FindAsync(id);
            if (payCentre == null)
            {
                return NotFound();
            }

            _context.Centres.Remove(payCentre);
            await _context.SaveChangesAsync();

            return payCentre;
        }

        private bool PayCentreExists(int id)
        {
            return _context.Centres.Any(e => e.Id == id);
        }
    }
}
