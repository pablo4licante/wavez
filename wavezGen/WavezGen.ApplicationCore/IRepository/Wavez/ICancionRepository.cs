
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface ICancionRepository
{
void setSessionCP (GenericSessionCP session);

CancionEN ReadOIDDefault (int id
                          );

void ModifyDefault (CancionEN cancion);

System.Collections.Generic.IList<CancionEN> ReadAllDefault (int first, int size);






int Nuevo (CancionEN cancion);

void Modificar (CancionEN cancion);


void Eliminar (int id
               );


CancionEN DameCancionPorOID (int id
                             );


System.Collections.Generic.IList<CancionEN> DameTodasLasCanciones (int first, int size);


System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> DameCancionesPorNombre (string nombre);

System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> DameCancionesPorUsuario(string cancion_autor);

}
}
