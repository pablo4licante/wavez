
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Playlist_reproducirPlaylist) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class PlaylistCP : GenericBasicCP
{
public void ReproducirPlaylist (int p_oid, string p_Usuario)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Playlist_reproducirPlaylist) ENABLED START*/

        PlaylistCEN playlistCEN = null;
        UsuarioCEN usuarioCEN = null;
        CancionCEN cancionCEN = null;
        ColaReprodCEN colaReprodCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();

                playlistCEN = new PlaylistCEN (CPSession.UnitRepo.PlaylistRepository);
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);
                cancionCEN = new CancionCEN (CPSession.UnitRepo.CancionRepository);
                colaReprodCEN = new ColaReprodCEN (CPSession.UnitRepo.ColaReprodRepository);

                PlaylistEN playlist = playlistCEN.DamePlaylistPorOID (p_oid);
                UsuarioEN usuario = usuarioCEN.DameUsuarioPorOID (p_Usuario);


                if (usuario.ColaReprod != null) { //si ya hay cola
                        ColaReprodEN colaReprod = usuario.ColaReprod; //se coge la cola del usuario
                        colaReprod.Cancion.Clear ();         ///y se vacia
                        colaReprodCEN.Modificar (colaReprod.Id); //se actualiza la cola vac�a en la base de datos
                }
                else{
                        int colaReprodId = colaReprodCEN.Nuevo (p_Usuario);
                        usuario.ColaReprod = new ColaReprodEN ();
                        usuario.ColaReprod.Id = colaReprodId;
                        colaReprodCEN.Modificar (colaReprodId); //se guarda la nueva cola en la base de datos
                        usuarioCEN.Modificar (p_Usuario, usuario.Nombre, usuario.Contrasenya, usuario.Email, usuario.FotoPerfil);
                }


                IList<int> p_OIDs_canciones = new List<int>();

                foreach (CancionEN cancion in playlist.Cancion) {
                        p_OIDs_canciones.Add (cancion.Id);
                }
                colaReprodCEN.AgregarCancion (usuario.ColaReprod.Id, p_OIDs_canciones);

                //



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
