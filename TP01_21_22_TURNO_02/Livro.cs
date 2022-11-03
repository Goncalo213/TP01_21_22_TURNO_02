using System.ComponentModel.DataAnnotations;

namespace TP01_21_22_TURNO_02
{
    public class Livro
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string autores { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string editora { get; set; }

        [Key]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string ISBN { get; set; }

       // [RegularExpression(@"^.+\.([pP][dD][fF])$", ErrorMessage = "Only Pdf Files")]
       // [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Only JPG Files")]
        public string capa { get; set; } = " ";

       // [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Only JPG Files")]
        public string contracapa { get; set; } = " ";
    }
}
