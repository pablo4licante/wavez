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

namespace WebWavez.Controllers
{
    public class UsuarioController : BasicController
    {
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


        //*********************************************  REGISTRO  **************************************************

        // GET: UsuarioController/Registro
        public ActionResult Registro()
        {
            return View();
        }

        // POST: UsuarioController/Registro
        [HttpPost]
        public ActionResult Registro(RegistroUsuarioViewModel registro)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            //conprobar la confirmaci�n de la password
            if (registro.Password == registro.ConfirmPassword)
            {
                //hacer el registro
                try
                {
                    //cancionCEN.Nuevo(cvm.Titulo, cvm.Genero, cvm.Fecha, cvm.FotoPortada, cvm.Autor, cvm.numReproducciones);
                    usuCEN.Registro(registro.Usuario, registro.Nombre, registro.Password, registro.Email, registro.FotoPerfil);
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    ModelState.AddModelError("", "Error al introducir los datos del registro");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Las contrase�as no coinciden");
                return View();
            }
        }


        //*********************************************  PERFIL  **************************************************

        // GET: UsuarioController/Perfil

        public ActionResult Perfil()
        {
            SessionInitialize();

            UsuarioRepository usuRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            //coger el usuario de la session
            UsuarioViewModel usuarioVM = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            string id = "";
            if (usuarioVM == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            id = usuarioVM.Usuario;
            //usuario = dameusuarioporoid (id)
            UsuarioEN usuario = usuCEN.DameUsuarioPorOID(id);
            //usuario.damemiscanciones
            IList<CancionEN> listaENs = (IList<CancionEN>)usuCEN.DameMisCanciones();
            //convertir las canciones en view model
            IEnumerable<CancionViewModel> listaCanciones = new CancionAssembler().ConvertirListENToListViewModel(listaENs);


            //IList<CancionEN> listaENs = (IList<CancionEN>)usuario.DameMisCanciones();  //dame las canciones del usuario
            //IEnumerable<CancionViewModel> listaCanciones = new CancionAssembler().ConvertirListENToListViewModel(listaENs);

            SessionClose();

            return View(listaCanciones);
        }

        /*
        public ActionResult Perfil2()
        {
            try
            {
                SessionInitialize();

                UsuarioRepository usuRepo = new UsuarioRepository(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                // Obtener el usuario de la sesi�n
                UsuarioViewModel usuarioVM = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                if (usuarioVM == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                // Obtener los datos del usuario desde la base de datos
                UsuarioEN usuario = usuCEN.DameUsuarioPorOID(usuarioVM.Usuario);
                IList<CancionEN> listaENs = usuario.DameMisCanciones();

                // Convertir a ViewModel
                IEnumerable<CancionViewModel> listaCanciones = new CancionAssembler().ConvertirListENToListViewModel(listaENs);


                return View(listaCanciones);
            }
            finally
            {
                SessionClose();
            }
        }
        */




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
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}