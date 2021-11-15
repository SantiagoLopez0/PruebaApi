using PruebaApi.DTO;
using PruebaApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaApi.Api.Controllers
{
    public class LibrosController : ApiController
    {
        LibrosService _service;

        public LibrosController()
        {
            _service = new LibrosService();
        }

        public IHttpActionResult Get()
        {
            return Ok(_service.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        public IHttpActionResult Insert(LibrosDTO libro)
        {
            return Ok(_service.Insert(libro));
        }

        //// GET: api/Libros
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Libros/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Libros
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Libros/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Libros/5
        //public void Delete(int id)
        //{
        //}
    }
}
