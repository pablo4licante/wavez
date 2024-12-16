

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class PlaylistCEN
 *
 */
public partial class PlaylistCEN
{
private IPlaylistRepository _IPlaylistRepository;

public PlaylistCEN(IPlaylistRepository _IPlaylistRepository)
{
        this._IPlaylistRepository = _IPlaylistRepository;
}

public IPlaylistRepository get_IPlaylistRepository ()
{
        return this._IPlaylistRepository;
}

public void QuitarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        //Call to PlaylistRepository

        _IPlaylistRepository.QuitarCancion (p_Playlist_OID, p_cancion_OIDs);
}
public void AddCancion(int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
    //Call to PlaylistRepository
    try
    {
        _IPlaylistRepository.AddCancion(p_Playlist_OID, p_cancion_OIDs);
        Console.WriteLine("Canciones añadidas: " + p_cancion_OIDs + " en la playlist: " + p_Playlist_OID);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al añadir canciones: " + ex.Message);
    }
}
public int Nuevo (string p_titulo, string p_portada, string p_usuarioCreador)
{
        PlaylistEN playlistEN = null;
        int oid;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Titulo = p_titulo;

        playlistEN.Portada = p_portada;


        if (p_usuarioCreador != null) {
                // El argumento p_usuarioCreador -> Property usuarioCreador es oid = false
                // Lista de oids id
                playlistEN.UsuarioCreador = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                playlistEN.UsuarioCreador.Usuario = p_usuarioCreador;
        }



        oid = _IPlaylistRepository.Nuevo (playlistEN);
        return oid;
}

public void Modificar (int p_Playlist_OID, string p_titulo, string p_portada)
{
        PlaylistEN playlistEN = null;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Id = p_Playlist_OID;
        playlistEN.Titulo = p_titulo;
        playlistEN.Portada = p_portada;
        //Call to PlaylistRepository

        _IPlaylistRepository.Modificar (playlistEN);
}

public void Eliminar (int id
                      )
{
        _IPlaylistRepository.Eliminar (id);
}

public PlaylistEN DamePlaylistPorOID (int id
                                      )
{
        PlaylistEN playlistEN = null;

        playlistEN = _IPlaylistRepository.DamePlaylistPorOID (id);
        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> DameTodasLasPlaylist (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> list = null;

        list = _IPlaylistRepository.DameTodasLasPlaylist (first, size);
        return list;
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> DamePlaylistsPorNombre (string nombre)
{
        return _IPlaylistRepository.DamePlaylistsPorNombre (nombre);
}
}
}
