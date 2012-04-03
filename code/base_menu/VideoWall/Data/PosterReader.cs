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

        private IEnumerable<string> _files;
        public PosterReader()
        {
            Path = @"...\...\...\Resources\Poster";
        }

        public string Path { get; set; }
        public IEnumerable<string> Files
        {
            get
            {
                return _files = Directory.GetFiles(Path, "*jpg");
            }
        }
    }
}
