using System;
using System.Windows.Controls;

namespace Interfaces
{
    public interface IApp
    {
        UserControl MainView { get; }
        String Name { get; }
    }
}