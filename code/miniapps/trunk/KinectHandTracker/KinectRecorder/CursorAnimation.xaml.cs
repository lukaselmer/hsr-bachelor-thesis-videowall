using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Expression.Shapes;

namespace Views
{
    /// <summary>
    /// Interaction logic for CursorAnimation.xaml
    /// </summary>
    public partial class CursorAnimation : UserControl
    {
        public CursorAnimation()
        {
            InitializeComponent();
        }

        public Storyboard InitStoryboard(double interval)
        {
            var dAnim = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.FromMilliseconds(interval))
            };


            var storyboard = new Storyboard();
            storyboard.Children.Add(dAnim);

            Storyboard.SetTargetName(dAnim, CursorCircle.Name);
            Storyboard.SetTargetProperty(dAnim, new PropertyPath(Arc.EndAngleProperty));

            return storyboard;
        }
    }
}
