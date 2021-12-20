using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eroski.Models;

namespace Eroski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EroskiItemsController : ControllerBase
    {
        private readonly EroskiContext _context;

        public EroskiItemsController(EroskiContext context)
        {
            _context = context;
        }

        // GET: api/EroskiItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EroskiItems>>> GetEroskiItems()
        {
            return await _context.EroskiItems.ToListAsync();
        }

        // GET: api/EroskiItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EroskiItems>> GetEroskiItems(string id)
        {
            var eroskiItems = await _context.EroskiItems.FindAsync(id);

            if (eroskiItems == null)
            {
                return NotFound();
            }

            return eroskiItems;
        }

        // PUT: api/EroskiItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEroskiItems(string id, EroskiItems eroskiItems)
        {
            if (id != eroskiItems.Seccion)
            {
                return BadRequest();
            }

            _context.Entry(eroskiItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EroskiItemsExists(id))
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

        // POST: api/EroskiItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EroskiItems>> PostEroskiItems(EroskiItems eroskiItems)
        {
            _context.EroskiItems.Add(eroskiItems);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EroskiItemsExists(eroskiItems.Seccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEroskiItems", new { id = eroskiItems.Seccion }, eroskiItems);
        }

        // DELETE: api/EroskiItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEroskiItems(string id)
        {
            var eroskiItems = await _context.EroskiItems.FindAsync(id);
            if (eroskiItems == null)
            {
                return NotFound();
            }

            _context.EroskiItems.Remove(eroskiItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EroskiItemsExists(string id)
        {
            return _context.EroskiItems.Any(e => e.Seccion == id);
        }
    }
}
