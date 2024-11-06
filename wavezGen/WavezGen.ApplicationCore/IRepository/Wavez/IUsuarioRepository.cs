
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string usuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);










string Nuevo (UsuarioEN usuario);



void Modificar (UsuarioEN usuario);


void Eliminar (string usuario
               );


UsuarioEN DameUsuarioPorOID (string usuario
                             );


System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size);


System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameUsuariosPorNombre (string nombre);


void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs);

void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs);

void AsignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs);

void DesasignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs);
}
}
