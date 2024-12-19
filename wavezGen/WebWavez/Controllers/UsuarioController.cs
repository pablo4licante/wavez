using Microsoft.AspNetCore.Mvc;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Assemblers;
using WebWavez.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using System.Diagnostics;
using WavezGen.ApplicationCore.Utils;
using WavezGen.ApplicationCore.Enumerated.Wavez;

namespace WebWavez.Controllers
{
    public class UsuarioController : BasicController
    {

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _webHost;

        public UsuarioController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        //*********************************************  LOGIN  **************************************************

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.Usuario, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir los datos del nombre de usuario o password");
                return View();
            }
            else
            {
                SessionInitialize();
                UsuarioEN usuEN = usuCEN.DameUsuarioPorOID(login.Usuario);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            // Limpiar los datos de sesión
            HttpContext.Session.Remove("usuario");

            // Redirigir al usuario a la página de inicio de sesión u otra página
            return RedirectToAction("Login", "Usuario");
        }



        //*********************************************  REGISTRO  **************************************************

        // GET: UsuarioController/Registro
        public ActionResult Registro()
        {
            return View();
        }

        // POST: UsuarioController/Registro
        [HttpPost]
        public async Task<ActionResult> Registro(RegistroUsuarioViewModel registro)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            string FotoFileName = ""; 

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            FotoFileName = timestamp + Path.GetExtension(registro.FicheroFotoPortada.FileName);

            string fotoDirectory = _webHost.WebRootPath + "/Imagenes";

            string fotoPath = Path.Combine((fotoDirectory), FotoFileName);

            if (!Directory.Exists(fotoDirectory))
            {
                Directory.CreateDirectory(fotoDirectory);
            }

            using (var fileStream = new FileStream(fotoPath, FileMode.Create))
            {
                await registro.FicheroFotoPortada.CopyToAsync(fileStream);
            }



