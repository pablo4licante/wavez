
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Cancion_compartir) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class CancionCP : GenericBasicCP
{
public void Compartir (int p_oid, string publicador_oid)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Cancion_compartir) ENABLED START*/

        CancionCEN cancionCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                cancionCEN = new  CancionCEN (CPSession.UnitRepo.CancionRepository);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Compartir() not yet implemented.");



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
