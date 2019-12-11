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
    public class OrdersController : ControllerBase
    {
        private readonly LibraryServiceMonolithicContext _context;

        public OrdersController(LibraryServiceMonolithicContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order
                .Include(order => order.OrderedBook)
                .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order
                .Include(order => order.OrderedBook)
                .FirstAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;


            if (order.IsCompleted)
            {
                var book = new Book
                {
                    Id = order.OrderedBook.Id,
                    ISBN = order.OrderedBook.ISBN,
                    Title = order.OrderedBook.Title,
                    Author = order.OrderedBook.Author,
                    AuthorId = order.OrderedBook.AuthorId
                };
                await _context.Book.AddAsync(book);
            }
        

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            if (order.IsCompleted)
            {
                var book = new Book
                {
                    Id = order.OrderedBook.Id,
                    ISBN = order.OrderedBook.ISBN,
                    Title = order.OrderedBook.Title,
                    Author = order.OrderedBook.Author,
                    AuthorId = order.OrderedBook.AuthorId
                };
                await _context.Book.AddAsync(book);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
