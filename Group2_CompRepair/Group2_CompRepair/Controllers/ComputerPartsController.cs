#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group2_CompRepair.Data;
using Group2_CompRepair.Models;
using Microsoft.AspNetCore.Authorization;
using Group2_CompRepair;



namespace Group2_CompRepair.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ComputerPartsController : ControllerBase
    {
        //adding code trying something out
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public ComputerPartsController(JwtAuthenticationManager jwtAuthenticationManager, Group2_ComprepairContext context)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }
        //-------------------------

        private readonly Group2_ComprepairContext _context;

        /* public ComputerPartsController(Group2_ComprepairContext context)
         {
             _context = context;
         }*/

        // GET: api/ComputerParts
        [Authorize]        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerPart>>> GetComputerParts()
        {
            return await _context.ComputerParts.ToListAsync();
        }
        //new code---------------
        /*[AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }*/



        //new code-------------------

        // GET: api/ComputerParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerPart>> GetComputerPart(int id)
        {
            var computerPart = await _context.ComputerParts.FindAsync(id);

            if (computerPart == null)
            {
                return NotFound();
            }

            return computerPart;
        }

        // PUT: api/ComputerParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputerPart(int id, ComputerPart computerPart)
        {
            if (id != computerPart.ComputerPartsId)
            {
                return BadRequest();
            }

            _context.Entry(computerPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerPartExists(id))
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

        // POST: api/ComputerParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComputerPart>> PostComputerPart(ComputerPart computerPart)
        {
            _context.ComputerParts.Add(computerPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputerPart", new { id = computerPart.ComputerPartsId }, computerPart);
        }

        // DELETE: api/ComputerParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputerPart(int id)
        {
            var computerPart = await _context.ComputerParts.FindAsync(id);
            if (computerPart == null)
            {
                return NotFound();
            }

            _context.ComputerParts.Remove(computerPart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputerPartExists(int id)
        {
            return _context.ComputerParts.Any(e => e.ComputerPartsId == id);
        }
    }
}
