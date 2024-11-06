
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
 * Clase Cancion:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class CancionRepository : BasicRepository, ICancionRepository
{
        public CancionRepository() : base ()
        {
        }


        public CancionRepository(GenericSessionCP sessionAux) : base (sessionAux)
        {
        }


        public void setSessionCP (GenericSessionCP session)
        {
                sessionInside = false;
                this.session = (ISession)session.CurrentSession;
        }


        public CancionEN ReadOIDDefault (int id
                                         )
        {
                CancionEN cancionEN = null;

                try
                {
                        SessionInitializeTransaction ();
                        cancionEN = (CancionEN)session.Get (typeof(CancionNH), id);
                        SessionCommit ();
                }

                catch (Exception) {
                }


                finally
                {
                        SessionClose ();
                }

                return cancionEN;
        }

        public System.Collections.Generic.IList<CancionEN> ReadAllDefault (int first, int size)
        {
                System.Collections.Generic.IList<CancionEN> result = null;
                try
                {
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                if (size > 0)
                                        result = session.CreateCriteria (typeof(CancionNH)).
                                                 SetFirstResult (first).SetMaxResults (size).List<CancionEN>();
                                else
                                        result = session.CreateCriteria (typeof(CancionNH)).List<CancionEN>();
                        }
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
                }

                return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault (CancionEN cancion)
        {
                try
                {
                        SessionInitializeTransaction ();
                        CancionNH cancionNH = (CancionNH)session.Load (typeof(CancionNH), cancion.Id);

                        cancionNH.Titulo = cancion.Titulo;


                        cancionNH.Genero = cancion.Genero;


                        cancionNH.Any = cancion.Any;


                        cancionNH.FotoPortada = cancion.FotoPortada;








                        cancionNH.NumReproducciones = cancion.NumReproducciones;


                        session.Update (cancionNH);
                        SessionCommit ();
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
                }


                finally
                {
                        SessionClose ();
                }
        }


        public int Nuevo (CancionEN cancion)
        {
                CancionNH cancionNH = new CancionNH (cancion);

                try
                {
                        SessionInitializeTransaction ();
                        if (cancion.Autor != null) {
                                // Argumento OID y no colección.
                                cancionNH
                                .Autor = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.ApplicationCore.EN.Wavez.UsuarioEN), cancion.Autor.Usuario);

                                cancionNH.Autor.PublicaCancion
                                .Add (cancionNH);
                        }

                        session.Save (cancionNH);
                        SessionCommit ();
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
                }


                finally
                {
                        SessionClose ();
                }

                return cancionNH.Id;
        }

        public void Modificar (CancionEN cancion)
        {
                try
                {
                        SessionInitializeTransaction ();
                        CancionNH cancionNH = (CancionNH)session.Load (typeof(CancionNH), cancion.Id);

                        cancionNH.Titulo = cancion.Titulo;


                        cancionNH.Genero = cancion.Genero;


                        cancionNH.Any = cancion.Any;


                        cancionNH.FotoPortada = cancion.FotoPortada;


                        cancionNH.NumReproducciones = cancion.NumReproducciones;

                        session.Update (cancionNH);
                        SessionCommit ();
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
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
                        CancionNH cancionNH = (CancionNH)session.Load (typeof(CancionNH), id);
                        session.Delete (cancionNH);
                        SessionCommit ();
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
                }


                finally
                {
                        SessionClose ();
                }
        }

        //Sin e: DameCancionPorOID
        //Con e: CancionEN
        public CancionEN DameCancionPorOID (int id
                                            )
        {
                CancionEN cancionEN = null;

                try
                {
                        SessionInitializeTransaction ();
                        cancionEN = (CancionEN)session.Get (typeof(CancionNH), id);
                        SessionCommit ();
                }

                catch (Exception) {
                }


                finally
                {
                        SessionClose ();
                }

                return cancionEN;
        }

        public System.Collections.Generic.IList<CancionEN> DameTodasLasCanciones (int first, int size)
        {
                System.Collections.Generic.IList<CancionEN> result = null;
                try
                {
                        SessionInitializeTransaction ();
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CancionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CancionEN>();
                        else
                                result = session.CreateCriteria (typeof(CancionNH)).List<CancionEN>();
                        SessionCommit ();
                }

                catch (Exception ex) {
                        SessionRollBack ();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                                throw;
                        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in CancionRepository.", ex);
                }


                finally
                {
                        SessionClose ();
                }

                return result;
        }

        public System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> DameCancionesPorNombre (string nombre)
        {
                System.Collections.Generic.IList<WavezGen.ApplicationCore.EN.Wavez.CancionEN> result;
                try
                {
                        SessionInitializeTransaction ();
                        //String sql = @"FROM CancionNH self where SELECT cancion FROM CancionNH as cancion WHERE cancion.Titulo LIKE :";
	                                        //IQuery query = session.CreateQuery(sql);
	                                        IQuery query = (IQuery)session.GetNamedQuery("CancionNHdameCancionesPorNombreHQL                                             ");
	                                                query.SetParameter("nombre ",nombre);
	
	                                        result= query.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
							SessionCommit();
					}
					
catch (Exception ex) {
SessionRollBack();
if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
	throw;
else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException("Error in CancionRepository.",ex);
}

					
finally
{
	SessionClose();
}

					return result;
					}
				
			
		    }
		}
