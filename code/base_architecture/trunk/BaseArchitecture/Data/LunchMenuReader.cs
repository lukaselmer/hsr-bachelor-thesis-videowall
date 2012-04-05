using System.IO;
using System.Linq;
using Common;

namespace Data
{
    public class LunchMenuReader : Notifier
    {

        public LunchMenuReader()
        {
            Path = @"...\...\...\Resources\LunchMenu";
        }
        public string Path { get; private set; }
        public string File
        {
            get { return Directory.GetFiles(Path, "*jpg").First(); }
        }
    }
}
