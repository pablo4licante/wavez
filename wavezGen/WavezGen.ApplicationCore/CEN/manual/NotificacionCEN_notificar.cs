
using System;
using System.Text;
using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CEN.Wavez_Notificacion_notificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CEN.Wavez
{
public partial class NotificacionCEN
{
public void Notificar (int p_oid)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CEN.Wavez_Notificacion_notificar) ENABLED START*/

        // Write here your custom code...

        // TODO PREGUNTAR

        NotificacionEN notificacion = DameNotificacionPorOID (p_oid);

        foreach (UsuarioEN usuario in notificacion.UsuariosReceptores) {
                usuario.RecibeNotificacion.Add (notificacion);
        }

        /*PROTECTED REGION END*/
}
}
}
