using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Models
{
    public class ComunidadDetailsViewModel
    {
        public ComunidadViewModel Comunidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public IEnumerable<NotificacionViewModel> Notificaciones { get; set; }
    }
}