
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
 * Clase Comentario:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class ComentarioRepository : BasicRepository, IComentarioRepository
{
public ComentarioRepository() : base ()
{
}


public ComentarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComentarioEN ReadOIDDefault (int id
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.Texto = comentario.Texto;



                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ComentarioEN comentario)
{
        ComentarioNH comentarioNH = new ComentarioNH (comentario);

        try
        {
                SessionInitializeTransaction ();
                if (comentario.Cancion != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Cancion = (WavezGen.ApplicationCore.EN.Wavez.CancionEN)session.Load (typeof(WavezGen.ApplicationCore.EN.Wavez.CancionEN), comentario.Cancion.Id);

                        comentarioNH.Cancion.Comentario
                        .Add (comentarioNH);
                }
                if (comentario.Usuario != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Usuario = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.ApplicationCore.EN.Wavez.UsuarioEN), comentario.Usuario.Usuario);

                        comentarioNH.Usuario.Comentario
                        .Add (comentarioNH);
                }

                session.Save (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioNH.Id;
}

public void Modificar (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.Texto = comentario.Texto;

                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
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
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), id);
                session.Delete (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameComentarioPorOID
//Con e: ComentarioEN
public ComentarioEN DameComentarioPorOID (int id
                                          )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> DameComentariosDeCancion (int ? cancion_OID)
{
        System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioNH self where SELECT comentario FROM ComentarioNH as comentario inner join comentario.Cancion as cancion WHERE cancion.Id  :cancion_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioNHdameComentariosDeCancionHQL");
                query.SetParameter ("cancion_OID", cancion_OID);

                result = query.List<WavezGen.ApplicationCore.EN.Wavez.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
