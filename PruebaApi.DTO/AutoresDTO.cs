using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO
{
    public class AutoresDTO
    {
        public int IdAutor { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string Email { get; set; }
    }
}
