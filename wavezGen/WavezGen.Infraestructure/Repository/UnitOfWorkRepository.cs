

using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WavezGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace WavezGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IAdminRepository AdminRepository {
        get
        {
                this.adminrepository = new AdminRepository ();
                this.adminrepository.setSessionCP (session);
                return this.adminrepository;
        }
}

public override IComunidadRepository ComunidadRepository {
        get
        {
                this.comunidadrepository = new ComunidadRepository ();
                this.comunidadrepository.setSessionCP (session);
                return this.comunidadrepository;
        }
}

public override IColaReprodRepository ColaReprodRepository {
        get
        {
                this.colareprodrepository = new ColaReprodRepository ();
                this.colareprodrepository.setSessionCP (session);
                return this.colareprodrepository;
        }
}

public override ICancionRepository CancionRepository {
        get
        {
                this.cancionrepository = new CancionRepository ();
                this.cancionrepository.setSessionCP (session);
                return this.cancionrepository;
        }
}

public override IPlaylistRepository PlaylistRepository {
        get
        {
                this.playlistrepository = new PlaylistRepository ();
                this.playlistrepository.setSessionCP (session);
                return this.playlistrepository;
        }
}

public override IComentarioRepository ComentarioRepository {
        get
        {
                this.comentariorepository = new ComentarioRepository ();
                this.comentariorepository.setSessionCP (session);
                return this.comentariorepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}
}
}

