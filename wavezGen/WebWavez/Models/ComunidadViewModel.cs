using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Models
{
    public class ComunidadViewModel
    {
        [ScaffoldColumn(false)]

        public GenerosEnum Genero { get; set; }
    }
}
