using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Common.Validations;


namespace WebApiAutores.Context.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The field {0} it's required")]
        [StringLength(maximumLength:5, ErrorMessage ="the field {0} should not have m ore than {1} characters")]
        [FirstCapital]
        public string Nombre { get; set; }
        [Range (18,1020)]
        [NotMapped]//para tener atributos no mapeados
        public int age { get; set; }
        [CreditCard]
        [NotMapped]
        public string CreditCard { get; set; }
        [Url]
        [NotMapped]
        public string URL { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
