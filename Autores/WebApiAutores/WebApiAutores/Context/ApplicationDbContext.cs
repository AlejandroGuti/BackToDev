using Microsoft.EntityFrameworkCore;
using WebApiAutores.Context.Entities;


namespace WebApiAutores.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
