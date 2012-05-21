#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Expression.Shapes;

#endregion

namespace VideoWall.Views.Xaml
{
    /// <summary>
    ///   Interaction logic for CursorAnimation.xaml
    /// </summary>
    public partial class CursorAnimation
    {
        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="CursorAnimation" /> class.
        /// </summary>
        public CursorAnimation()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Inits the storyboard.
        /// </summary>
        /// <param name="interval"> The interval. </param>
        /// <returns> The storyboard. </returns>
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

        #endregion
    }
}