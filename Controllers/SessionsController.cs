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
    public class ResumeController : ControllerBase
    {
        private readonly TodoContext _context;

        public ResumeController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Resume
        [HttpGet]
        public async Task<ActionResult> GetTodoItems()
        {
            var total = await _context.TodoItems.Select(t => t.Valor).SumAsync();
            return Ok(new
                {
                    total = total
                });
        }

        // GET: api/Resume/5
        [HttpGet("{filtro}")]
        public async Task<ActionResult> GetTodoItem(bool filtro)
        {
            var total = await _context.TodoItems
                .Where(t=>t.IsComplete==filtro)
                .Select(t => t.Valor).SumAsync();

             return Ok(new
                {
                    IsComplete = filtro,
                    total = total
                });
        }

                // GET: api/Resume/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTodoItemId(int id)
        {
              var item = await _context.TodoItems
              .FirstOrDefaultAsync(t => t.Id == id);

             return Ok(new
                {
                    Fecha = DateTime.Now,
                    IsComplete = item.IsComplete,
                    Valor = item.Valor
                });
        }

        // GET: api/Resume/reset/5
        [HttpGet("/reset/{id}")]
        public async Task<ActionResult> GetTodoItemReset(long id)
        {
            var item = await _context.TodoItems
              .FirstOrDefaultAsync(t => t.Id == id);
            item.Valor = 0;
            await _context.SaveChangesAsync();
            return Ok(new
                {
                    ResetOn = DateTime.Now,
                    item = item
                });

        }

    }
}