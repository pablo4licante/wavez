using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertirENToViewModel(NotificacionEN notificacion)
        {
            NotificacionViewModel nvm = new NotificacionViewModel();
            if(notificacion.UsuarioPublicador != null)
            {
                nvm.UsuarioPublicador = notificacion.UsuarioPublicador.Usuario;
            } else
            {
                nvm.UsuarioPublicador = "";
            }

            nvm.Fecha = notificacion.Fecha ?? DateTime.MinValue;
            nvm.Id = notificacion.Id;
            nvm.Mensaje = notificacion.Mensaje;
            nvm.TipoContenido = notificacion.TipoContenido;
            nvm.Foto = notificacion.Foto;
            

            IList<UsuarioEN> usuarios_receptores = notificacion.UsuariosReceptores;
            
            
            IList<string> usuarios_receptores_string = new List<string>();

            foreach (UsuarioEN usuario in usuarios_receptores)
            {
                Console.WriteLine("Usuario AGREGADO a notificacion: " + usuario.Usuario);
                usuarios_receptores_string.Add(usuario.Usuario);
            }

            nvm.UsuariosReceptores = usuarios_receptores_string;
            
            if(notificacion.TipoContenido == "cancion")
            {
                nvm.CancionCompartida = notificacion.ContieneCancion.Id;
            } else if (notificacion.TipoContenido == "playlist")
            {
                nvm.PlaylistCompartida = notificacion.ContienePlaylist.Id;
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