using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Models
{
    public class ComunidadDetailsViewModel
    {
        public ComunidadViewModel Comunidad { get; set; }
        public IEnumerable<NotificacionViewModel> Notificaciones { get; set; }
    }
}