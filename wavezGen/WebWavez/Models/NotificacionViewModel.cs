using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WavezGen.ApplicationCore.EN.Wavez;

namespace WebWavez.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "El id de la notificacion es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La foto es obligatoria.")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        [StringLength(500, ErrorMessage = "El mensaje no puede exceder los 500 caracteres.")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El id del usuario publicador es obligatorio.")]
        public UsuarioEN UsuarioPublicador { get; set; }

        [Required(ErrorMessage = "Los usuarios receptores son obligatorios.")]
        public IList<UsuarioEN> UsuariosReceptores { get; set; }

        public int Comunidad { get; set; }

        [Required(ErrorMessage = "El tipo de contenido debe ser cancion o playlist")]
        public string TipoContenido { get; set; }

        [Required(ErrorMessage = "Incluye al menos un id de playlist o cancion al que hacer referencia")]
        public int idReferencia { get; set; }
    }
}