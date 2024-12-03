using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class HomeController : BasicController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SessionInitialize();
            CancionRepository cancionRepository = new CancionRepository(session);
            CancionCEN cancionCEN = new CancionCEN(cancionRepository);
            IList<CancionEN> listaENs = cancionCEN.DameTodasLasCanciones(0, -1);

            IEnumerable<CancionViewModel> listaCanciones = new CancionAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();


            return View(listaCanciones);
        }

        public IActionResult ResultadoBusqueda(string query)
        {
            SessionInitialize();
            CancionRepository cancionRepository = new CancionRepository(session);
            CancionCEN cancionCEN = new CancionCEN(cancionRepository);

            PlaylistRepository playlistrepository = new PlaylistRepository ();
            PlaylistCEN playlistCEN = new PlaylistCEN (playlistrepository);

            UsuarioRepository usuariorepository = new UsuarioRepository ();
            UsuarioCEN usuarioCEN = new UsuarioCEN (usuariorepository);

            IList<CancionEN> listaCanciones = new List<CancionEN>();
            IList<PlaylistEN> listaPlaylists = new List<PlaylistEN>();
            IList<UsuarioEN> listaUsuarios = new List<UsuarioEN>();

            if (!string.IsNullOrWhiteSpace(query))
            {
                listaCanciones = cancionCEN.DameCancionesPorNombre(query);
                listaPlaylists = playlistCEN.DamePlaylistsPorNombre(query);
                listaUsuarios = usuarioCEN.DameUsuariosPorNombre(query);
            }
            else
            {
                listaCanciones = cancionCEN.DameTodasLasCanciones(0, -1);
                listaPlaylists = playlistCEN.DameTodasLasPlaylist(0, -1);
                listaUsuarios = usuarioCEN.DameTodosLosUsuarios(0, -1);
            }
            if(listaCanciones == null || listaCanciones.Count == 0)
            {
                listaCanciones = new List<CancionEN>();
            }
            if(listaPlaylists == null || listaPlaylists.Count == 0)
            {
                listaPlaylists = new List<PlaylistEN>();
            }
            if(listaUsuarios == null || listaUsuarios.Count == 0)
            {
                listaUsuarios = new List<UsuarioEN>();
            }

            IEnumerable<CancionViewModel> listaCancionesViewModel = new CancionAssembler().ConvertirListENToListViewModel(listaCanciones);
            IEnumerable<PlaylistViewModel> listaPlaylistsViewModel = new PlaylistAssembler().ConvertirListENToListViewModel(listaPlaylists); // Asumiendo que existe un PlaylistAssembler
            IEnumerable<UsuarioViewModel> listaUsuariosViewModel = new UsuarioAssembler().ConvertirListENToListViewModel(listaUsuarios); // Asumiendo que existe un UsuarioAssembler

            SessionClose();

            var resultadoBusqueda = new ResultadoBusquedaViewModel
            {
                Canciones = listaCancionesViewModel,
                Playlists = listaPlaylistsViewModel,
                Usuarios = listaUsuariosViewModel
            };

            return View(resultadoBusqueda);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
