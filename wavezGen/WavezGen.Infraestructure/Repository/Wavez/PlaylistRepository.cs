
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
using System.Linq;


/*
 * Clase Playlist:
 *
 */

namespace WavezGen.Infraestructure.Repository.Wavez
{
public partial class PlaylistRepository : BasicRepository, IPlaylistRepository
{
public PlaylistRepository() : base ()
{
}


public PlaylistRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PlaylistEN ReadOIDDefault (int id
                                  )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlaylistNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                        else
                                result = session.CreateCriteria (typeof(PlaylistNH)).List<PlaylistEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistNH playlistNH = (PlaylistNH)session.Load (typeof(PlaylistNH), playlist.Id);

                playlistNH.Titulo = playlist.Titulo;


                playlistNH.Portada = playlist.Portada;





                session.Update (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void QuitarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                WavezGen.ApplicationCore.EN.Wavez.PlaylistEN playlistEN = null;
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);

                WavezGen.ApplicationCore.EN.Wavez.CancionEN cancionENAux = null;
                if (playlistEN.Cancion != null) {
                        foreach (int item in p_cancion_OIDs) {
                                cancionENAux = (WavezGen.ApplicationCore.EN.Wavez.CancionEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.CancionNH), item);
                                if (playlistEN.Cancion.Contains (cancionENAux) == true) {
                                        playlistEN.Cancion.Remove (cancionENAux);
                                        cancionENAux.Playlist.Remove (playlistEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_cancion_OIDs you are trying to unrelationer, doesn't exist in PlaylistEN");
                        }
                }

                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_cancion_OIDs)
{
        WavezGen.ApplicationCore.EN.Wavez.PlaylistEN playlistEN = null;
        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);
                WavezGen.ApplicationCore.EN.Wavez.CancionEN cancionENAux = null;
                if (playlistEN.Cancion == null) {
                        playlistEN.Cancion = new System.Collections.Generic.List<WavezGen.ApplicationCore.EN.Wavez.CancionEN>();
                }

                foreach (int item in p_cancion_OIDs) {
                        cancionENAux = new WavezGen.ApplicationCore.EN.Wavez.CancionEN ();
                        cancionENAux = (WavezGen.ApplicationCore.EN.Wavez.CancionEN)session.Load (typeof(WavezGen.Infraestructure.EN.Wavez.CancionNH), item);
                        cancionENAux.Playlist.Add (playlistEN);

                        playlistEN.Cancion.Add (cancionENAux);
                }


                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int Nuevo (PlaylistEN playlist)
{
        PlaylistNH playlistNH = new PlaylistNH (playlist);

        try
        {
                SessionInitializeTransaction ();
                if (playlist.UsuarioCreador != null) {
                        // Argumento OID y no colección.
                        playlistNH
                        .UsuarioCreador = (WavezGen.ApplicationCore.EN.Wavez.UsuarioEN)session.Load (typeof(WavezGen.ApplicationCore.EN.Wavez.UsuarioEN), playlist.UsuarioCreador.Usuario);

                        playlistNH.UsuarioCreador.PlaylistCreada
                        .Add (playlistNH);
                }

                session.Save (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playlistNH.Id;
}

public void Modificar (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistNH playlistNH = (PlaylistNH)session.Load (typeof(PlaylistNH), playlist.Id);

                playlistNH.Titulo = playlist.Titulo;


                playlistNH.Portada = playlist.Portada;

                session.Update (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


        public void Eliminar(int id)
        {
                try
                {
                        SessionInitializeTransaction();

                        // Cargar la playlist
                        PlaylistNH playlistNH = (PlaylistNH)session.Load(typeof(PlaylistNH), id);

                        // Eliminar explícitamente las relaciones de la tabla intermedia
                        var cancionesRelacionadas = playlistNH.Cancion.ToList(); // Crear una copia
                        foreach (var cancion in cancionesRelacionadas)
                        {
                        playlistNH.Cancion.Remove(cancion); // Eliminar la relación
                        cancion.Playlist.Remove(playlistNH); // Eliminar la relación inversa
                        }
                        session.Update(playlistNH); // Sincronizar cambios en la tabla intermedia

                        // Ahora eliminar la playlist
                        session.Delete(playlistNH);

                        SessionCommit();
                }
                catch (Exception ex)
                {
                        SessionRollBack();
                        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                        else
                        throw new WavezGen.ApplicationCore.Exceptions.DataLayerException("Error in PlaylistRepository.", ex);
                }
                finally
                {
                        SessionClose();
                }
        }


        //Sin e: DamePlaylistPorOID
        //Con e: PlaylistEN
        public PlaylistEN DamePlaylistPorOID (int id
                                      )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> DameTodasLasPlaylist (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlaylistNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                else
                        result = session.CreateCriteria (typeof(PlaylistNH)).List<PlaylistEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PlaylistEN> DamePlaylistsPorNombre(string nombre)
{
    System.Collections.Generic.IList<PlaylistEN> result;
    try
    {
        SessionInitializeTransaction();
        result = session.CreateCriteria(typeof(PlaylistNH))
                        .Add(Restrictions.Like("Titulo", nombre, MatchMode.Anywhere))
                        .List<PlaylistEN>();
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is WavezGen.ApplicationCore.Exceptions.ModelException)
            throw;
        else throw new WavezGen.ApplicationCore.Exceptions.DataLayerException("Error in PlaylistRepository.", ex);
    }
    finally
    {
        SessionClose();
    }
    return result;
}
}
}
