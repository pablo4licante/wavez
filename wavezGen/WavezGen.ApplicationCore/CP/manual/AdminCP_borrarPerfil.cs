
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Admin_borrarPerfil) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class AdminCP : GenericBasicCP
{
public void BorrarPerfil (string p_oid, string perfil_OID)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Admin_borrarPerfil) ENABLED START*/

        AdminCEN adminCEN = null;
        UsuarioCEN usuarioCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                adminCEN = new  AdminCEN (CPSession.UnitRepo.AdminRepository);
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);

                UsuarioEN usuarioABorrar = usuarioCEN.DameUsuarioPorOID (perfil_OID);

                usuarioCEN.Eliminar (usuarioABorrar.Usuario);

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
