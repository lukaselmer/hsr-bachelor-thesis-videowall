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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

#endregion

namespace VideoWall.Views.Helpers
{
    internal static class ExtendedVisualTreeHelper
    {
        internal static IEnumerable<TSearched> FindInVisualTreeDown<TSearched>(DependencyObject obj) where TSearched : class
        {
            if (obj == null) yield break;
            var typedObj = obj as TSearched;
            if (typedObj != null) yield return typedObj;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var children = FindInVisualTreeDown<TSearched>(VisualTreeHelper.GetChild(obj, i));
                foreach (var child in children.Where(child => child != null))
                {
                    yield return child;
                }
            }
        }
    }
}