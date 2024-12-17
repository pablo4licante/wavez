
using System;
using System.Text;
using WavezGen.ApplicationCore.CEN.Wavez;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CP.Wavez;
using WavezGen.Infraestructure.EN.Wavez;
using System.Diagnostics;
using System.Linq;


/*
 * Clase Usuario:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
{
public UsuarioRepository() : base ()
{
}


public UsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioEN ReadOIDDefault (string usuario
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), usuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Usuario);

                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.Contrasenya = usuario.Contrasenya;


                usuarioNH.Email = usuario.Email;


                usuarioNH.FotoPerfil = usuario.FotoPerfil;











                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Seguir (string p_Usuario_OID, System.Collections.Generic.IList<string> p_usuarioSeguidos_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioSeguidosENAux = null;
                if (usuarioEN.UsuarioSeguidos == null) {
                        usuarioEN.UsuarioSeguidos = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
                }

                foreach (string item in p_usuarioSeguidos_OIDs) {
                        usuarioSeguidosENAux = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                        usuarioSeguidosENAux = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.UsuarioNH), item);

                        usuarioEN.UsuarioSeguidos.Add (usuarioSeguidosENAux);
                }


                session.Update (usuarioEN);
                //Debug.WriteLine($"Usuario {usuarioEN.Usuario} ahora sigue a {string.Join(", ", usuarioEN.UsuarioSeguidos.Select(u => u.Usuario))}");

                SessionCommit();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DejarDeSeguir (string p_Usuario_OID, System.Collections.Generic.IList<string> p_usuarioSeguidos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioSeguidosENAux = null;
                if (usuarioEN.UsuarioSeguidos != null) {
                        foreach (string item in p_usuarioSeguidos_OIDs) {
                                usuarioSeguidosENAux = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.UsuarioNH), item);
                                if (usuarioEN.UsuarioSeguidos.Contains (usuarioSeguidosENAux) == true) {
                                        usuarioEN.UsuarioSeguidos.Remove (usuarioSeguidosENAux);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuarioSeguidos_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public string Nuevo (UsuarioEN usuario)
{
        UsuarioNH usuarioNH = new UsuarioNH (usuario);

        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioNH.Usuario;
}

public void Modificar (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Usuario);

                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.Contrasenya = usuario.Contrasenya;


                usuarioNH.Email = usuario.Email;


                usuarioNH.FotoPerfil = usuario.FotoPerfil;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (string usuario
                      )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario);
                session.Delete (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameUsuarioPorOID
//Con e: UsuarioEN
public UsuarioEN DameUsuarioPorOID (string usuario
                                    )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), usuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<UsuarioEN> DameUsuariosPorNombre(string nombre)
{
    System.Collections.Generic.IList<UsuarioEN> result;
    try
    {
        SessionInitializeTransaction();
        result = session.CreateCriteria(typeof(UsuarioNH))
                        .Add(Restrictions.Like("Nombre", nombre, MatchMode.Anywhere))
                        .List<UsuarioEN>();
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
            throw;
        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
    }
    finally
    {
        SessionClose();
    }
    return result;
}
public void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidadENAux = null;
                if (usuarioEN.Comunidad == null) {
                        usuarioEN.Comunidad = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.ComunidadEN>();
                }

                foreach (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum item in p_comunidad_OIDs) {
                        comunidadENAux = new WavezGen.ApplicationCore.EN.Wavez.ComunidadEN ();
                        comunidadENAux = (WavezGen.ApplicationCore.EN.Wavez.ComunidadEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.ComunidadNH), item);
                        comunidadENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Comunidad.Add (comunidadENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum> p_comunidad_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidadENAux = null;
                if (usuarioEN.Comunidad != null) {
                        foreach (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum item in p_comunidad_OIDs) {
                                comunidadENAux = (WavezGen.ApplicationCore.EN.Wavez.ComunidadEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.ComunidadNH), item);
                                if (usuarioEN.Comunidad.Contains (comunidadENAux) == true) {
                                        usuarioEN.Comunidad.Remove (comunidadENAux);
                                        comunidadENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comunidad_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                WavezGen.ApplicationCore.EN.Wavez.PlaylistEN playlistGuardadaENAux = null;
                if (usuarioEN.PlaylistGuardada == null) {
                        usuarioEN.PlaylistGuardada = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.PlaylistEN>();
                }

                foreach (int item in p_playlistGuardada_OIDs) {
                        playlistGuardadaENAux = new WavezGen.ApplicationCore.EN.Wavez.PlaylistEN ();
                        playlistGuardadaENAux = (WavezGen.ApplicationCore.EN.Wavez.PlaylistEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.PlaylistNH), item);
                        playlistGuardadaENAux.Usuario.Add (usuarioEN);

                        usuarioEN.PlaylistGuardada.Add (playlistGuardadaENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarPlaylist (string p_Usuario_OID, System.Collections.Generic.IList<int> p_playlistGuardada_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                WavezGen.ApplicationCore.EN.Wavez.PlaylistEN playlistGuardadaENAux = null;
                if (usuarioEN.PlaylistGuardada != null) {
                        foreach (int item in p_playlistGuardada_OIDs) {
                                playlistGuardadaENAux = (WavezGen.ApplicationCore.EN.Wavez.PlaylistEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.PlaylistNH), item);
                                if (usuarioEN.PlaylistGuardada.Contains (playlistGuardadaENAux) == true) {
                                        usuarioEN.PlaylistGuardada.Remove (playlistGuardadaENAux);
                                        playlistGuardadaENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_playlistGuardada_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameMisCanciones ()
{
        System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where SELECT cancion FROM UsuarioNH as usuario inner join usuario.PublicaCancion as cancion WHERE cancion.Autor = usuario.Usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHdameMisCancionesHQL");

                result = query.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> DameMisPlaylists ()
{
        System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where SELECT playlist FROM UsuarioNH as usuario inner join usuario.PlaylistCreada as playlist WHERE playlist.UsuarioCreador = usuario.Usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHdameMisPlaylistsHQL");

                result = query.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
