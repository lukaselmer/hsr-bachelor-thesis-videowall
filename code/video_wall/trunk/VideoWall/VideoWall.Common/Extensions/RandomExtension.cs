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
using System.Collections.Generic;
using System.Linq;
using VideoWall.Common.Helpers;

#endregion

namespace VideoWall.Common.Extensions
{
    /// <summary>
    ///   The random extension for the IEnumerable interface.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public static class RandomExtension
    {
        private static readonly Random Random = new Random();

        /// <summary>
        ///   Gets a random element of the list.
        /// </summary>
        /// <typeparam name="T"> The interface of the enumerable. </typeparam>
        /// <param name="enumerable"> The enumerable. </param>
        /// <returns> An element of the enumerable list. </returns>
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            PreOrPostCondition.AssertNotNull(enumerable, "enumerable");
            // ReSharper disable PossibleMultipleEnumeration
            // PreOrPostCondition.AssertNotNull is own implementation of assert, 
            // so ReSharper thinks there is no assert, which is worng.
            if (!enumerable.Any()) return default(T);

            var randomIndex = Random.Next(enumerable.Count());
            return enumerable.ElementAt(randomIndex);
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}
