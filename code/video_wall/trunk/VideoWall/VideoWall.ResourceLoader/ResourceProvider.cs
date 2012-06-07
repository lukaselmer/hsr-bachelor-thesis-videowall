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
using System.Threading;
using System.Windows;
using System.Windows.Controls;

#endregion

namespace VideoWall.ResourceLoader
{
    /// <summary>
    ///   The ResourceProvider is responsible for providing resources.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public static class ResourceProvider
    {
        #region Declarations

        /// <summary>
        ///   The resource dictionary is loaded from the xaml file.
        ///   It is wrapped in a thread local because like this the resources are available in every thread. This
        ///   is especially important for the unit tests because they run parallel in multiple threads.
        /// </summary>
        static readonly ThreadLocal<ResourceDictionary> ResourceDictionary = new ThreadLocal<ResourceDictionary>(() => new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/VideoWall.ResourceLoader;component/Resources.xaml")
        });

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the hand left image.
        /// </summary>
        public static Image HandLeft { get { return Image("handLeft"); } }

        /// <summary>
        ///   Gets the hand right image.
        /// </summary>
        public static Image HandRight { get { return Image("handRight"); } }

        #endregion

        #region Methods

        /// <summary>
        ///   Gets the resources.
        /// </summary>
        /// <returns> </returns>
        private static ResourceDictionary GetResources()
        {
            return ResourceDictionary.Value;
        }

        /// <summary>
        ///   Gets the image from the specified key.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns> </returns>
        private static Image Image(string key)
        {
            return GetResources()[key] as Image;
        }

        #endregion
    }
}
