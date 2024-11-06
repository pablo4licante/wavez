

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class ColaReprodCEN
 *
 */
public partial class ColaReprodCEN
{
private IColaReprodRepository _IColaReprodRepository;

public ColaReprodCEN(IColaReprodRepository _IColaReprodRepository)
{
        this._IColaReprodRepository = _IColaReprodRepository;
}

public IColaReprodRepository get_IColaReprodRepository ()
{
        return this._IColaReprodRepository;
}

public int Nuevo (string p_usuario)
{
        ColaReprodEN colaReprodEN = null;
        int oid;

        //Initialized ColaReprodEN
        colaReprodEN = new ColaReprodEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                colaReprodEN.Usuario = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                colaReprodEN.Usuario.Usuario = p_usuario;
        }



        oid = _IColaReprodRepository.Nuevo (colaReprodEN);
        return oid;
}

public void Modificar (int p_ColaReprod_OID)
{
        ColaReprodEN colaReprodEN = null;

        //Initialized ColaReprodEN
        colaReprodEN = new ColaReprodEN ();
        colaReprodEN.Id = p_ColaReprod_OID;
        //Call to ColaReprodRepository

        _IColaReprodRepository.Modificar (colaReprodEN);
}

public void Eliminar (int id
                      )
{
        _IColaReprodRepository.Eliminar (id);
}

public ColaReprodEN DameColaPorOID (int id
                                    )
{
        ColaReprodEN colaReprodEN = null;

        colaReprodEN = _IColaReprodRepository.DameColaPorOID (id);
        return colaReprodEN;
}

public System.Collections.Generic.IList<ColaReprodEN> DameTodasLasColas (int first, int size)
{
        System.Collections.Generic.IList<ColaReprodEN> list = null;

        list = _IColaReprodRepository.DameTodasLasColas (first, size);
        return list;
}
public void AgregarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        //Call to ColaReprodRepository

        _IColaReprodRepository.AgregarCancion (p_ColaReprod_OID, p_cancion_OIDs);
}
public void QuitarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        //Call to ColaReprodRepository

        _IColaReprodRepository.QuitarCancion (p_ColaReprod_OID, p_cancion_OIDs);
}
}
}
