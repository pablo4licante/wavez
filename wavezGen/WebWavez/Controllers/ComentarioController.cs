﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WebWavez.Models;

namespace WebWavez.Controllers
{
    public class ComentarioController : BasicController
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoComentario(int idCancion, string mensaje)
        {
            ComentarioRepository comentarioRepository = new ComentarioRepository();
            ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioRepository);
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            comentarioCEN.Nuevo(mensaje, idCancion, usuario.Usuario);

            // Redirect to the Cancion Details view with the idCancion parameter
            return RedirectToAction("Details", "Cancion", new { id = idCancion });
        }

        // GET: ComentarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ComentarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComentarioController/Edit/5
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

        // GET: ComentarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComentarioController/Delete/5
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
