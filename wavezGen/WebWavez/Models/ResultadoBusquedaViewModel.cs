using System.Collections.Generic;

namespace WebWavez.Models
{
    public class ResultadoBusquedaViewModel
    {
        public IEnumerable<CancionViewModel> Canciones { get; set; }
        public IEnumerable<PlaylistViewModel> Playlists { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
        public string[] Filtros { get; set; }

    }
}