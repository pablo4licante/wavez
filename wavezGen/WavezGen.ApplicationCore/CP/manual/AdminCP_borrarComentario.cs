
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Admin_borrarComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class AdminCP : GenericBasicCP
{
public void BorrarComentario (string p_oid, int comentario_OID)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Admin_borrarComentario) ENABLED START*/

        AdminCEN adminCEN = null;
            ComentarioCEN comentarioCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                adminCEN = new  AdminCEN (CPSession.UnitRepo.AdminRepository);
                comentarioCEN = new ComentarioCEN(CPSession.UnitRepo.ComentarioRepository);
                ComentarioEN comentario = comentarioCEN.DameComentarioPorOID(comentario_OID);
                comentarioCEN.Eliminar(comentario.Id);

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
