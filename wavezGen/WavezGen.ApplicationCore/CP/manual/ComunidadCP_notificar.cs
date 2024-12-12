
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Comunidad_notificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class ComunidadCP : GenericBasicCP
{
public void Notificar (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_oid, int p_Notificacion)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Comunidad_notificar) ENABLED START*/

        ComunidadCEN comunidadCEN = null;
        NotificacionCEN notificacionCEN = null;


        // TODO preguntar por esto
        try
        {
                CPSession.SessionInitializeTransaction ();
                comunidadCEN = new  ComunidadCEN (CPSession.UnitRepo.ComunidadRepository);
                notificacionCEN = new NotificacionCEN (CPSession.UnitRepo.NotificacionRepository);

                ComunidadEN comunidad = comunidadCEN.DameComunidadPorOID (p_oid);
                NotificacionEN notificacion = notificacionCEN.DameNotificacionPorOID (p_Notificacion);

                foreach (UsuarioEN usuario in comunidad.Usuario) {
                        usuario.RecibeNotificacion.Add (notificacion);
                }

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
