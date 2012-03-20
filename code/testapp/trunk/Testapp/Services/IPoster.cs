using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace Services
{
    public interface IPoster
    {
        string Title { get; }
        IDocumentPaginatorSource Document { get; }
    }
}
