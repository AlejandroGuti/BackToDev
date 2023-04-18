using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Context;
using WebApiAutores.Context.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route ("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("AutorDetailed/{id:int}")]
        public async Task<ActionResult<Autor>> AutorDetailed(int id)
        {
            return await _context.Autores.Include(x=>x.Books).FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            return await _context.Autores.FirstOrDefaultAsync(x=>x.Id==id);
        }

        [HttpGet(Name ="AllAutors")]
        public async Task<ActionResult<List<Autor>>> AllAutors()
        {
            return await _context.Autores.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> CreateAutor(Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> AutorUpdate (Autor autor, int id)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide");
            }
            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAutor(int id)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            _context.Remove(new Autor() { Id = id });
            await _context.SaveChangesAsync();
            return Ok(exist);
        }
        
    }
}
