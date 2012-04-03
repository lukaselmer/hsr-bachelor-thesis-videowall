using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
