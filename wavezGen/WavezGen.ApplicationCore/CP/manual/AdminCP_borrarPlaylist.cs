
using System;
using System.Text;

using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;



/*PROTECTED REGION ID(usingWavezGen.ApplicationCore.CP.Wavez_Admin_borrarPlaylist) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class AdminCP : GenericBasicCP
{
public void BorrarPlaylist (string p_oid, int playlist_OID)
{
        /*PROTECTED REGION ID(WavezGen.ApplicationCore.CP.Wavez_Admin_borrarPlaylist) ENABLED START*/

        AdminCEN adminCEN = null;
        PlaylistCEN playlistCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                adminCEN = new  AdminCEN (CPSession.UnitRepo.AdminRepository);
                playlistCEN = new PlaylistCEN(CPSession.UnitRepo.PlaylistRepository);

                PlaylistEN playlist = playlistCEN.DamePlaylistPorOID(playlist_OID);
                playlistCEN.Eliminar(playlist.Id);

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