using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Transactions;
using System.Xml.Serialization;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class PlaylistController : BasicController
    {

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _webHost;

        public PlaylistController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: PlaylistController
        public ActionResult Index()
        {
            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            IList<PlaylistEN> listaENs = playlistCEN.DameTodasLasPlaylist(0, -1);

            IEnumerable<PlaylistViewModel> listaPlaylists = new PlaylistAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();

            IList<PlaylistEN> misPlaylistsENs = dameMisPlaylists();
            IEnumerable<PlaylistViewModel> MisPlaylists = new PlaylistAssembler().ConvertirListENToListViewModel(misPlaylistsENs);

            // Pass the playlists to the view
            ViewBag.MisPlaylists = MisPlaylists;

            return View(listaPlaylists);
        }

        [HttpPost]
        public void AgregarCancionAPlaylist(int cancionOID, int playlistOID)
        {
            Console.WriteLine("Cancion: " + cancionOID.ToString());
            Console.WriteLine("Playlist " + playlistOID.ToString());

            var playlistRepository = new PlaylistRepository();
            var playlistCEN = new PlaylistCEN(playlistRepository);
            playlistCEN.AddCancion(playlistOID, new List<int> { cancionOID });
        
        }


        public IList<PlaylistEN> dameMisPlaylists()
        {

            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            IList<PlaylistEN> playlistENs = playlistCEN.DameTodasLasPlaylist(0, -1);
            IList<PlaylistEN> misPlaylists = new List<PlaylistEN>();
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            foreach (PlaylistEN playlistEN in playlistENs)
            {
                if (playlistEN.UsuarioCreador.Usuario == usuario.Usuario)
                {
                    misPlaylists.Add(playlistEN);
                }
            }

            return misPlaylists;
        }
        
public string dameMisPlaylistJSON() // Lol JSON a mano
        {
            IList<PlaylistEN> misPlaylists = dameMisPlaylists();
            string texto = "{ ";
            texto += "\"playlists\":[";
            for (int i = 0; i < misPlaylists.Count; i++)
            {
                PlaylistEN playlist = misPlaylists[i];
                texto += "{ ";
                texto += "\"Id\":\"";
                texto += playlist.Id;
                texto += "\"";
                texto += ",";

                texto += "\"Titulo\":\"";
                texto += playlist.Titulo;
                texto += "\"";
                texto += "}";

                if (i < misPlaylists.Count - 1)
                {
                    texto += ",";
                }
            }
            texto += "]}";

            return texto;
        }

        // GET: PlaylistController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            PlaylistEN playlistEN = playlistCEN.DamePlaylistPorOID(id);

            if (playlistEN == null)
            {
                SessionClose();
                return NotFound();
            }

            PlaylistViewModel playlistViewModel = new PlaylistAssembler().ConvertirENToViewModel(playlistEN);

            // Fetch the songs in the playlist
            IList<CancionEN> cancionesEN = playlistEN.Cancion;
            IEnumerable<CancionViewModel> cancionesViewModel = new CancionAssembler().ConvertirListENToListViewModel(cancionesEN);
            ViewBag.Canciones = cancionesViewModel;

            SessionClose();

            // Pass the playlist and songs to the view
            return View(playlistViewModel);
        }

        // GET: PlaylistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaylistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(PlaylistViewModel pvm)
        {

            string FotoFileName = "", FotoPath = "";
            if (pvm.FicheroFotoPortada != null && pvm.FicheroFotoPortada.Length > 0)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                FotoFileName = timestamp + Path.GetExtension(pvm.FicheroFotoPortada.FileName);

                string fotoDirectory = _webHost.WebRootPath + "/Imagenes";
                
                string fotoPath = Path.Combine((fotoDirectory), FotoFileName);

                if (!Directory.Exists(fotoDirectory))
                {
                    Directory.CreateDirectory(fotoDirectory);
                }


                using (var fileStream = new FileStream(fotoPath, FileMode.Create))
                {
                    await pvm.FicheroFotoPortada.CopyToAsync(fileStream);
                }
            }
            try
            {
                UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

                FotoFileName = "/Imagenes/" + FotoFileName;
                PlaylistRepository playlistRepository = new PlaylistRepository();
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                playlistCEN.Nuevo(pvm.Titulo, FotoFileName, usuario.Usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaylistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaylistController/Edit/5
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

        // GET: PlaylistController/Delete/5
        public ActionResult Delete(int id)
        {
            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            playlistCEN.Eliminar(id);
            return RedirectToAction("Perfil", "Usuario", new { id = "me" });
        }

        // POST: PlaylistController/Delete/5
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