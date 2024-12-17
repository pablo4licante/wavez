using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;
using NHibernate;

namespace WebWavez.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: NotificacionController
        public ActionResult Index()
        {

            IEnumerable<NotificacionViewModel> listaNotificaciones;

            SessionInitialize();
            NotificacionRepository notificacionRepository = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);

            IList<NotificacionEN> listaENs = notificacionCEN.DameTodasLasNotificaciones(0, -1);
            listaNotificaciones = new NotificacionAssembler().ConvertirListENToListViewModel(listaENs);

            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
            UsuarioEN yo = usuarioCEN.DameUsuarioPorOID(usuario.Usuario);
            IList<UsuarioEN> todosLosUsuarios = usuarioCEN.DameTodosLosUsuarios(0, -1);
            List<UsuarioEN> seguidos = todosLosUsuarios.Where(u => yo.UsuarioSeguidos.Contains(u)).ToList();

            // Print seguidos
            foreach (var seguido in seguidos)
            {
                Console.WriteLine($"Seguido: {seguido.Nombre}");
            }

            listaNotificaciones = listaNotificaciones.Where(n => seguidos.Contains(usuarioCEN.DameUsuarioPorOID(n.UsuarioPublicador)));

            // Print listaNotificaciones


            foreach (var notificacion in listaNotificaciones)
            {
                Console.WriteLine($"Notificacion: {notificacion.Id} {notificacion.UsuarioPublicador}");
            }
            return View(listaNotificaciones);

        }

        // GET: NotificacionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            NotificacionRepository notificacionRepository = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);
            NotificacionEN notificacionEN = notificacionCEN.DameNotificacionPorOID(id);
            NotificacionViewModel notificacionViewModel = new NotificacionAssembler().ConvertirENToViewModel(notificacionEN);
            SessionClose();
            return View(notificacionViewModel);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotificacionViewModel nvm)
        {
            try
            {
                NotificacionRepository notificacionRepository = new NotificacionRepository();
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
                PlaylistRepository playlistRepository = new PlaylistRepository();
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                CancionRepository cancionRepository = new CancionRepository();
                CancionCEN cancionCEN = new CancionCEN(cancionRepository);
                UsuarioEN UsuarioPublicador = usuarioCEN.DameUsuarioPorOID(nvm.UsuarioPublicador);
                IList<UsuarioEN> UsuariosReceptores = new List<UsuarioEN>();
                foreach (string usuario in nvm.UsuariosReceptores)
                {
                    UsuariosReceptores.Add(usuarioCEN.DameUsuarioPorOID(usuario));
                }

                CancionEN CancionCompartida = cancionCEN.DameCancionPorOID(nvm.CancionCompartida);
                PlaylistEN PlaylistCompartida = playlistCEN.DamePlaylistPorOID(nvm.PlaylistCompartida);
 
                notificacionCEN.Nuevo(nvm.Foto, nvm.Mensaje, nvm.Fecha, nvm.TipoContenido, UsuarioPublicador, UsuariosReceptores, CancionCompartida, PlaylistCompartida);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}