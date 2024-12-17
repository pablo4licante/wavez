using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class CancionController : BasicController
    {

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _webHost;

        public CancionController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

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
            var generosEnumValues = Enum.GetValues(typeof(WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum))
                                        .Cast<WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum>()
                                        .ToDictionary(g => (int)g, g => g.ToString());

            ViewBag.GenerosEnumDictionary = generosEnumValues;
            return View();
        }

        // POST: CancionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CancionViewModel cvm)
        {

            string CancionFileName = "", CancionPath = "";
            string FotoFileName = "", FotoPath = "";
            if (cvm.FicheroFotoPortada != null && cvm.FicheroCancion != null && cvm.FicheroCancion.Length > 0 && cvm.FicheroFotoPortada.Length > 0)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                CancionFileName = timestamp + Path.GetExtension(cvm.FicheroCancion.FileName);
                FotoFileName = timestamp + Path.GetExtension(cvm.FicheroFotoPortada.FileName);

                string fotoDirectory = _webHost.WebRootPath + "/Imagenes";
                string songDirectory = _webHost.WebRootPath + "/Canciones";

                string cancionPath = Path.Combine((songDirectory), CancionFileName);
                string fotoPath = Path.Combine((fotoDirectory), FotoFileName);

                if (!Directory.Exists(fotoDirectory))
                {
                    Directory.CreateDirectory(fotoDirectory);
                }

                if (!Directory.Exists(songDirectory))
                {
                    Directory.CreateDirectory(songDirectory);
                }

                using (var fileStream = new FileStream(cancionPath, FileMode.Create))
                {
                    await cvm.FicheroCancion.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(fotoPath, FileMode.Create))
                {
                    await cvm.FicheroFotoPortada.CopyToAsync(fileStream);
                }
            }
            try
            {
                UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

                CancionFileName = "/Canciones/" + CancionFileName;
                FotoFileName = "/Imagenes/" + FotoFileName;
                Console.WriteLine("Estamos aqui {Subiendo Cancion} -> " + CancionFileName + " " + FotoFileName);
                CancionRepository cancionRepository = new CancionRepository();
                CancionCEN cancionCEN = new CancionCEN(cancionRepository);
                cancionCEN.Nuevo(cvm.Titulo, cvm.Genero, DateTime.Now, FotoFileName, usuario.Usuario, 1, CancionFileName);
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
        [HttpPost]
        public IActionResult AumentarReproducciones(int id)
        {
            CancionRepository cancionRepository = new CancionRepository();
            CancionCEN cancionCEN = new CancionCEN(cancionRepository);
            cancionCEN.ReproducirCancion(id);

            // You can return some result if needed
            return Json(new { success = true });
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
