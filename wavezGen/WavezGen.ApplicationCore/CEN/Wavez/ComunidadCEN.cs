

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class ComunidadCEN
 *
 */
public partial class ComunidadCEN
{
private IComunidadRepository _IComunidadRepository;

public ComunidadCEN(IComunidadRepository _IComunidadRepository)
{
        this._IComunidadRepository = _IComunidadRepository;
}

public IComunidadRepository get_IComunidadRepository ()
{
        return this._IComunidadRepository;
}

public WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum Nuevo (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_genero)
{
        ComunidadEN comunidadEN = null;

        WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum oid;
        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Genero = p_genero;



        oid = _IComunidadRepository.Nuevo (comunidadEN);
        return oid;
}

public void Modificar (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_Comunidad_OID)
{
        ComunidadEN comunidadEN = null;

        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Genero = p_Comunidad_OID;
        //Call to ComunidadRepository

        _IComunidadRepository.Modificar (comunidadEN);
}

public void Eliminar (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                      )
{
        _IComunidadRepository.Eliminar (genero);
}

public ComunidadEN DameComunidadPorOID (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                                        )
{
        ComunidadEN comunidadEN = null;

        comunidadEN = _IComunidadRepository.DameComunidadPorOID (genero);
        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> DameTodasLasComunidades (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> list = null;

        list = _IComunidadRepository.DameTodasLasComunidades (first, size);
        return list;
}
}
}
