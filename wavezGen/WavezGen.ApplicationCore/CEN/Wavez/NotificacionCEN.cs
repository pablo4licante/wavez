

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

public int Nuevo (int p_id, string p_foto, string p_mensaje, Nullable<DateTime> p_fecha)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_id;

        notificacionEN.Foto = p_foto;

        notificacionEN.Mensaje = p_mensaje;

        notificacionEN.Fecha = p_fecha;



        oid = _INotificacionRepository.Nuevo (notificacionEN);
        return oid;
}

public void Modificar (int p_Notificacion_OID, string p_foto, string p_mensaje, Nullable<DateTime> p_fecha)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Foto = p_foto;
        notificacionEN.Mensaje = p_mensaje;
        notificacionEN.Fecha = p_fecha;
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
}
}
