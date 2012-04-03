using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class PosterReader : Notifier
    {

        public PosterReader()
        {
            Path = @"...\...\...\Resources\Poster";
        }

        public string Path { get; private set; }
        public IEnumerable<string> Files
        {
            get
            {
                return Directory.GetFiles(Path, "*jpg");
            }
        }
    }
}
