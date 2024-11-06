
using System;
// Definición clase ComentarioEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo cancion
 */
private WavezGen.ApplicationCore.EN.Wavez.CancionEN cancion;



/**
 *	Atributo usuario
 */
private WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.CancionEN Cancion {
        get { return cancion; } set { cancion = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string texto, WavezGen.ApplicationCore.EN.Wavez.CancionEN cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario
                    )
{
        this.init (Id, texto, cancion, usuario);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (comentario.Id, comentario.Texto, comentario.Cancion, comentario.Usuario);
}

private void init (int id
                   , string texto, WavezGen.ApplicationCore.EN.Wavez.CancionEN cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario)
{
        this.Id = id;


        this.Texto = texto;

        this.Cancion = cancion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
