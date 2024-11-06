
using System;
// Definición clase NotificacionEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo comunidad
 */
private WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidad;



/**
 *	Atributo usuariosReceptores
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuariosReceptores;



/**
 *	Atributo usuarioPublicador
 */
private WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioPublicador;



/**
 *	Atributo contieneCancion
 */
private WavezGen.ApplicationCore.EN.Wavez.CancionEN contieneCancion;



/**
 *	Atributo contienePlaylist
 */
private WavezGen.ApplicationCore.EN.Wavez.PlaylistEN contienePlaylist;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> UsuariosReceptores {
        get { return usuariosReceptores; } set { usuariosReceptores = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.UsuarioEN UsuarioPublicador {
        get { return usuarioPublicador; } set { usuarioPublicador = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.CancionEN ContieneCancion {
        get { return contieneCancion; } set { contieneCancion = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.PlaylistEN ContienePlaylist {
        get { return contienePlaylist; } set { contienePlaylist = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public NotificacionEN()
{
        usuariosReceptores = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
}



public NotificacionEN(int id, string foto, string mensaje, WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuariosReceptores, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioPublicador, WavezGen.ApplicationCore.EN.Wavez.CancionEN contieneCancion, WavezGen.ApplicationCore.EN.Wavez.PlaylistEN contienePlaylist, Nullable<DateTime> fecha
                      )
{
        this.init (Id, foto, mensaje, comunidad, usuariosReceptores, usuarioPublicador, contieneCancion, contienePlaylist, fecha);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.Foto, notificacion.Mensaje, notificacion.Comunidad, notificacion.UsuariosReceptores, notificacion.UsuarioPublicador, notificacion.ContieneCancion, notificacion.ContienePlaylist, notificacion.Fecha);
}

private void init (int id
                   , string foto, string mensaje, WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuariosReceptores, WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioPublicador, WavezGen.ApplicationCore.EN.Wavez.CancionEN contieneCancion, WavezGen.ApplicationCore.EN.Wavez.PlaylistEN contienePlaylist, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Foto = foto;

        this.Mensaje = mensaje;

        this.Comunidad = comunidad;

        this.UsuariosReceptores = usuariosReceptores;

        this.UsuarioPublicador = usuarioPublicador;

        this.ContieneCancion = contieneCancion;

        this.ContienePlaylist = contienePlaylist;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
