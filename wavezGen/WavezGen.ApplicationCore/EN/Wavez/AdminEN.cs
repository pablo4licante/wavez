
using System;
// Definición clase AdminEN
namespace WavezGen.ApplicationCore.EN.Wavez
{
public partial class AdminEN                                                                        : WavezGen.ApplicationCore.EN.Wavez.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(string usuario,
               string nombre, String contrasenya, string email, string fotoPerfil, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> recibeNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> mandaNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> publicaCancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioSeguidos, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistCreada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistGuardada, WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprod
               )
{
        this.init (Usuario, nombre, contrasenya, email, fotoPerfil, comunidad, recibeNotificacion, mandaNotificacion, comentario, publicaCancion, usuarioSeguidos, playlistCreada, playlistGuardada, colaReprod);
}


public AdminEN(AdminEN admin)
{
        this.init (admin.Usuario, admin.Nombre, admin.Contrasenya, admin.Email, admin.FotoPerfil, admin.Comunidad, admin.RecibeNotificacion, admin.MandaNotificacion, admin.Comentario, admin.PublicaCancion, admin.UsuarioSeguidos, admin.PlaylistCreada, admin.PlaylistGuardada, admin.ColaReprod);
}

private void init (string usuario
                   , string nombre, String contrasenya, string email, string fotoPerfil, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN> comunidad, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> recibeNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.NotificacionEN> mandaNotificacion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> comentario, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> publicaCancion, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> usuarioSeguidos, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistCreada, System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN> playlistGuardada, WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprod)
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
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
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
