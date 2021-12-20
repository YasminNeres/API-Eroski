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
    public class SessionesController : ControllerBase
    {
        private readonly SessionesContext _context;

        public SessionesController(SessionesContext context)
        {
            _context = context;
        }

        // GET: api/Mercados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetMercadoFs()
        {
            return await _context.Sessions.ToListAsync();
        }

        // GET: api/Mercados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetMercadoF(string id)
        {
            var mercadoF = await _context.Sessions.FindAsync(id);

            if (mercadoF == null)
            {
                return NotFound();
            }
           
              await _context.SaveChangesAsync();


            return mercadoF;

        }

        // PUT: api/Mercados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMercadoF(string id)
        {
           
            var mercadoF = await _context.Sessions.FindAsync(id);

           

            if (id != mercadoF.nSeccion )
            {
                return BadRequest();
            }

           
            _context.Entry(mercadoF).State = EntityState.Modified;

            try
            { 
                mercadoF.Ticket +=1;
            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercadoFExists(id))
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
          // Segundo PUT
         // PUT: api/Mercados/Reset
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

          [HttpPut("Reset")]
        public async Task<IActionResult> PutMercadoF2(string id)
        {
           
            var mercadoF = await _context.Sessions.FindAsync(id);

           

            if (id != mercadoF.nSeccion )
            {
                return BadRequest();
            }

           
            _context.Entry(mercadoF).State = EntityState.Modified;

            try
            { 
                mercadoF.Ticket = 0;
            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercadoFExists(id))
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

        // POST: api/Mercados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Session>> PostMercadoF(Session mercadoF)
        {
            _context.Sessions.Add(mercadoF);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MercadoFExists(mercadoF.nSeccion ))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMercadoF", new { id = mercadoF.nSeccion  }, mercadoF);
        }

        private bool MercadoFExists(string id)
        {
            return _context.Sessions.Any(e => e.nSeccion  == id);
        }
    }
}