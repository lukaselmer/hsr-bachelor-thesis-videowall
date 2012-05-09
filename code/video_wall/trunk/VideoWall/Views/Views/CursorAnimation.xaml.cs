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
        /// <summary>
        /// Initializes a new instance of the <see cref="CursorAnimation"/> class.
        /// </summary>
        public CursorAnimation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes the storyboard.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <returns></returns>
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
