

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class CancionCEN
 *
 */
public partial class CancionCEN
{
private ICancionRepository _ICancionRepository;

public CancionCEN(ICancionRepository _ICancionRepository)
{
        this._ICancionRepository = _ICancionRepository;
}

public ICancionRepository get_ICancionRepository ()
{
        return this._ICancionRepository;
}

public int Nuevo (string p_titulo, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_genero, Nullable<DateTime> p_any, string p_fotoPortada, string p_autor, int p_numReproducciones)
{
        CancionEN cancionEN = null;
        int oid;

        //Initialized CancionEN
        cancionEN = new CancionEN ();
        cancionEN.Titulo = p_titulo;

        cancionEN.Genero = p_genero;

        cancionEN.Any = p_any;

        cancionEN.FotoPortada = p_fotoPortada;


        if (p_autor != null) {
                // El argumento p_autor -> Property autor es oid = false
                // Lista de oids id
                cancionEN.Autor = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                cancionEN.Autor.Usuario = p_autor;
        }

        cancionEN.NumReproducciones = p_numReproducciones;



        oid = _ICancionRepository.Nuevo (cancionEN);
        return oid;
}

public void Modificar (int p_Cancion_OID, string p_titulo, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_genero, Nullable<DateTime> p_any, string p_fotoPortada, int p_numReproducciones)
{
        CancionEN cancionEN = null;

        //Initialized CancionEN
        cancionEN = new CancionEN ();
        cancionEN.Id = p_Cancion_OID;
        cancionEN.Titulo = p_titulo;
        cancionEN.Genero = p_genero;
        cancionEN.Any = p_any;
        cancionEN.FotoPortada = p_fotoPortada;
        cancionEN.NumReproducciones = p_numReproducciones;
        //Call to CancionRepository

        _ICancionRepository.Modificar (cancionEN);
}

public void Eliminar (int id
                      )
{
        _ICancionRepository.Eliminar (id);
}

public CancionEN DameCancionPorOID (int id
                                    )
{
        CancionEN cancionEN = null;

        cancionEN = _ICancionRepository.DameCancionPorOID (id);
        return cancionEN;
}

public System.Collections.Generic.IList<CancionEN> DameTodasLasCanciones (int first, int size)
{
        System.Collections.Generic.IList<CancionEN> list = null;

        list = _ICancionRepository.DameTodasLasCanciones (first, size);
        return list;
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> DameCancionesPorNombre (string nombre)
{
        return _ICancionRepository.DameCancionesPorNombre (nombre);
}
}
}
