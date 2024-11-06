
using System;
using System.Text;
using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CEN.Wavez_Cancion_reproducirCancion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CEN.Wavez
{
public partial class CancionCEN
{
public void ReproducirCancion (int p_oid)
{
            /*PROTECTED REGION ID(WavezGen.ApplicationCore.CEN.Wavez_Cancion_reproducirCancion) ENABLED START*/

            // Write here your custom code...


            CancionEN cancion = _ICancionRepository.DameCancionPorOID(p_oid);
            if (cancion == null)
            {
                throw new ModelException("Cancion no encontrada");
            }

            cancion.NumReproducciones++;
            _ICancionRepository.Modificar(cancion);

            throw new NotImplementedException ("Method ReproducirCancion() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
