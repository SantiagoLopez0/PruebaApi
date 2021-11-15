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
    public class AutoresController : ApiController
    {
        AutoresService _service;

        public AutoresController()
        {
            _service = new AutoresService();
        }
        public IHttpActionResult Get()
        {
            return Ok(_service.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        public IHttpActionResult Insert(AutoresDTO autor)
        {
            return Ok(_service.Insert(autor));
        }

        //// GET: api/Autores/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Autores
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Autores/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Autores/5
        //public void Delete(int id)
        //{
        //}
    }
}
