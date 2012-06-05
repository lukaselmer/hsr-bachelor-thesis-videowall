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

using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.Helpers;

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The dish.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class Dish : IDish
    {
        #region Properties

        /// <summary>
        ///   Gets the type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///   Gets the price.
        /// </summary>
        public string Price { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="Dish" /> class.
        /// </summary>
        /// <param name="type"> The type. </param>
        /// <param name="name"> The name. </param>
        /// <param name="price"> The price. </param>
        public Dish(string type, string name, string price)
        {
            PreOrPostCondition.AssertNotNull(type, "type");
            PreOrPostCondition.AssertNotNull(name, "name");
            PreOrPostCondition.AssertNotNull(price, "price");

            Type = type;
            Name = name;
            Price = price;
        }

        #endregion
    }
}
