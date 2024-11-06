
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IComentarioRepository
{
void setSessionCP (GenericSessionCP session);

ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);




int Nuevo (ComentarioEN comentario);

void Modificar (ComentarioEN comentario);


void Eliminar (int id
               );


ComentarioEN DameComentarioPorOID (int id
                                   );


System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size);


System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> DameComentariosFiltrado ();
}
}
