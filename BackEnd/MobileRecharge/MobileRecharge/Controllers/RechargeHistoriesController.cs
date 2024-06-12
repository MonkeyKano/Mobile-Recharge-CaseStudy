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
    public class RechargeHistoriesController : ControllerBase
    {
        private readonly MobileRechargeDbContext _context;

        public RechargeHistoriesController(MobileRechargeDbContext context)
        {
            _context = context;
        }

        // GET: api/RechargeHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RechargeHistory>>> GetHistory()
        {
            return await _context.History.ToListAsync();
        }

        // GET: api/RechargeHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RechargeHistory>> GetRechargeHistory(int id)
        {
            var rechargeHistory = await _context.History.FindAsync(id);

            if (rechargeHistory == null)
            {
                return NotFound();
            }

            return rechargeHistory;
        }

        // PUT: api/RechargeHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRechargeHistory(int id, RechargeHistory rechargeHistory)
        {
            if (id != rechargeHistory.RechargeId)
            {
                return BadRequest();
            }

            _context.Entry(rechargeHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RechargeHistoryExists(id))
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

        // POST: api/RechargeHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RechargeHistory>> PostRechargeHistory(RechargeHistory rechargeHistory)
        {
            _context.History.Add(rechargeHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRechargeHistory", new { id = rechargeHistory.RechargeId }, rechargeHistory);
        }

        // DELETE: api/RechargeHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRechargeHistory(int id)
        {
            var rechargeHistory = await _context.History.FindAsync(id);
            if (rechargeHistory == null)
            {
                return NotFound();
            }

            _context.History.Remove(rechargeHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RechargeHistoryExists(int id)
        {
            return _context.History.Any(e => e.RechargeId == id);
        }
    }
}
