
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_ColaReprod_vaciarCola) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class ColaReprodCP : GenericBasicCP
{
public void VaciarCola (int p_oid)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_ColaReprod_vaciarCola) ENABLED START*/

        ColaReprodCEN colaReprodCEN = null;
        CancionCEN cancionCEN = null;



            try
        {

                // Write here your custom transaction 

                CPSession.SessionInitializeTransaction ();
                colaReprodCEN = new  ColaReprodCEN (CPSession.UnitRepo.ColaReprodRepository);
                cancionCEN = new CancionCEN (CPSession.UnitRepo.CancionRepository);

                ColaReprodEN colaReprod = colaReprodCEN.DameColaPorOID(p_oid);
                
                IList<int> p_OIDs_canciones = new List<int>();

                foreach (CancionEN cancion in colaReprod.Cancion) { 
                    p_OIDs_canciones.Add(cancion.Id);
                }
                colaReprodCEN.QuitarCancion(p_oid, p_OIDs_canciones);


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
