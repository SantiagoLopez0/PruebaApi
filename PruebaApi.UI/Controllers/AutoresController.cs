using PruebaApi.DTO;
using PruebaApi.UI.Service.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaApi.UI.Controllers
{
    public class AutoresController : Controller
    {
        AutoresService _service;

        public AutoresController()
        {
            _service = new AutoresService();
        }

        // GET: Autores
        public async Task<ActionResult> Index()
        {
            var response = await _service.GetAsync();
            return View(response);
        }

        // GET: Autores/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _service.GetAsync(id);
            return View(response);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        public async Task<ActionResult> Create(AutoresDTO autor)
        {
            try
            {
                // TODO: Add insert logic here
                var response = await _service.InsertAsync(autor);
                ViewBag.Error = "";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                string abc = ex.ToString();
                ViewBag.Error = "Error en el registro del Autor";
                return View();
            }
        }

        // GET: Autores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Autores/Edit/5
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

        // GET: Autores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Autores/Delete/5
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
