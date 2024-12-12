using Microsoft.AspNetCore.Mvc;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class ComunidadController : BasicController
    {
        // GET: ComunidadController
        public ActionResult Index()
        {
            SessionInitialize();
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            IList<ComunidadEN> listaENs = comunidadCEN.DameTodasLasComunidades(0, -1);

            IEnumerable<ComunidadViewModel> listaComunidades = new ComunidadAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();

            return View(listaComunidades);
        }

        // GET: ComunidadController/Details/{genero}
        public ActionResult Details(int id)
        {
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            NotificacionRepository notificacionRepository = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);

            IList<NotificacionEN> listaNotificacionesENs = notificacionCEN.DameTodasLasNotificaciones(0, -1);
            
            return View();
        }
    }
}
