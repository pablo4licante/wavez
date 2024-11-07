
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
