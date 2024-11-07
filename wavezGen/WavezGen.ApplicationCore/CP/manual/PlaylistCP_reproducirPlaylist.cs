
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



        try
        {
                CPSession.SessionInitializeTransaction ();

                playlistCEN = new  PlaylistCEN (CPSession.UnitRepo.PlaylistRepository);
                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                cancionCEN = new CancionCEN(CPSession.UnitRepo.UsuarioRepository);
                colaReprodCEN = new ColaReprodCEN(CPSession.UnitRepo.UsuarioRepository);

                PlaylistEN playlist = playlistCEN.DamePlaylistPorOID(p_oid);
                UsuarioEN usuario = usuarioCEN.DameUsuarioPorOID(p_Usuario);

                if (usuario.ColaReprod)  //si ya hay cola
                {
                
                ColaReprodEN colaReprod = usuario.ColaReprod;  //se coge la cola del usuario
                colaReprodCEN.VaciarCola();              ///y se vacia
                }
                else
                {
                ColaReprodEN colaReprod =  ColaReprodCEN.Nuevo(p_Usuario);
                }


                IList<int> p_OIDs_canciones = new List<int>();

                foreach (CancionEN cancion in playlist.Cancion)
                {
                p_OIDs_canciones.Add(cancion.Id);
                }
                colaReprodCEN.AgregarCancion(usuario.ColaReprod.Id, p_OIDs_canciones);

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
