using Lucene.Net.Analysis.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSpanishSearch
{
    public class SpanishAnalyzer : Lucene.Net.Analysis.Snowball.SnowballAnalyzer
    {
        public SpanishAnalyzer() : base(Lucene.Net.Util.Version.LUCENE_30, "Spanish", StandardAnalyzer.STOP_WORDS_SET)
        {

        }
    }
}