            //conprobar la confirmación de la password
            if (registro.Password == registro.ConfirmPassword)
            {
                //hacer el registro
                try
                {
                    FotoFileName = "/Imagenes/" + FotoFileName;
                    
                    //cancionCEN.Nuevo(cvm.Titulo, cvm.Genero, cvm.Fecha, cvm.FotoPortada, cvm.Autor, cvm.numReproducciones);
                    usuCEN.Nuevo(registro.Usuario, registro.Nombre, registro.Password, registro.Email, FotoFileName);
                    return RedirectToAction("Login", "Usuario");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Error al introducir los datos del registro " + e);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Las contraseñas no coinciden");
                return View();
            }
        }


        //*********************************************  PERFIL  **************************************************

        // GET: UsuarioController/Perfil
        public ActionResult Perfil(string id)
        {
            SessionInitialize();

            UsuarioRepository usuRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
            CancionRepository cancionRepo = new CancionRepository(session);
            CancionCEN cancionCEN = new CancionCEN(cancionRepo);
            PlaylistRepository playlistRepo = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepo);

            //coger el usuario de la session
            UsuarioViewModel usuarioVM = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuarioVM == null){ return RedirectToAction("Login", "Usuario"); }

            //el usuario que queremos mostrar es el nuestro si le pasamos me
            if (id == "me")
            {
                id = usuarioVM.Usuario;
            }
            var esPerfilPropio = (usuarioVM.Usuario == id);
            //se coge el usuario que se tiene que mostrar
            UsuarioEN usuario = usuCEN.DameUsuarioPorOID(id);
            if (usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //seguidos del usuario
            IList<UsuarioEN> seguidosUsuario = usuario.UsuarioSeguidos;
            //seguidores del usuario
            IList<UsuarioEN> usuarios = usuCEN.DameTodosLosUsuarios(0, -1);
            IList<UsuarioEN> seguidoresUsuario = new List<UsuarioEN>();
            foreach (var item in usuarios)  //para cada usuario
            {
                if (item.UsuarioSeguidos.Any(u => u.Usuario == usuario.Usuario))  //si un usuario sigue al actual
                {
                    seguidoresUsuario.Add(item);  //se añade a lista de seguidores de usuario
                }
            }

            int totalSeguidores = seguidoresUsuario.Count;
            int totalSeguidos = seguidosUsuario.Count;

            //se cogen las canciones del usuario
            IList<CancionEN> cancionesUsuario = cancionCEN.DameTodasLasCanciones(0, -1).Where(c => c.Autor == usuario).ToList();
            //se cogen las playlist del usuario
            IList<PlaylistEN> playlistUsuario = playlistCEN.DameTodasLasPlaylist(0, -1).Where(p => p.UsuarioCreador == usuario).ToList();

            //si es la pagina de otro ******************************************************************
            UsuarioEN usuarioSesion = usuCEN.DameUsuarioPorOID(usuarioVM.Usuario); //cogemos el usuario de la sesion
            IList<UsuarioEN> seguidosUsuarioSesion = usuarioSesion.UsuarioSeguidos; //sus seguidos
            bool esSeguido = seguidosUsuarioSesion.Any(u => u.Usuario == usuario.Usuario); //está este en sus seguidos??
            Debug.WriteLine($"El usuario {usuario.Usuario} es seguido:  {esSeguido} por {usuarioSesion.Usuario}");
            //convertir el usuario en view model *******************************************
            UsuarioViewModel usuarioPerfilVM = new UsuarioAssembler().ConvertirENToViewModel(usuario);
            usuarioPerfilVM.EsSeguidoPorUsuarioActual = esSeguido;


            //convertir las canciones en view model
            IEnumerable<CancionViewModel> listaCancionesVM = new CancionAssembler().ConvertirListENToListViewModel(cancionesUsuario);
            //convertir las playlist en view model
            IEnumerable<PlaylistViewModel> listaPlaylistVM = new PlaylistAssembler().ConvertirListENToListViewModel(playlistUsuario);
            //convertir los seguidores en view model
            IEnumerable<UsuarioViewModel> listaSeguidoresVM = new UsuarioAssembler().ConvertirListENToListViewModel(seguidoresUsuario);
            //convertir los seguidos en view model
            IEnumerable<UsuarioViewModel> listaSeguidosVM = new UsuarioAssembler().ConvertirListENToListViewModel(seguidosUsuario);

            SessionClose();

            var perfilVM = new PerfilViewModel
            {
                Usuario = usuarioPerfilVM,
                Canciones = listaCancionesVM,
                Playlists = listaPlaylistVM,
                Seguidores = listaSeguidoresVM,
                Seguidos = listaSeguidosVM,
                EsPerfilPropio = esPerfilPropio,
                TotalSeguidores = totalSeguidores,
                TotalSeguidos = totalSeguidos
            };

            return View(perfilVM);
        }


        [HttpPost]
        public JsonResult Seguir(string id)
        {
            SessionInitialize();
            try
            {
                // Obtener el usuario autenticado de la sesión
                var usuarioSesion = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                if (usuarioSesion == null)
                {
                    SessionClose();
                    return Json(new { success = false, message = "Usuario no autenticado." });
                }

                UsuarioRepository usuRepo = new UsuarioRepository(session);
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuRepo);

                // Comprobar si el usuario ya está siguiendo al otro usuario
                var seguidos = usuarioCEN.DameUsuarioPorOID(usuarioSesion.Usuario).UsuarioSeguidos;
                bool yaSeguido = seguidos.Any(u => u.Usuario == id);


                var idsSeguidos = new List<string> { id };  //el usuario al que se va a seguir se tiene que pasar a lista 

                if (yaSeguido)
                {
                    // Dejar de seguir
                    UsuarioRepository usuariorepository = new UsuarioRepository();
                    UsuarioCEN usuariocen = new UsuarioCEN(usuariorepository);
                    usuariocen.DejarDeSeguir(usuarioSesion.Usuario, idsSeguidos);

                    SessionClose();
                    return Json(new { success = true, action = "unfollow", message = "Has dejado de seguir a este usuario." });
                }
                else
                {
                    // Seguir
                    UsuarioRepository usuariorepository = new UsuarioRepository();
                    UsuarioCEN usuariocen = new UsuarioCEN(usuariorepository);
                    usuariocen.Seguir(usuarioSesion.Usuario, idsSeguidos);

                    SessionClose();
                    return Json(new { success = true, action = "follow", message = "Estás siguiendo a este usuario." });
                }
            }
            catch (Exception ex)
            {
                SessionClose();
                return Json(new { success = false, message = ex.Message });
            }
        }




        //***********************************************************************************************************

        // GET: UsuarioController
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
            IList<UsuarioEN> listaENs = usuarioCEN.DameTodosLosUsuarios(0, -1);

            IEnumerable<UsuarioViewModel> listaUsuarios = new UsuarioAssembler().ConvertirListENToListViewModel(listaENs);
            SessionClose();

            return View(listaUsuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel uvm)
        {
            try
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
                usuarioCEN.Nuevo(uvm.Usuario, uvm.Nombre, uvm.Password, uvm.Email, uvm.FotoPerfil);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(string id)
        {
            SessionInitialize();

            UsuarioRepository usuRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            UsuarioEN usuEN = usuCEN.DameUsuarioPorOID(id);
            UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);  

            SessionClose(); 
            return View(usuVM);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id,UsuarioViewModel usu)
        {
            string FotoFileName = "";

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (usu.FicheroFotoPortada != null) {
                FotoFileName = timestamp + Path.GetExtension(usu.FicheroFotoPortada.FileName);
                string fotoDirectory = _webHost.WebRootPath + "/Imagenes";

                string fotoPath = Path.Combine((fotoDirectory), FotoFileName);

                if (!Directory.Exists(fotoDirectory))
                {
                    Directory.CreateDirectory(fotoDirectory);
                }

                using (var fileStream = new FileStream(fotoPath, FileMode.Create))
                {
                    await usu.FicheroFotoPortada.CopyToAsync(fileStream);
                }
            }

            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                // Obtener el usuario actual desde la base de datos
                UsuarioEN usuarioActual = usuCEN.DameUsuarioPorOID(id);
                if (usuarioActual == null)
                {
                    return View();
                }

                // Si la contraseña en el formulario está vacía, mantener la contraseña actual
                string nuevaContrasenya = string.IsNullOrEmpty(usu.Password)
                    ? usuarioActual.Contrasenya  // Mantener la existente
                    : usu.Password;  // Encriptar la nueva contraseña

                if(FotoFileName != "")
                {
                    usu.FotoPerfil = "/Imagenes/" + FotoFileName;
                } else
                {
                    usu.FotoPerfil = usuarioActual.FotoPerfil;
                }

                usuCEN.Modificar(id, usu.Nombre, usu.Password, usu.Email, usu.FotoPerfil);
                return RedirectToAction(nameof(Perfil));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Perfil));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public void CambiarFavorito(int idComunidad)
        {
            SessionInitialize();

            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            ComunidadEN comunidad = comunidadCEN.DameComunidadPorOID((GenerosEnum)idComunidad);
            UsuarioEN usuarioEN = usuarioCEN.DameUsuarioPorOID(usuario.Usuario);

            if (comunidad.Usuario.Contains(usuarioEN))
            {
                usuarioCEN.DesasignarComunidad(usuario.Usuario, new List<GenerosEnum> { (GenerosEnum)idComunidad });
            }
            else
            {
                usuarioCEN.AsignarComunidad(usuario.Usuario, new List<GenerosEnum> { (GenerosEnum)idComunidad });
            }
        }
    }
}