using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Context;
using WebApiAutores.Context.Entities;


namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("byId/{id:int}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBookByIdDetailed(int id)
        {
            return await _context.Books.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.Id == id);
        } 
        [HttpGet("AllBooks/{id:int}")]
        public async Task<ActionResult<List<Book>>> AllBooks(int id)
        {
            return await _context.Books.ToListAsync();
        }
       

        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book)
        {
            var autorExist = await _context.Autores.AnyAsync(x => x.Id == book.AutorId);
            if (!autorExist)
            {
                return BadRequest($"Autor Not Found with Id {book.AutorId}");
            }
            _context.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }


    }
}
