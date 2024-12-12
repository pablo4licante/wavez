
using System;
// Definición clase ComunidadEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class ComunidadEN
{
/**
 *	Atributo genero
 */
private WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario;



/**
 *	Atributo cancion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion;






public virtual WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> Cancion {
        get { return cancion; } set { cancion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}





public ComunidadEN()
{
        usuario = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
        cancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
        notificacion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN>();
}



public ComunidadEN(WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion
                   )
{
        this.init (Genero, usuario, cancion, notificacion);
}


public ComunidadEN(ComunidadEN comunidad)
{
        this.init (comunidad.Genero, comunidad.Usuario, comunidad.Cancion, comunidad.Notificacion);
}

private void init (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                   , System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion)
{
        this.Genero = genero;


        this.Usuario = usuario;

        this.Cancion = cancion;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComunidadEN t = obj as ComunidadEN;
        if (t == null)
                return false;
        if (Genero.Equals (t.Genero))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Genero.GetHashCode ();
        return hash;
}
}
}
