using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO
{
    public class LibrosDTO
    {
        public int idLibro { get; set; }     
        public string NombreLibro { get; set; }
        public int? Paginas { get; set; }
        public int? IdAutor { get; set; }

        public int? AnnioPublicacion { get; set; }
        public string Genero { get; set; }

        public string Nombre_Autor { get; set; }
    }
}
