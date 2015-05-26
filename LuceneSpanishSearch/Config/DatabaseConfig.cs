using LuceneSpanishSearch.Indices;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch.Config
{
    internal static class DatabaseConfig
    {

        internal static void ConfigureEmbeddedDb()
        {
            IDocumentStore store = new EmbeddableDocumentStore
            {
                ConnectionStringName = "SampleRavenDb"
            };

            store.Initialize();

            // Se registran todos los indices del assembly
            var asm = typeof(Documentos_PorTituloDescripcion).Assembly;
            IndexCreation.CreateIndexes(asm, store);

            // se setea una variable estática con el document store
            // para abrir sesiones en cualquier momento.
            DataBaseSession.store = store;
        }
    }
}