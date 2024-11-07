
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
public void SubirCancion (string p_oid, string p_titulo_cancion, Enumerated.Wavez.GenerosEnum p_genero_cancion, Nullable<DateTime> p_fecha_cancion, string p_foto_cancion, string p_nif_cliente)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Usuario_subirCancion) ENABLED START*/

        CancionCEN cancionCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                cancionCEN = new CancionCEN (CPSession.UnitRepo.CancionRepository);
                //public int Nuevo (string p_titulo, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_genero, string p_fotoPortada, string p_autor, int p_numReproducciones)

                int idCancion = cancionCEN.Nuevo (p_titulo_cancion, p_genero_cancion, p_fecha_cancion, p_foto_cancion, p_nif_cliente, 0);

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
