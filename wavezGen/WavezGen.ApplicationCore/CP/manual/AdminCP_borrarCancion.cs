
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Admin_borrarCancion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class AdminCP : GenericBasicCP
{
public void BorrarCancion (string p_oid, int cancion_OID)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Admin_borrarCancion) ENABLED START*/

        AdminCEN adminCEN = null;
        CancionCEN cancionCEN = null;



            try
        {
                CPSession.SessionInitializeTransaction ();
                adminCEN = new  AdminCEN (CPSession.UnitRepo.AdminRepository);
                cancionCEN = new CancionCEN(CPSession.UnitRepo.CancionRepository);

                CancionEN cancion = cancionCEN.DameCancionPorOID(cancion_OID);
                cancionCEN.Eliminar(cancion.Id);

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
