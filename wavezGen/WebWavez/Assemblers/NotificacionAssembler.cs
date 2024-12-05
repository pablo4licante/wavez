using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertirENToViewModel(NotificacionEN notificacion)
        {
            NotificacionViewModel nvm = new NotificacionViewModel();
            nvm.UsuarioPublicador = notificacion.UsuarioPublicador;

            nvm.Fecha = (DateTime)notificacion.Fecha;
            nvm.Id = notificacion.Id;
            nvm.Mensaje = notificacion.Mensaje;
            nvm.TipoContenido = notificacion.TipoContenido;
            nvm.Foto = notificacion.Foto;
            nvm.UsuarioPublicador = notificacion.UsuarioPublicador;
            nvm.UsuariosReceptores = notificacion.UsuariosReceptores;
            if(notificacion.TipoContenido == "cancion")
            {
                nvm.CancionCompartida = notificacion.ContieneCancion;
            } else if (notificacion.TipoContenido == "playlist")
            {
                nvm.PlaylistCompartida = notificacion.ContienePlaylist;
            }

            return nvm;
        }

        public IList<NotificacionViewModel> ConvertirListENToListViewModel(IList<NotificacionEN> notificaciones)
        {
            IList<NotificacionViewModel> nvms = new List<NotificacionViewModel>();
            foreach (NotificacionEN notificacion in notificaciones)
            {
                nvms.Add(ConvertirENToViewModel(notificacion));
            }
            return nvms.ToList();
        }
    }
}