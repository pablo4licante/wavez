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

        public IActionResult ResultadoBusqueda(string query, string[] filter)
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
                if (filter.Contains("canciones"))
                {
                    listaCanciones = cancionCEN.DameCancionesPorNombre(query);
                }
                if (filter.Contains("playlists"))
                {
                    listaPlaylists = playlistCEN.DamePlaylistsPorNombre(query);
                }
                if (filter.Contains("usuarios"))
                {
                    listaUsuarios = usuarioCEN.DameUsuariosPorNombre(query);
                }
            }
            else
            {
                if (filter.Contains("canciones"))
                {
                    listaCanciones = cancionCEN.DameTodasLasCanciones(0, -1);
                }
                if (filter.Contains("playlists"))
                {
                    listaPlaylists = playlistCEN.DameTodasLasPlaylist(0, -1);
                }
                if (filter.Contains("usuarios"))
                {
                    listaUsuarios = usuarioCEN.DameTodosLosUsuarios(0, -1);
                }
            }

            if (filter.Contains("canciones"))
            {
                if(listaCanciones == null || listaCanciones.Count == 0)
                {
                    listaCanciones = new List<CancionEN>();
                }
            }
            if (filter.Contains("playlists")) 
            {
                if(listaPlaylists == null || listaPlaylists.Count == 0)
                {
                    listaPlaylists = new List<PlaylistEN>();
                }
            }
            if (filter.Contains("usuarios"))
            {
                if(listaUsuarios == null || listaUsuarios.Count == 0)
                {
                    listaUsuarios = new List<UsuarioEN>();
                }
            }

            IEnumerable<CancionViewModel> listaCancionesViewModel = new CancionAssembler().ConvertirListENToListViewModel(listaCanciones);
            IEnumerable<PlaylistViewModel> listaPlaylistsViewModel = new PlaylistAssembler().ConvertirListENToListViewModel(listaPlaylists);
            IEnumerable<UsuarioViewModel> listaUsuariosViewModel = new UsuarioAssembler().ConvertirListENToListViewModel(listaUsuarios);

            SessionClose();

            var resultadoBusqueda = new ResultadoBusquedaViewModel
            {
                Canciones = listaCancionesViewModel,
                Playlists = listaPlaylistsViewModel,
                Usuarios = listaUsuariosViewModel,
                Filtros = filter
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
