

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioRepository _IComentarioRepository;

public ComentarioCEN(IComentarioRepository _IComentarioRepository)
{
        this._IComentarioRepository = _IComentarioRepository;
}

public IComentarioRepository get_IComentarioRepository ()
{
        return this._IComentarioRepository;
}

public int Nuevo (string p_texto, int p_cancion, string p_usuario)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Texto = p_texto;


        if (p_cancion != -1) {
                // El argumento p_cancion -> Property cancion es oid = false
                // Lista de oids id
                comentarioEN.Cancion = new WavezGen.ApplicationCore.EN.Wavez.CancionEN ();
                comentarioEN.Cancion.Id = p_cancion;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                comentarioEN.Usuario.Usuario = p_usuario;
        }



        oid = _IComentarioRepository.Nuevo (comentarioEN);
        return oid;
}

public void Modificar (int p_Comentario_OID, string p_texto)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Texto = p_texto;
        //Call to ComentarioRepository

        _IComentarioRepository.Modificar (comentarioEN);
}

public void Eliminar (int id
                      )
{
        _IComentarioRepository.Eliminar (id);
}

public ComentarioEN DameComentarioPorOID (int id
                                          )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioRepository.DameComentarioPorOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioRepository.DameTodosLosComentarios (first, size);
        return list;
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> DameComentariosDeCancion (int ? cancion_OID)
{
        return _IComentarioRepository.DameComentariosDeCancion (cancion_OID);
}
}
}
