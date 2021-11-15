using PruebaApi.DTO;
using PruebaApi.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Service
{
    public class AutoresService
    {
        PruebaApiModel _db;

        public AutoresService()
        {
            _db = new PruebaApiModel();
        }
        public IEnumerable<AutoresDTO> Get()
        {
            var resultado = _db.Autores;
            List<AutoresDTO> response = new List<AutoresDTO>();
            AutoresDTO autorDto = new AutoresDTO();
            foreach (var item in resultado)
            {
                autorDto = new AutoresDTO();
                autorDto.IdAutor = item.IdAutor;
                autorDto.NombreCompleto = item.NombreCompleto;
                autorDto.FechaNacimiento = item.FechaNacimiento;
                autorDto.CiudadProcedencia = item.CiudadProcedencia;
                response.Add(autorDto);
            }

            return response;
        }
        public AutoresDTO Get(int id)
        {
            var resultado = _db.Autores.Where(x => x.IdAutor == id).FirstOrDefault();

            AutoresDTO autorDto = new AutoresDTO();
                
            autorDto.IdAutor = resultado.IdAutor;
            autorDto.NombreCompleto = resultado.NombreCompleto;
            autorDto.FechaNacimiento = resultado.FechaNacimiento;
            autorDto.CiudadProcedencia = resultado.CiudadProcedencia;
            autorDto.Email = resultado.Email;

            return autorDto;
        }

        public bool Insert(AutoresDTO autor)
        {
            try
            {
                Autores autorinsert = new Autores();

                autorinsert.NombreCompleto = autor.NombreCompleto;
                autorinsert.FechaNacimiento = autor.FechaNacimiento;
                autorinsert.Email = autor.Email;
                autorinsert.CiudadProcedencia = autor.CiudadProcedencia;

                _db.Autores.Add(autorinsert);

                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception();
            }
        }

    }
}
