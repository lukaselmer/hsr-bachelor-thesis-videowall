using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Services
{
    public interface ILunchMenu : INotifyPropertyChanged
    {
        string Name { get; set; }
    }
}
