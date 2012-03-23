using System.Windows;
using System.Windows.Input;

namespace HandCursorDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Cursor = Cursors.None;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var pos = e.GetPosition(MyGrid);
            Hand.Margin = new Thickness(pos.X - 80, pos.Y - 80, 0, 0);
        }
    }
}
