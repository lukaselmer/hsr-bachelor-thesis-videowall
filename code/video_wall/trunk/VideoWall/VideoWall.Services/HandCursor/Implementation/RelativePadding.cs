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

using VideoWall.Common;

#endregion

namespace VideoWall.ServiceModels.HandCursor.Implementation
{
    /// <summary>
    ///   The relative padding. Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    internal class RelativePadding
    {
        #region Properties

        /// <summary>
        ///   Gets the left padding.
        /// </summary>
        internal double Left { get; private set; }

        /// <summary>
        ///   Gets the top padding.
        /// </summary>
        internal double Top { get; private set; }

        /// <summary>
        ///   Gets the right padding.
        /// </summary>
        internal double Right { get; private set; }

        /// <summary>
        ///   Gets the bottom padding.
        /// </summary>
        internal double Bottom { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="RelativePadding" /> class.
        /// </summary>
        /// <param name="left"> The left padding. </param>
        /// <param name="top"> The top padding. </param>
        /// <param name="right"> The right padding. </param>
        /// <param name="bottom"> The bottom padding. </param>
        public RelativePadding(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            PreOrPostCondition.AssertTrue(Left >= 0.0, "Left must be >= 0");
            PreOrPostCondition.AssertTrue(Top >= 0.0, "Top must be >= 0");
            PreOrPostCondition.AssertTrue(Right >= 0.0, "Right must be >= 0");
            PreOrPostCondition.AssertTrue(Bottom >= 0.0, "Bottom must be >= 0");
            PreOrPostCondition.AssertTrue(Left + Right < 1.0, "left+right < 1.0");
            PreOrPostCondition.AssertTrue(Top + Bottom < 1.0, "top + bottom < 1.0");
        }

        #endregion
    }
}
