using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAutores.Context.Entities
{
    public class Book: IValidatableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        [NotMapped]
        public int Menor { get; set; }
        [NotMapped]
        public int Major { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                var first = Title[0].ToString();
                if (first != first.ToUpper())
                {
                    yield return new ValidationResult("The inicial must be capital", 
                        new string[] { nameof(Title)});
                }
            }
            if (Menor > Major)
            {
                yield return new ValidationResult("The field Menor should be menor than the Major",
                    new string[] { nameof(Menor) });
            }

        }
    }
}
