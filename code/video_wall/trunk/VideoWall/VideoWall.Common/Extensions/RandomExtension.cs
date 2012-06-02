using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace VideoWall.Common.Extensions
{
    /// <summary>
    /// The random extension for the IEnumerable interface
    /// </summary>
    public static class RandomExtension
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Gets a random element of the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            PreOrPostCondition.AssertNotNull(enumerable, "enumerable");
            if (!enumerable.Any()) return default(T);

            var randomIndex = Random.Next(enumerable.Count());
            return enumerable.ElementAt(randomIndex);
        }
    }
}
