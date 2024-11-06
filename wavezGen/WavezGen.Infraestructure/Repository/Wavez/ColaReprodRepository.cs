
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
 * Clase ColaReprod:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class ColaReprodRepository : BasicRepository, IColaReprodRepository
{
public ColaReprodRepository() : base ()
{
}


public ColaReprodRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ColaReprodEN ReadOIDDefault (int id
                                    )
{
        ColaReprodEN colaReprodEN = null;

        try
        {
                SessionInitializeTransaction ();
                colaReprodEN = (ColaReprodEN)session.Get (typeof(ColaReprodNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return colaReprodEN;
}

public System.Collections.Generic.IList<ColaReprodEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ColaReprodEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ColaReprodNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ColaReprodEN>();
                        else
                                result = session.CreateCriteria (typeof(ColaReprodNH)).List<ColaReprodEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ColaReprodEN colaReprod)
{
        try
        {
                SessionInitializeTransaction ();
                ColaReprodNH colaReprodNH = (ColaReprodNH)session.Load (typeof(ColaReprodNH), colaReprod.Id);


                session.Update (colaReprodNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ColaReprodEN colaReprod)
{
        ColaReprodNH colaReprodNH = new ColaReprodNH (colaReprod);

        try
        {
                SessionInitializeTransaction ();
                if (colaReprod.Usuario != null) {
                        // Argumento OID y no colección.
                        colaReprodNH
                        .Usuario = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.ApplicationCore.EN.Wavez.UsuarioEN), colaReprod.Usuario.Usuario);

                        colaReprodNH.Usuario.ColaReprod
                                = colaReprodNH;
                }

                session.Save (colaReprodNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return colaReprodNH.Id;
}

public void Modificar (ColaReprodEN colaReprod)
{
        try
        {
                SessionInitializeTransaction ();
                ColaReprodNH colaReprodNH = (ColaReprodNH)session.Load (typeof(ColaReprodNH), colaReprod.Id);
                session.Update (colaReprodNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                ColaReprodNH colaReprodNH = (ColaReprodNH)session.Load (typeof(ColaReprodNH), id);
                session.Delete (colaReprodNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameColaPorOID
//Con e: ColaReprodEN
public ColaReprodEN DameColaPorOID (int id
                                    )
{
        ColaReprodEN colaReprodEN = null;

        try
        {
                SessionInitializeTransaction ();
                colaReprodEN = (ColaReprodEN)session.Get (typeof(ColaReprodNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return colaReprodEN;
}

public System.Collections.Generic.IList<ColaReprodEN> DameTodasLasColas (int first, int size)
{
        System.Collections.Generic.IList<ColaReprodEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ColaReprodNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ColaReprodEN>();
                else
                        result = session.CreateCriteria (typeof(ColaReprodNH)).List<ColaReprodEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AgregarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprodEN = null;
        try
        {
                SessionInitializeTransaction ();
                colaReprodEN = (ColaReprodEN)session.Load (typeof(ColaReprodNH), p_ColaReprod_OID);
                WavezGen.ApplicationCore.EN.Wavez.CancionEN cancionENAux = null;
                if (colaReprodEN.Cancion == null) {
                        colaReprodEN.Cancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
                }

                foreach (int item in p_cancion_OIDs) {
                        cancionENAux = new WavezGen.ApplicationCore.EN.Wavez.CancionEN ();
                        cancionENAux = (WavezGen.ApplicationCore.EN.Wavez.CancionEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.CancionNH), item);
                        cancionENAux.ColaReprod.Add (colaReprodEN);

                        colaReprodEN.Cancion.Add (cancionENAux);
                }


                session.Update (colaReprodEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarCancion (int p_ColaReprod_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.ColaReprodEN colaReprodEN = null;
                colaReprodEN = (ColaReprodEN)session.Load (typeof(ColaReprodNH), p_ColaReprod_OID);

                WavezGen.ApplicationCore.EN.Wavez.CancionEN cancionENAux = null;
                if (colaReprodEN.Cancion != null) {
                        foreach (int item in p_cancion_OIDs) {
                                cancionENAux = (WavezGen.ApplicationCore.EN.Wavez.CancionEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.CancionNH), item);
                                if (colaReprodEN.Cancion.Contains (cancionENAux) == true) {
                                        colaReprodEN.Cancion.Remove (cancionENAux);
                                        cancionENAux.ColaReprod.Remove (colaReprodEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_cancion_OIDs you are trying to unrelationer, doesn't exist in ColaReprodEN");
                        }
                }

                session.Update (colaReprodEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColaReprodRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
