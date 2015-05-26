using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch.Models
{
    public class DocumentoEditarModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Contenido { get; set; }
    }
}