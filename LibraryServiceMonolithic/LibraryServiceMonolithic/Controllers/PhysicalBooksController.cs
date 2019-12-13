using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryServiceMonolithic.Models;

namespace LibraryServiceMonolithic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalBooksController : ControllerBase
    {
        private readonly LibraryServiceMonolithicContext _context;

        public PhysicalBooksController(LibraryServiceMonolithicContext context)
        {
            _context = context;
        }

        // GET: api/PhysicalBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhysicalBook>>> GetPhysicalBook()
        {
            return await _context.PhysicalBook.ToListAsync();
        }

        // GET: api/PhysicalBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhysicalBook>> GetPhysicalBook(int id)
        {
            var physicalBook = await _context.PhysicalBook.FindAsync(id);

            if (physicalBook == null)
            {
                return NotFound();
            }

            return physicalBook;
        }

        // PUT: api/PhysicalBooks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhysicalBook(int id, PhysicalBook physicalBook)
        {
            if (id != physicalBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(physicalBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysicalBookExists(id))
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

        // POST: api/PhysicalBooks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PhysicalBook>> PostPhysicalBook(PhysicalBook physicalBook)
        {
            _context.PhysicalBook.Add(physicalBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhysicalBook", new { id = physicalBook.Id }, physicalBook);
        }

        // DELETE: api/PhysicalBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhysicalBook>> DeletePhysicalBook(int id)
        {
            var physicalBook = await _context.PhysicalBook.FindAsync(id);
            if (physicalBook == null)
            {
                return NotFound();
            }

            _context.PhysicalBook.Remove(physicalBook);
            await _context.SaveChangesAsync();

            return physicalBook;
        }

        private bool PhysicalBookExists(int id)
        {
            return _context.PhysicalBook.Any(e => e.Id == id);
        }
    }
}
