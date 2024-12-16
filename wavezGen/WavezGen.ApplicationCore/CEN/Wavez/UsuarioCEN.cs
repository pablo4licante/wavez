

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using Newtonsoft.Json;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public void Seguir (string p_Usuario_OID, System.Collections.Generic.IList<string> p_usuarioSeguidos_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.Seguir (p_Usuario_OID, p_usuarioSeguidos_OIDs);
}
public void DejarDeSeguir (string p_Usuario_OID, System.Collections.Generic.IList<string> p_usuarioSeguidos_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DejarDeSeguir (p_Usuario_OID, p_usuarioSeguidos_OIDs);
}
public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Contrasenya.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Usuario);

        return result;
}

public string Nuevo (string p_usuario, string p_nombre, String p_contrasenya, string p_email, string p_fotoPerfil)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Usuario = p_usuario;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Email = p_email;

        usuarioEN.FotoPerfil = p_fotoPerfil;



        oid = _IUsuarioRepository.Nuevo (usuarioEN);
        return oid;
}

public void Modificar (string p_Usuario_OID, string p_nombre, String p_contrasenya, string p_email, string p_fotoPerfil)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Usuario = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;


        //usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        // Si la contraseña ya está codificada (ejemplo, longitud de un hash MD5 es 32 caracteres hexadecimales), no la codifiques de nuevo
        if (!string.IsNullOrEmpty(p_contrasenya) && p_contrasenya.Length != 32)
        {
            usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5(p_contrasenya);
        }
        else
        {
            usuarioEN.Contrasenya = p_contrasenya; // Mantener la contraseña tal cual si ya está codificada
        }


            usuarioEN.Email = p_email;
        usuarioEN.FotoPerfil = p_fotoPerfil;
        //Call to UsuarioRepository

        _IUsuarioRepository.Modificar (usuarioEN);
}

public void Eliminar (string usuario
                      )
{
        _IUsuarioRepository.Eliminar (usuario);
}

public UsuarioEN DameUsuarioPorOID (string usuario
                                    )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.DameUsuarioPorOID (usuario);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.DameTodosLosUsuarios (first, size);
        return list;
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameUsuariosPorNombre (string nombre)
{
        return _IUsuarioRepository.DameUsuariosPorNombre (nombre);
}
public void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.AsignarComunidad (p_Usuario_OID, p_comunidad_OIDs);
}
public void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DesasignarComunidad (p_Usuario_OID, p_comunidad_OIDs);
}
public void AsignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.AsignarPlaylist (p_Usuario_OID, p_playlistGuardada_OIDs);
}
public void DesasignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DesasignarPlaylist (p_Usuario_OID, p_playlistGuardada_OIDs);
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameMisCanciones ()
{
        return _IUsuarioRepository.DameMisCanciones ();
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameMisPlaylists ()
{
        return _IUsuarioRepository.DameMisPlaylists ();
}



private string Encode (string usuario)
{
        var payload = new Dictionary<string, object>(){
                { "usuario", usuario }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string usuario)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (usuario);
        string token = Encode (en.Usuario);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerUSUARIO (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((string)en.Usuario).Equals (ObtenerUSUARIO (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerUSUARIO (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string usuario = (string)results ["usuario"];
                return usuario;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
