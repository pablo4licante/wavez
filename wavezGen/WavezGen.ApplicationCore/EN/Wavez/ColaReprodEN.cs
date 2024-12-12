
using System;
// Definición clase ColaReprodEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class ColaReprodEN
{
/**
 *	Atributo cancion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario;






public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> Cancion {
        get { return cancion; } set { cancion = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ColaReprodEN()
{
        cancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
}



public ColaReprodEN(int id, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario
                    )
{
        this.init (Id, cancion, usuario);
}


public ColaReprodEN(ColaReprodEN colaReprod)
{
        this.init (colaReprod.Id, colaReprod.Cancion, colaReprod.Usuario);
}

private void init (int id
                   , System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuario)
{
        this.Id = id;


        this.Cancion = cancion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ColaReprodEN t = obj as ColaReprodEN;
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
