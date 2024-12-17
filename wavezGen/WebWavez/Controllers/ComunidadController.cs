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
        public ActionResult Index(GenerosEnum? genre)
        {
            SessionInitialize();
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            IList<ComunidadEN> listaENs = new List<ComunidadEN>();

            if (genre.HasValue)
            {
                listaENs = comunidadCEN.DameTodasLasComunidades(0, -1).Where(c => c.Genero == genre.Value).ToList();
            }
            else
            {
                listaENs = comunidadCEN.DameTodasLasComunidades(0, -1);
            }

            IEnumerable<ComunidadViewModel> listaFiltrada = new ComunidadAssembler().ConvertirListENToListViewModel(listaENs);
            ViewBag.Generos = Enum.GetValues(typeof(GenerosEnum)).Cast<GenerosEnum>().ToList();
            ViewBag.FiltroActual = genre; // Opcional: para marcar el género seleccionado actualmente.
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
            SessionClose();

            var viewModel = new ComunidadDetailsViewModel
            {
                Comunidad = new ComunidadAssembler().CovertirENToViewModel(comunidadEN),
                Notificaciones = listaNotificaciones
            };

            return View(viewModel);
        }
    }
}
