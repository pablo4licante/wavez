

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public int Nuevo (string p_foto, string p_mensaje, Nullable<DateTime> p_fecha, string p_tipoContenido, UsuarioEN usuarioPublicador, IList<UsuarioEN> usuariosReceptores, CancionEN cancionCompartida, PlaylistEN playlistCompartida)
{
        int oid;

        //Initialized NotificacionEN
        NotificacionEN notificacionEN = new NotificacionEN();
        notificacionEN.Foto = p_foto;
        notificacionEN.Mensaje = p_mensaje;
        notificacionEN.Fecha = p_fecha;
        notificacionEN.TipoContenido = p_tipoContenido;
            if (cancionCompartida != null)
            {
                notificacionEN.ContieneCancion = cancionCompartida;
            }

            if (playlistCompartida != null)
            {
                notificacionEN.ContienePlaylist = playlistCompartida;
            }
        notificacionEN.UsuarioPublicador = usuarioPublicador;
        notificacionEN.UsuariosReceptores = usuariosReceptores;



        oid = _INotificacionRepository.Nuevo (notificacionEN);
        return oid;
}

public int NuevoConComunidad(string p_foto, string p_mensaje, Nullable<DateTime> p_fecha, string p_tipoContenido, ComunidadEN comunidad, IList<UsuarioEN> usuariosReceptores, CancionEN cancionCompartida, PlaylistEN playlistCompartida)

        {
            int oid;

            //Initialized NotificacionEN
            NotificacionEN notificacionEN = new NotificacionEN();
            notificacionEN.Foto = p_foto;
            notificacionEN.Mensaje = p_mensaje;
            notificacionEN.Fecha = p_fecha;
            notificacionEN.TipoContenido = p_tipoContenido;
            if (cancionCompartida != null)
            {
                notificacionEN.ContieneCancion = cancionCompartida;
            }

            if (playlistCompartida != null)
            {
                notificacionEN.ContienePlaylist = playlistCompartida;
            }
            notificacionEN.Comunidad = comunidad;
            notificacionEN.UsuariosReceptores = usuariosReceptores;



            oid = _INotificacionRepository.Nuevo(notificacionEN);
            return oid;
        }

        public void Modificar (int p_Notificacion_OID, string p_foto, string p_mensaje, Nullable<DateTime> p_fecha, string p_tipoContenido)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Foto = p_foto;
        notificacionEN.Mensaje = p_mensaje;
        notificacionEN.Fecha = p_fecha;
        notificacionEN.TipoContenido = p_tipoContenido;
        //Call to NotificacionRepository

        _INotificacionRepository.Modificar (notificacionEN);
}

public void Eliminar (int id
                      )
{
        _INotificacionRepository.Eliminar (id);
}

public NotificacionEN DameNotificacionPorOID (int id
                                              )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.DameNotificacionPorOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> DameTodasLasNotificaciones (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.DameTodasLasNotificaciones (first, size);
        return list;
}
public void AsignarComunidad (int p_Notificacion_OID, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_comunidad_OID)
{
        //Call to NotificacionRepository

        _INotificacionRepository.AsignarComunidad (p_Notificacion_OID, p_comunidad_OID);
}
public void AsignarUsuariosReceptores (int p_Notificacion_OID, System.Collections.Generic.IList<string> p_usuariosReceptores_OIDs)
{
        //Call to NotificacionRepository

        _INotificacionRepository.AsignarUsuariosReceptores (p_Notificacion_OID, p_usuariosReceptores_OIDs);
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> DameNotificacionDeHoy ()
{
        return _INotificacionRepository.DameNotificacionDeHoy ();
}
public void AsignarCancion (int p_Notificacion_OID, int p_contieneCancion_OID)
{
        //Call to NotificacionRepository

        _INotificacionRepository.AsignarCancion (p_Notificacion_OID, p_contieneCancion_OID);
}
public void AsignarPlaylist (int p_Notificacion_OID, int p_contienePlaylist_OID)
{
        //Call to NotificacionRepository

        _INotificacionRepository.AsignarPlaylist (p_Notificacion_OID, p_contienePlaylist_OID);
}
public void AsignarUsuarioPublicador (int p_Notificacion_OID, string p_usuarioPublicador_OID)
{
        //Call to NotificacionRepository

        _INotificacionRepository.AsignarUsuarioPublicador (p_Notificacion_OID, p_usuarioPublicador_OID);
}
}
}
