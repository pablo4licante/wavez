using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Models
{
    public class ComentarioViewModel
    {

        [ScaffoldColumn(false)]

        public int Id { get; set; }

        public int Cancion { get; set; }

        public string UsuarioOID { get; set; }
        public string UsuarioDisplay { get; set; }


        public string Mensaje { get; set; }
        public string FotoUrl { get; set; }
}
}
