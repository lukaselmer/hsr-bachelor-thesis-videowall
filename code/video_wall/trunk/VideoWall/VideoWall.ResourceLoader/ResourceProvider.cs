﻿#region Header

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
using System.Windows.Controls;

#endregion

namespace VideoWall.ResourceLoader
{
    /// <summary>
    ///   The ResourceProvider is responsible to provide resources
    /// </summary>
    public static class ResourceProvider
    {
        /// <summary>
        ///   The resource dictionary is loaded from the xaml file
        /// </summary>
        private static readonly ResourceDictionary ResourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/VideoWall.ResourceLoader;component/Resources.xaml")
            };

        /// <summary>
        ///   Gets the hand left image.
        /// </summary>
        public static Image HandLeft { get { return Image("handLeft"); } }

        /// <summary>
        ///   Gets the hand right image.
        /// </summary>
        public static Image HandRight { get { return Image("handRight"); } }

        /// <summary>
        ///   Gets the resources.
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary GetResources()
        {
            return ResourceDictionary;
        }

        /// <summary>
        ///   Gets the image from the specified key.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns> </returns>
        private static Image Image(string key)
        {
            return (Image) GetResources()[key];
        }
    }
}