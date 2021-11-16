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

        public ActionResult GetData(JqueryDataTableParam param)
        {
            List<LibrosDTO> libros = new List<LibrosDTO>();
            try
            {
                libros = (List<LibrosDTO>)_service.GetAsync().Result;
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    libros = (List<LibrosDTO>)libros.Where(x => (x.NombreLibro.ToLower().Contains(param.sSearch.ToLower()))
                                                 || (x.Nombre_Autor.ToLower().Contains(param.sSearch.ToLower()))
                                                 || (x.Genero.ToLower().Contains(param.sSearch.ToLower()))
                                                 || (Convert.ToString(x.AnnioPublicacion).ToLower().Contains(param.sSearch.ToLower()))).ToList();
                }

                var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
                var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

                if (sortColumnIndex == 1)
                {
                    libros = (List<LibrosDTO>)(sortDirection == "asc" ? libros.OrderBy(c => c.NombreLibro) : libros.OrderByDescending(c => c.NombreLibro)).ToList();
                }
                else if (sortColumnIndex == 2)
                {
                    libros = (List<LibrosDTO>)(sortDirection == "asc" ? libros.OrderBy(c => c.Nombre_Autor) : libros.OrderByDescending(c => c.Nombre_Autor)).ToList();
                }
                else if (sortColumnIndex == 3)
                {
                    libros = (List<LibrosDTO>)(sortDirection == "asc" ? libros.OrderBy(c => c.AnnioPublicacion) : libros.OrderByDescending(c => c.AnnioPublicacion)).ToList();
                }
                else if (sortColumnIndex == 4)
                {
                    libros = (List<LibrosDTO>)(sortDirection == "asc" ? libros.OrderBy(c => c.Genero) : libros.OrderByDescending(c => c.Genero)).ToList();
                }
                else
                {
                    Func<LibrosDTO, string> orderingFunction = e => sortColumnIndex == 0 ? e.Nombre_Autor.ToString() :
                                                                   sortColumnIndex == 1 ? e.AnnioPublicacion.ToString() :
                                                                   e.Genero;

                    libros = (List<LibrosDTO>)(sortDirection == "asc" ? libros.OrderBy(orderingFunction) : libros.OrderByDescending(orderingFunction)).ToList();
                }

                var displayResult = libros.Skip(param.iDisplayStart)
                    .Take(param.iDisplayLength).ToList();
                var totalRecords = libros.Count();

                JsonResult response = Json(new
                {
                    param.sEcho,
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalRecords,
                    aaData = displayResult
                }, JsonRequestBehavior.AllowGet);
                return response;

            }
            catch (Exception ex)
            {
                JsonResult response = Json(new
                {
                    error = "error",
                    //trace = "Sin conexión a Base de Datos - Verifique VPN o Red !" //ex.ToString()
                    trace = ex.ToString()
                }, JsonRequestBehavior.AllowGet);
                return response;

                throw;
            }
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
