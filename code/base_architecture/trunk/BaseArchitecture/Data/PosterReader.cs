using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class PosterReader : Notifier
    {
        private readonly IPosterReaderConfig PosterReaderConfig;

        public PosterReader(IPosterReaderConfig posterReaderConfig)
        {
            PosterReaderConfig = posterReaderConfig;
        }

        public string ReadPoster()
        {
            return PosterReaderConfig.ReadsAs() ? "Aaaaa" : "Bla";
        }
    }
}
