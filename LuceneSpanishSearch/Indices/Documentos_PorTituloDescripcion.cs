﻿using LuceneSpanishSearch.Models;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch.Indices
{
    public class Documentos_PorTituloDescripcion : AbstractIndexCreationTask<Documento>
    {
        public Documentos_PorTituloDescripcion()
        {
            Map = documentos => from documento in documentos select new { documento.Titulo, documento.Contenido };

            //var analyzerName = typeof(SpanishAnalyzer).AssemblyQualifiedName;

            Index(x => x.Titulo, FieldIndexing.Analyzed);
            //Analyze(x => x.Titulo, analyzerName);
            Suggestion(x => x.Titulo);

            Index(x => x.Contenido, FieldIndexing.Analyzed);
            //Analyze(x => x.Contenido, analyzerName);
        }
    }
}