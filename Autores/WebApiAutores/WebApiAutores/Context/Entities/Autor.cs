namespace WebApiAutores.Context.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
