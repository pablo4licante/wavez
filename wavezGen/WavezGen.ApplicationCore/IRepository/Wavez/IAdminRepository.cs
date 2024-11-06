
using System;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public partial interface IAdminRepository
{
void setSessionCP (GenericSessionCP session);

AdminEN ReadOIDDefault (string usuario
                        );

void ModifyDefault (AdminEN admin);

System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size);







string Nuevo (AdminEN admin);

void Modificar (AdminEN admin);


void Eliminar (string usuario
               );


AdminEN DameAdminPorOID (string usuario
                         );


System.Collections.Generic.IList<AdminEN> DameTodosLosAdmin (int first, int size);
}
}
