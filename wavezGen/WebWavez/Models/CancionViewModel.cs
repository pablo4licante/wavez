using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Models
{
    public class CancionViewModel
    {

        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Dale nombre a la cancion", Description = "Titulo de la cancion", Name = "Titulo")]
        [Required(ErrorMessage = "Debe indicar un nombre para la cancion")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre de la cancion no puede tener mas de 50 caracteres")]
        [RegularExpression(@"^[\w\s\-\!\?\.\,\(\)\[\]\&\#\@\$\%\*\+]*$", ErrorMessage = "El nombre de la cancion contiene caracteres no permitidos")]
        public string Titulo { get; set; }

        public GenerosEnum Genero { get; set; } 

        public string FotoPortada { get; set; }

        public IFormFile FicheroFotoPortada { get; set; }

        public DateTime Fecha { get; set; }

        public int numReproducciones { get; set; }

        public string AutorDisplay { get; set; }
        public string Autor { get; set; }

        [Required(ErrorMessage = "Debe indicar un nombre para la cancion")]
        public string Url { get; set; }

        public IFormFile FicheroCancion { get; set; }

        public IEnumerable<string> Generos { get; set; }
    }
}
