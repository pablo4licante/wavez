using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.Enumerated.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class ComunidadController : BasicController
    {
        // GET: ComunidadController
        public ActionResult Index(string filterType)
        {
            SessionInitialize();
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            IList<ComunidadEN> listaENs = new List<ComunidadEN>();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            listaENs = comunidadCEN.DameTodasLasComunidades(0, -1);

            Console.WriteLine("Este es el segundo filtro" + filterType);
            
            if (filterType == "mine")
                //hacer bien la relacion para guardar las comunidades a las que pertenece el usuario logueado
            {
                if (filterType == "mine")
                {
                    var usuarioEN = usuarioCEN.DameUsuarioPorOID(usuario.Usuario);
                    listaENs = listaENs.Where(c => c.Usuario.Contains(usuarioEN)).ToList();
                }
            }

            IEnumerable<ComunidadViewModel> listaFiltrada = new ComunidadAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();

            return View(listaFiltrada);
        }


        // GET: ComunidadController/Details/{genero}
        // GET: ComunidadController/Details/{genero}
        public ActionResult Detalle(int id)
        {
            SessionInitialize();
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            NotificacionRepository notificacionRepository = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            ComunidadEN comunidad = comunidadCEN.DameComunidadPorOID((GenerosEnum)id);
            UsuarioEN usuarioEN = usuarioCEN.DameUsuarioPorOID(usuario.Usuario);

            ViewBag.EsFavorito = comunidad.Usuario.Contains(usuarioEN);
            ViewBag.IdComunidad = id;


            if (!Enum.IsDefined(typeof(WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum), id))
            {
                SessionClose();
                return RedirectToAction("Error");
            }

            ComunidadEN comunidadEN = comunidadCEN.DameComunidadPorOID((WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum)id);
            if (comunidadEN == null)
            {
                SessionClose();
                return RedirectToAction("Error");
            }

            IList<NotificacionEN> listaNotificacionesENs = comunidadEN.Notificacion;
            IEnumerable<NotificacionViewModel> listaNotificaciones = new NotificacionAssembler().ConvertirListENToListViewModel(listaNotificacionesENs);

            var viewModel = new ComunidadDetailsViewModel
            {
                Comunidad = new ComunidadAssembler().CovertirENToViewModel(comunidadEN),
                Notificaciones = listaNotificaciones
            };

            return View(viewModel);
        }

        [HttpPost]
        public void CrearTodasLasComunidades()
        {
            ComunidadRepository comunidadRepository = new ComunidadRepository();
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            foreach (GenerosEnum genero in Enum.GetValues(typeof(GenerosEnum)))
            {
                if(genero != GenerosEnum.Pop)
                {
                    comunidadCEN.Nuevo(genero);
                }
            }
        }

    }
}
