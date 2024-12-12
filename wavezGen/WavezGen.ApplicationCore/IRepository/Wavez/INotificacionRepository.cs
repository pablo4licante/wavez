
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface INotificacionRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);




int Nuevo (NotificacionEN notificacion);

void Modificar (NotificacionEN notificacion);


void Eliminar (int id
               );


NotificacionEN DameNotificacionPorOID (int id
                                       );


System.Collections.Generic.IList<NotificacionEN> DameTodasLasNotificaciones (int first, int size);


void AsignarComunidad (int p_Notificacion_OID, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_comunidad_OID);

void AsignarUsuariosReceptores (int p_Notificacion_OID, System.Collections.Generic.IList<string> p_usuariosReceptores_OIDs);

System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> DameNotificacionDeHoy ();


void AsignarCancion (int p_Notificacion_OID, int p_contieneCancion_OID);

void AsignarPlaylist (int p_Notificacion_OID, int p_contienePlaylist_OID);

void AsignarUsuarioPublicador (int p_Notificacion_OID, string p_usuarioPublicador_OID);
}
}
