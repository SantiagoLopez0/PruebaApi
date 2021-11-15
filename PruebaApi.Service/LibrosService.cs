using PruebaApi.DTO;
using PruebaApi.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Service
{
    public class LibrosService
    {
        PruebaApiModel _db;
        AutoresService _autores;


        public LibrosService()
        {
            _db = new PruebaApiModel();
            _autores = new AutoresService();
        }

        public IEnumerable<LibrosDTO> Get()
        {
            var resultado = _db.Libros;
            List<LibrosDTO> response = new List<LibrosDTO>();
            LibrosDTO libroDto = new LibrosDTO();

            foreach (var item in resultado)
            {
                libroDto = new LibrosDTO();
                libroDto.idLibro = item.idLibro;
                libroDto.NombreLibro = item.NombreLibro;
                libroDto.Paginas = item.Paginas;
                libroDto.AnnioPublicacion = item.AnnioPublicacion;
                libroDto.Genero = item.Genero;
                libroDto.IdAutor = (int)item.IdAutor;

                AutoresDTO autorTemp = new AutoresDTO();
                autorTemp = _autores.Get((int)libroDto.IdAutor);

                libroDto.Nombre_Autor = autorTemp.NombreCompleto;

                response.Add(libroDto);
            }

            return response;
        }

        public LibrosDTO Get(int id)
        {
            var resultado = _db.Libros.Where(x => x.idLibro == id).FirstOrDefault();

            LibrosDTO libroDto = new LibrosDTO();

            libroDto = new LibrosDTO();
            libroDto.idLibro = resultado.idLibro;
            libroDto.NombreLibro = resultado.NombreLibro;
            libroDto.Paginas = resultado.Paginas;
            libroDto.AnnioPublicacion = resultado.AnnioPublicacion;
            libroDto.Genero = resultado.Genero;
            libroDto.IdAutor = resultado.IdAutor;

            return libroDto;
        }

        public bool Insert(LibrosDTO libro)
        {
            try
            {
                Libros libroInsert = new Libros();

                libroInsert.idLibro = libro.idLibro;
                libroInsert.NombreLibro = libro.NombreLibro;
                libroInsert.Paginas = libro.Paginas;
                libroInsert.AnnioPublicacion = libro.AnnioPublicacion;
                libroInsert.Genero = libro.Genero;
                libroInsert.IdAutor = libro.IdAutor;

                _db.Libros.Add(libroInsert);
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
