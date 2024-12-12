
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
 * Clase Admin:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class AdminRepository : BasicRepository, IAdminRepository
{
public AdminRepository() : base ()
{
}


public AdminRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AdminEN ReadOIDDefault (string usuario
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminNH), usuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminNH)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), admin.Usuario);
                session.Update (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Nuevo (AdminEN admin)
{
        AdminNH adminNH = new AdminNH (admin);

        try
        {
                SessionInitializeTransaction ();

                session.Save (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminNH.Usuario;
}

public void Modificar (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), admin.Usuario);

                adminNH.Nombre = admin.Nombre;


                adminNH.Contrasenya = admin.Contrasenya;


                adminNH.Email = admin.Email;


                adminNH.FotoPerfil = admin.FotoPerfil;

                session.Update (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
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
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), usuario);
                session.Delete (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameAdminPorOID
//Con e: AdminEN
public AdminEN DameAdminPorOID (string usuario
                                )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminNH), usuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> DameTodosLosAdmin (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdminNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                else
                        result = session.CreateCriteria (typeof(AdminNH)).List<AdminEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
