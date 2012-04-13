using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Microsoft.Expression.Shapes;
namespace Views
{
    /// <summary>
    /// Interaction logic for CursorAnimation.xaml
    /// </summary>
    public partial class CursorAnimation
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
