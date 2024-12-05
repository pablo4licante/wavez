
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
        NotificacionCEN notificacionCEN = null;
        UsuarioCEN usuarioCEN = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                cancionCEN = new CancionCEN (CPSession.UnitRepo.CancionRepository);
                notificacionCEN = new NotificacionCEN (CPSession.UnitRepo.NotificacionRepository);
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);

                CancionEN cancionCompartida = cancionCEN.DameCancionPorOID (p_oid);
                UsuarioEN usuarioPublicador = usuarioCEN.DameUsuarioPorOID (publicador_oid);

                // TODO parece que solo pueda compartirse asi una cancion queda checkear una vez vaya esto para compartir playlist o cancion dependiendo de donde venga.
                if (cancionCompartida != null && usuarioPublicador != null) {
                        // Crear la notificacion
                        string mensaje = usuarioPublicador.Nombre + " ha compartido la cancion " + cancionCompartida.Titulo;
                        int idReferencia = cancionCompartida.Id;
                        IList<UsuarioEN> listaUsuarios = usuarioCEN.DameTodosLosUsuarios(0, -1);
                        IList<UsuarioEN> listaSeguidores = new List<UsuarioEN>();
                        foreach (UsuarioEN usuario in listaUsuarios)
                        {
                        if (usuario.UsuarioSeguidos.Contains(usuarioPublicador))
                            listaSeguidores.Add(usuario);
                        }
                    notificacionCEN.Nuevo(cancionCompartida.FotoPortada, mensaje, usuarioPublicador, idReferencia, (int)cancionCompartida.Genero, DateTime.Today, listaSeguidores);
                }
                else{
                        throw new Exception ("No se ha podido compartir la cancion.");
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
