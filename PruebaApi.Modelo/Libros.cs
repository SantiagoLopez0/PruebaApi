namespace PruebaApi.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Libros
    {
        [Key]
        public int idLibro { get; set; }

        [StringLength(150)]
        public string NombreLibro { get; set; }

        public int? Paginas { get; set; }

        public int? IdAutor { get; set; }

        public int? AnnioPublicacion { get; set; }

        [StringLength(150)]
        public string Genero { get; set; }

        public virtual Autores Autores { get; set; }
    }
}
