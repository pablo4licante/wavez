
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IComunidadRepository
{
void setSessionCP (GenericSessionCP session);

ComunidadEN ReadOIDDefault (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                            );

void ModifyDefault (ComunidadEN comunidad);

System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size);




WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum Nuevo (ComunidadEN comunidad);

void Modificar (ComunidadEN comunidad);


void Eliminar (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
               );


ComunidadEN DameComunidadPorOID (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                                 );


System.Collections.Generic.IList<ComunidadEN> DameTodasLasComunidades (int first, int size);


void AsignarUsuario (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void DesasignarUsuario (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);
}
}
