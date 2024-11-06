
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IPlaylistRepository
{
void setSessionCP (GenericSessionCP session);

PlaylistEN ReadOIDDefault (int id
                           );

void ModifyDefault (PlaylistEN playlist);

System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size);








void EliminarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs);

void AddCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs);

int Nuevo (PlaylistEN playlist);

void Modificar (PlaylistEN playlist);


void Eliminar (int id
               );


PlaylistEN DamePlaylistPorOID (int id
                               );


System.Collections.Generic.IList<PlaylistEN> DameTodasLasPlaylist (int first, int size);


System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> DamePlaylistsPorNombre (string nombre);


void AsignarUsuario (int p_Playlist_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void DesasignarUsuario (int p_Playlist_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);
}
}
