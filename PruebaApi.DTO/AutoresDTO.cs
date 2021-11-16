using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO
{
    public class AutoresDTO
    {
        public int IdAutor { get; set; }
        public string NombreCompleto { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string Email { get; set; }
    }
}
