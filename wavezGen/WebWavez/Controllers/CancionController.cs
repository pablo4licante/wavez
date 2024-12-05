using Microsoft.AspNetCore.Mvc;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class CancionController : BasicController
    {
        // GET: CancionController
        public ActionResult Index()
        {
            SessionInitialize();
            CancionRepository cancionRepository = new CancionRepository(session);
            CancionCEN cancionCEN = new CancionCEN(cancionRepository);
            IList<CancionEN> listaENs = cancionCEN.DameTodasLasCanciones(0, -1);

            IEnumerable<CancionViewModel> listaCanciones = new CancionAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();

            return View(listaCanciones);
        }

        // GET: CancionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CancionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CancionViewModel cvm)
        {
            try
            {
                CancionRepository cancionRepository = new CancionRepository();
                CancionCEN cancionCEN = new CancionCEN(cancionRepository);
                cancionCEN.Nuevo(cvm.Titulo, cvm.Genero, cvm.Fecha, cvm.FotoPortada, cvm.Autor, cvm.numReproducciones, cvm.Url);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CancionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CancionController/Edit/5
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

        // GET: CancionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CancionController/Delete/5
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
