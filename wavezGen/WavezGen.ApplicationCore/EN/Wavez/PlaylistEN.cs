
using System;
// Definición clase PlaylistEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class PlaylistEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo portada
 */
private string portada;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion;



/**
 *	Atributo cancion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion;



/**
 *	Atributo usuarioCreador
 */
private WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioCreador;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Portada {
        get { return portada; } set { portada = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> Cancion {
        get { return cancion; } set { cancion = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.UsuarioEN UsuarioCreador {
        get { return usuarioCreador; } set { usuarioCreador = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public PlaylistEN()
{
        notificacion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN>();
        cancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
        usuario = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
}



public PlaylistEN(int id, string titulo, string portada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioCreador, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario
                  )
{
        this.init (Id, titulo, portada, notificacion, cancion, usuarioCreador, usuario);
}


public PlaylistEN(PlaylistEN playlist)
{
        this.init (playlist.Id, playlist.Titulo, playlist.Portada, playlist.Notificacion, playlist.Cancion, playlist.UsuarioCreador, playlist.Usuario);
}

private void init (int id
                   , string titulo, string portada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancion, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioCreador, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuario)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Portada = portada;

        this.Notificacion = notificacion;

        this.Cancion = cancion;

        this.UsuarioCreador = usuarioCreador;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlaylistEN t = obj as PlaylistEN;
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
