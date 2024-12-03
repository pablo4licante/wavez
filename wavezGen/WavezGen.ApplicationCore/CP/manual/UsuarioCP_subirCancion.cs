
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Usuario_subirCancion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class UsuarioCP : GenericBasicCP
{
public void SubirCancion (string p_oid, string URL)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Usuario_subirCancion) ENABLED START*/

        CancionCEN cancionCEN = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                cancionCEN = new CancionCEN (CPSession.UnitRepo.CancionRepository);
                string p_titulo_cancion = "default_title"; // Replace with actual value
                WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_genero_cancion = WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum.Pop; // Replace with actual value
                DateTime p_fecha_cancion = DateTime.Now; // Replace with actual value
                string p_foto_cancion = "default_photo"; // Replace with actual value
                string p_nif_cliente = "default_nif"; // Replace with actual value

                int idCancion = cancionCEN.Nuevo(p_titulo_cancion, p_genero_cancion, p_fecha_cancion, p_foto_cancion, p_nif_cliente, 0, URL);

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw;
        }
        finally
        {
                CPSession.SessionClose ();
        }

        /*PROTECTED REGION END*/
}
}
}
