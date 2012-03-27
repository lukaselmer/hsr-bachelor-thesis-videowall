using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;

namespace Services
{
    public class Poster : IPoster
    {
        public Poster(string file)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                if (fileNameWithoutExtension != null)
                {
                    Title = fileNameWithoutExtension.Replace("_", " ");

                    var doc = new XpsDocument(file, FileAccess.Read);
                    Document = doc.GetFixedDocumentSequence();
                }
        }

        public string Title { get; private set; }

        public IDocumentPaginatorSource Document { get; set; }
    }
}
