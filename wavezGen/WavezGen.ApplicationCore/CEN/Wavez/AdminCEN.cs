

using System;
using System.Text;
using System.Collections.Generic;

using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;


namespace WavezGen.ApplicationCore.CEN.Wavez
{
/*
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminRepository _IAdminRepository;

public AdminCEN(IAdminRepository _IAdminRepository)
{
        this._IAdminRepository = _IAdminRepository;
}

public IAdminRepository get_IAdminRepository ()
{
        return this._IAdminRepository;
}

public string Nuevo (string p_usuario, string p_nombre, String p_contrasenya, string p_email, string p_fotoPerfil)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Usuario = p_usuario;

        adminEN.Nombre = p_nombre;

        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        adminEN.Email = p_email;

        adminEN.FotoPerfil = p_fotoPerfil;



        oid = _IAdminRepository.Nuevo (adminEN);
        return oid;
}

public void Modificar (string p_Admin_OID, string p_nombre, String p_contrasenya, string p_email, string p_fotoPerfil)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Usuario = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        adminEN.Email = p_email;
        adminEN.FotoPerfil = p_fotoPerfil;
        //Call to AdminRepository

        _IAdminRepository.Modificar (adminEN);
}

public void Eliminar (string usuario
                      )
{
        _IAdminRepository.Eliminar (usuario);
}

public AdminEN DameAdminPorOID (string usuario
                                )
{
        AdminEN adminEN = null;

        adminEN = _IAdminRepository.DameAdminPorOID (usuario);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> DameTodosLosAdmin (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminRepository.DameTodosLosAdmin (first, size);
        return list;
}
}
}
