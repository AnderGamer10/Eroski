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

        // GET: api/EroskiItems/(seccion)
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

        // PUT: api/EroskiItems/(seccion)
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEroskiItems(string id)
        {
            //Buscamos la seccion en la base de datos
            var eroskiItems = await _context.EroskiItems.FindAsync(id);
            //Si no existe devolvera notFound y si existe se le sumara uno al numero del ticket
            if (eroskiItems == null)
            {
                return NotFound();
            }
            else
            {
                eroskiItems.numeroTicket++;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/EroskiItems/Reset/(seccion)
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Reset/{id}")]
        public async Task<IActionResult> ResettEroskiItems(string id)
        {
            //Buscamos la seccion en la base de datos
            var eroskiItems = await _context.EroskiItems.FindAsync(id);
            //Si no existe devolvera notFound y si existe se le sumara uno al numero del ticket
            if (eroskiItems == null)
            {
                return NotFound();
            }
            else
            {
                eroskiItems.numeroTicket = 0;
            }

            await _context.SaveChangesAsync();
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
