
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IColaReprodRepository
{
void setSessionCP (GenericSessionCP session);

ColaReprodEN ReadOIDDefault (int id
                             );

void ModifyDefault (ColaReprodEN colaReprod);

System.Collections.Generic.IList<ColaReprodEN> ReadAllDefault (int first, int size);





int Nuevo (ColaReprodEN colaReprod);

void Modificar (ColaReprodEN colaReprod);


void Eliminar (int id
               );


ColaReprodEN DameColaPorOID (int id
                             );


System.Collections.Generic.IList<ColaReprodEN> DameTodasLasColas (int first, int size);


void AgregarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs);

void QuitarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs);
}
}
