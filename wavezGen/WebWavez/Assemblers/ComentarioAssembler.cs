using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class ComentarioAssembler
    {

        public ComentarioViewModel ConvertirENToViewModel(ComentarioEN comentarioEN)
        {
            ComentarioViewModel comentarioViewModel = new ComentarioViewModel();
            comentarioViewModel.Id = comentarioEN.Id;
            comentarioViewModel.Cancion = comentarioEN.Cancion.Id;
            comentarioViewModel.UsuarioOID = comentarioEN.Usuario.Usuario;
            comentarioViewModel.UsuarioDisplay = comentarioEN.Usuario.Nombre;
            comentarioViewModel.Mensaje = comentarioEN.Texto;
            comentarioViewModel.FotoUrl = comentarioEN.Usuario.FotoPerfil;
            return comentarioViewModel;
        }

        public IList<ComentarioViewModel> ConvertirListENToListViewModel(IList<ComentarioEN> listaENs)
        {
            IList<ComentarioViewModel> listaComentariosVM = new List<ComentarioViewModel>();
            foreach (ComentarioEN comentarioEN in listaENs)
            {
                listaComentariosVM.Add(ConvertirENToViewModel(comentarioEN));
            }
            return listaComentariosVM.ToList();
        }
    }
}
