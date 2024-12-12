
using System;
// Definición clase UsuarioEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class UsuarioEN
{
/**
 *	Atributo usuario
 */
private string usuario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fotoPerfil
 */
private string fotoPerfil;



/**
 *	Atributo comunidad
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad;



/**
 *	Atributo recibeNotificacion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> recibeNotificacion;



/**
 *	Atributo mandaNotificacion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> mandaNotificacion;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario;



/**
 *	Atributo publicaCancion
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> publicaCancion;



/**
 *	Atributo usuarioSeguidos
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioSeguidos;



/**
 *	Atributo playlistCreada
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistCreada;



/**
 *	Atributo playlistGuardada
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistGuardada;



/**
 *	Atributo colaReprod
 */
private WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprod;



/**
 *	Atributo cancionCompartida
 */
private System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancionCompartida;






public virtual string Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string FotoPerfil {
        get { return fotoPerfil; } set { fotoPerfil = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> RecibeNotificacion {
        get { return recibeNotificacion; } set { recibeNotificacion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> MandaNotificacion {
        get { return mandaNotificacion; } set { mandaNotificacion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> PublicaCancion {
        get { return publicaCancion; } set { publicaCancion = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> UsuarioSeguidos {
        get { return usuarioSeguidos; } set { usuarioSeguidos = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> PlaylistCreada {
        get { return playlistCreada; } set { playlistCreada = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> PlaylistGuardada {
        get { return playlistGuardada; } set { playlistGuardada = value;  }
}



public virtual WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN ColaReprod {
        get { return colaReprod; } set { colaReprod = value;  }
}



public virtual System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> CancionCompartida {
        get { return cancionCompartida; } set { cancionCompartida = value;  }
}





public UsuarioEN()
{
        comunidad = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN>();
        recibeNotificacion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN>();
        mandaNotificacion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN>();
        comentario = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN>();
        publicaCancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
        usuarioSeguidos = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
        playlistCreada = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN>();
        playlistGuardada = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN>();
        cancionCompartida = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
}



public UsuarioEN(string usuario, string nombre, String contrasenya, string email, string fotoPerfil, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> recibeNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> mandaNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> publicaCancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioSeguidos, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistCreada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistGuardada, WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprod, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancionCompartida
                 )
{
        this.init (Usuario, nombre, contrasenya, email, fotoPerfil, comunidad, recibeNotificacion, mandaNotificacion, comentario, publicaCancion, usuarioSeguidos, playlistCreada, playlistGuardada, colaReprod, cancionCompartida);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Usuario, usuario.Nombre, usuario.Contrasenya, usuario.Email, usuario.FotoPerfil, usuario.Comunidad, usuario.RecibeNotificacion, usuario.MandaNotificacion, usuario.Comentario, usuario.PublicaCancion, usuario.UsuarioSeguidos, usuario.PlaylistCreada, usuario.PlaylistGuardada, usuario.ColaReprod, usuario.CancionCompartida);
}

private void init (string usuario
                   , string nombre, String contrasenya, string email, string fotoPerfil, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> recibeNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> mandaNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> publicaCancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioSeguidos, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistCreada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistGuardada, WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprod, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> cancionCompartida)
{
        this.Usuario = usuario;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Email = email;

        this.FotoPerfil = fotoPerfil;

        this.Comunidad = comunidad;

        this.RecibeNotificacion = recibeNotificacion;

        this.MandaNotificacion = mandaNotificacion;

        this.Comentario = comentario;

        this.PublicaCancion = publicaCancion;

        this.UsuarioSeguidos = usuarioSeguidos;

        this.PlaylistCreada = playlistCreada;

        this.PlaylistGuardada = playlistGuardada;

        this.ColaReprod = colaReprod;

        this.CancionCompartida = cancionCompartida;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Usuario.Equals (t.Usuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Usuario.GetHashCode ();
        return hash;
}
}
}
