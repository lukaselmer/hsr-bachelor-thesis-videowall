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

using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.ViewHelpers;

#endregion

namespace LunchMenuApp.ViewModels
{
    /// <summary>
    ///   The dish view model represents a dish.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class DishViewModel : Notifier
    {
        #region Declarations

        /// <summary>
        /// The name of the dish.
        /// </summary>
        private string _name;

        /// <summary>
        /// The price of the dish.
        /// </summary>
        private string _price;

        /// <summary>
        /// The type of the dish (e.g. Tagesteller, Dauerbrenner, ...)
        /// </summary>
        private string _type;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the price.
        /// </summary>
        public string Price
        {
            get { return _price; }
            private set
            {
                _price = value;
                Notify("Price");
            }
        }

        /// <summary>
        ///   Gets the type.
        /// </summary>
        public string Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                Notify("Type");
            }
        }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                Notify("Name");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="DishViewModel" /> class.
        /// </summary>
        /// <param name="dish"> The dish. </param>
        public DishViewModel(IDish dish)
        {
            Type = dish.Type;
            Name = dish.Name;
            Price = dish.Price;
        }

        #endregion
    }
}
