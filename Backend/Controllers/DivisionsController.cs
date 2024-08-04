using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController(DatabaseContext context) : ControllerBase
    {
        // GET: api/Divisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> GetDivisions()
        {
            return await context.Divisions.Where(division => division.DeletedAt == null).ToListAsync();
        }

        // GET: api/Divisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> GetDivision(int id)
        {
            var division = await context.Divisions.FindAsync(id);

            if (division == null)
            {
                return NotFound();
            }

            return division;
        }

        // PUT: api/Divisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivision(int id, Division division)
        {
            if (id != division.Id)
            {
                return BadRequest();
            }

            context.Entry(division).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisionExists(id))
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

        // POST: api/Divisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Division>> PostDivision(Division division)
        {
            context.Divisions.Add(division);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetDivision", new { id = division.Id }, division);
        }

        // DELETE: api/Divisions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivision(int id)
        {
            var division = await context.Divisions.FindAsync(id);
            if (division == null)
            {
                return NotFound();
            }

            division.DeletedAt = DateTime.Now;
            context.Entry(division).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool DivisionExists(int id)
        {
            return context.Divisions.Any(e => e.Id == id);
        }
    }
}
