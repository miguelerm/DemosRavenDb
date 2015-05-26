using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch.Models
{
    public class DocumentoIndexModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Titulo { get; set; }
    }
}