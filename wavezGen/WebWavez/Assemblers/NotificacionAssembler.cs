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

            nvm.Comunidad = (int)notificacion.Comunidad.Genero; // TODO Check si funciona el cast
            nvm.Fecha = (DateTime)notificacion.Fecha;
            nvm.Id = notificacion.Id;
            nvm.Mensaje = notificacion.Mensaje;
            nvm.TipoContenido = notificacion.ContieneCancion != null ? "cancion" : "playlist";
            nvm.idReferencia = notificacion.ContieneCancion != null ? notificacion.ContieneCancion.Id : notificacion.ContienePlaylist.Id;
            nvm.Foto = notificacion.Foto;
            nvm.UsuariosReceptores = notificacion.UsuariosReceptores;

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