using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.EN.Wavez;

namespace WebWavez.Models
{
    public class PlaylistViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Dale nombre a la playlist", Description = "Titulo de la playlist", Name = "Titulo")]
        [Required(ErrorMessage = "Debe indicar un nombre para la playlist")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre de la playlist no puede tener más de 50 caracteres")]
        [RegularExpression(@"^[\w\s\-\!\?\.\,\(\)\[\]\&\#\@\$\%\*\+]*$", ErrorMessage = "El nombre de la playlist contiene caracteres no permitidos")]
        public string Titulo { get; set; }

        public string FotoPortada { get; set; }

        public UsuarioEN UsuarioCreador { get; set; }
        public string Portada { get; internal set; }
    }
}