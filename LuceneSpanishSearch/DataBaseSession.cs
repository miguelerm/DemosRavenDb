using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch
{
    public class DataBaseSession
    {
        internal static IDocumentStore store;

        public static IDocumentSession Open()
        {
            if (store == null) throw new InvalidOperationException("El Document Store debe inicializarse antes de poder abrir una sesion.");
            return store.OpenSession();
        }
    }
}