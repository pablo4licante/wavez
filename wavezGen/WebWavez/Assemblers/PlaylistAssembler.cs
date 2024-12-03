using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class PlaylistAssembler
    {
        public PlaylistViewModel ConvertirENToViewModel(PlaylistEN playlist)
        {
            PlaylistViewModel pvm = new PlaylistViewModel();
            pvm.Id = playlist.Id;
            pvm.Titulo = playlist.Titulo;
            pvm.FotoPortada = playlist.Portada;
            pvm.UsuarioCreador = playlist.UsuarioCreador;
            return pvm;
        }

        public IList<PlaylistViewModel> ConvertirListENToListViewModel(IList<PlaylistEN> playlists)
        {
            IList<PlaylistViewModel> pvms = new List<PlaylistViewModel>();
            foreach (PlaylistEN playlist in playlists)
            {
                pvms.Add(ConvertirENToViewModel(playlist));
            }
            return pvms.ToList();
        }
    }
}