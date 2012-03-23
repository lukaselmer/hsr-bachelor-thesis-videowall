using System.ComponentModel;

namespace Services
{
    public interface IPoster: INotifyPropertyChanged
    {
        string Name { get; set; }
    }
}