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

using Common;
using LunchMenuApp.ServiceModels;

#endregion

namespace LunchMenuApp.ViewModels
{
    /// <summary>
    /// The dish view model represents a dish
    /// </summary>
    public class DishViewModel : Notifier
    {
        private string _name;
        private string _type;
        private string _price;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishViewModel"/> class.
        /// </summary>
        /// <param name="dish">The dish.</param>
        public DishViewModel(Dish dish)
        {
            Type = dish.Type;
            Name = dish.Name;
            Price = dish.Price;
        }

        #region Properties

        /// <summary>
        /// Gets the price.
        /// </summary>
        public string Price
        {
            get
            {
                return _price;
            }
            private set
            {
                _price = value;
                Notify("Price");
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }
            private set
            {
                _type = value;
                Notify("Type");
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
                Notify("Name");
            }
        }

        #endregion
    }
}
