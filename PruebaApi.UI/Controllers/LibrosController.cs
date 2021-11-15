using PruebaApi.DTO;
using PruebaApi.UI.Service.services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaApi.UI.Controllers
{
    public class LibrosController : Controller
    {
        LibrosService _service;
        AutoresService _autores;

        public LibrosController()
        {
            _service = new LibrosService();
            _autores = new AutoresService();
        }

        // GET: Libros
        public async Task<ActionResult> Index()
        {
            var response = await _service.GetAsync();
            return View(response);
        }

        // GET: Libros/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _service.GetAsync(id);
            return View(response);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(_autores.GetAsync().Result, "IdAutor", "NombreCompleto");

            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        public async Task<ActionResult> Create(LibrosDTO libro)
        {
            try
            {
                // TODO: Add insert logic here
                int maxLibros = Convert.ToInt32(ConfigurationManager.AppSettings["maxLibros"]);
                var libros = await _service.GetAsync();
                ViewBag.mensaje = string.Empty;
                if (libros.Count() == maxLibros)
                {
                    ViewBag.AutorId = new SelectList(_autores.GetAsync().Result, "IdAutor", "NombreCompleto");
                    ViewBag.mensaje = "Ha alcanzado e";
                    return View();
                }
                else
                {
                    var response = await _service.InsertAsync(libro);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                ViewBag.mensaje = "Error al grabar";
                return View();
            }
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
