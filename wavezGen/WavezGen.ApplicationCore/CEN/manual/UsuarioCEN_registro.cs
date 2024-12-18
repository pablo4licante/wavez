
using System;
using System.Text;
using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CEN.Wavez_Usuario_registro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CEN.Wavez
{
public partial class UsuarioCEN
{
public void Registro (string p_oid, string nombre, string password, string email, string fotoPerfil)
{
            /*PROTECTED REGION ID(WavezGen.ApplicationCore.CEN.Wavez_Usuario_registro) ENABLED START*/

            // Write here your custom code...

            Console.WriteLine("OYE ESTOY AQUI " + p_oid);
        // TODO
        UsuarioEN usuario = new UsuarioEN (p_oid, nombre, password, email, fotoPerfil,
                null, null, null, null, null, null, null, null, null, null);

        _IUsuarioRepository.Nuevo (usuario);

        /*PROTECTED REGION END*/
}
}
}
