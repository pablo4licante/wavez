
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


/*
 * Clase Comunidad:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class ComunidadRepository : BasicRepository, IComunidadRepository
{
public ComunidadRepository() : base ()
{
}


public ComunidadRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComunidadEN ReadOIDDefault (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                                   )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadNH), genero);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComunidadNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                        else
                                result = session.CreateCriteria (typeof(ComunidadNH)).List<ComunidadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), comunidad.Genero);



                session.Update (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum Nuevo (ComunidadEN comunidad)
{
        ComunidadNH comunidadNH = new ComunidadNH (comunidad);

        try
        {
                SessionInitializeTransaction ();

                session.Save (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidadNH.Genero;
}

public void Modificar (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), comunidad.Genero);
                session.Update (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                      )
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), genero);
                session.Delete (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameComunidadPorOID
//Con e: ComunidadEN
public ComunidadEN DameComunidadPorOID (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum genero
                                        )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadNH), genero);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> DameTodasLasComunidades (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComunidadNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                else
                        result = session.CreateCriteria (typeof(ComunidadNH)).List<ComunidadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarUsuario (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidadEN = null;
        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadNH), p_Comunidad_OID);
                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario == null) {
                        comunidadEN.Usuario = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new WavezGen.ApplicationCore.EN.Wavez.UsuarioEN ();
                        usuarioENAux = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.UsuarioNH), item);
                        usuarioENAux.Comunidad.Add (comunidadEN);

                        comunidadEN.Usuario.Add (usuarioENAux);
                }


                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarUsuario (WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.ComunidadEN comunidadEN = null;
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadNH), p_Comunidad_OID);

                WavezGen.ApplicationCore.EN.Wavez.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.UsuarioNH), item);
                                if (comunidadEN.Usuario.Contains (usuarioENAux) == true) {
                                        comunidadEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Comunidad.Remove (comunidadEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in ComunidadEN");
                        }
                }

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
