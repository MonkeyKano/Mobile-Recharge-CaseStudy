using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Models;

namespace MobileRecharge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly MobileRechargeDbContext _context;

        public CustomerDetailsController(MobileRechargeDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(long id)
        {
            var customerDetails = await _context.Customers.FindAsync(id);

            if (customerDetails == null)
            {
                return NotFound();
            }

            return customerDetails;
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetails(long id, CustomerDetails customerDetails)
        {
            if (id != customerDetails.PhoneNumber)
            {
                return BadRequest();
            }

            _context.Entry(customerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailsExists(id))
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

        // POST: api/CustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            _context.Customers.Add(customerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetails", new { id = customerDetails.PhoneNumber }, customerDetails);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetails(long id)
        {
            var customerDetails = await _context.Customers.FindAsync(id);
            if (customerDetails == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDetailsExists(long id)
        {
            return _context.Customers.Any(e => e.PhoneNumber == id);
        }
    }
}
