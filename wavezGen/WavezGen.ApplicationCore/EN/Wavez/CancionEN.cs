
using System;
// Definición clase CancionEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class CancionEN
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
 *	Atributo genero
 */
private WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo fotoPortada
 */
private string fotoPortada;



/**
 *	Atributo comunidad
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion;



/**
 *	Atributo colaReprod
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN> colaReprod;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario;



/**
 *	Atributo autor
 */
private WavezGen.ApplicationCore.EN.Wavez.UsuarioEN autor;



/**
 *	Atributo playlist
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlist;



/**
 *	Atributo numReproducciones
 */
private int numReproducciones;



/**
 *	Atributo usuarioCompatidor
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioCompatidor;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string FotoPortada {
        get { return fotoPortada; } set { fotoPortada = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN> ColaReprod {
        get { return colaReprod; } set { colaReprod = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.UsuarioEN Autor {
        get { return autor; } set { autor = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> Playlist {
        get { return playlist; } set { playlist = value;  }
}



public virtual int NumReproducciones {
        get { return numReproducciones; } set { numReproducciones = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> UsuarioCompatidor {
        get { return usuarioCompatidor; } set { usuarioCompatidor = value;  }
}





public CancionEN()
{
        comunidad = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN>();
        notificacion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN>();
        colaReprod = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN>();
        comentario = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN>();
        playlist = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN>();
        usuarioCompatidor = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
}



public CancionEN(int id, string titulo, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero, Nullable<DateTime> fecha, string fotoPortada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN> colaReprod, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN autor, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlist, int numReproducciones, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioCompatidor
                 )
{
        this.init (Id, titulo, genero, fecha, fotoPortada, comunidad, notificacion, colaReprod, comentario, autor, playlist, numReproducciones, usuarioCompatidor);
}


public CancionEN(CancionEN cancion)
{
        this.init (cancion.Id, cancion.Titulo, cancion.Genero, cancion.Fecha, cancion.FotoPortada, cancion.Comunidad, cancion.Notificacion, cancion.ColaReprod, cancion.Comentario, cancion.Autor, cancion.Playlist, cancion.NumReproducciones, cancion.UsuarioCompatidor);
}

private void init (int id
                   , string titulo, WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero, Nullable<DateTime> fecha, string fotoPortada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> notificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN> colaReprod, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN autor, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlist, int numReproducciones, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioCompatidor)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Genero = genero;

        this.Fecha = fecha;

        this.FotoPortada = fotoPortada;

        this.Comunidad = comunidad;

        this.Notificacion = notificacion;

        this.ColaReprod = colaReprod;

        this.Comentario = comentario;

        this.Autor = autor;

        this.Playlist = playlist;

        this.NumReproducciones = numReproducciones;

        this.UsuarioCompatidor = usuarioCompatidor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CancionEN t = obj as CancionEN;
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
