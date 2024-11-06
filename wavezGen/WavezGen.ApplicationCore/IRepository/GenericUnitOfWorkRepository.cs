
using System;
using System.Collections.Generic;
using System.Text;

namespace WavezGen.ApplicationCore.IRepository.Wavez
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IAdminRepository adminrepository;
protected IComunidadRepository comunidadrepository;
protected IColaReprodRepository colareprodrepository;
protected ICancionRepository cancionrepository;
protected IPlaylistRepository playlistrepository;
protected IComentarioRepository comentariorepository;
protected INotificacionRepository notificacionrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IAdminRepository AdminRepository {
        get;
}
public abstract IComunidadRepository ComunidadRepository {
        get;
}
public abstract IColaReprodRepository ColaReprodRepository {
        get;
}
public abstract ICancionRepository CancionRepository {
        get;
}
public abstract IPlaylistRepository PlaylistRepository {
        get;
}
public abstract IComentarioRepository ComentarioRepository {
        get;
}
public abstract INotificacionRepository NotificacionRepository {
        get;
}
}
}
