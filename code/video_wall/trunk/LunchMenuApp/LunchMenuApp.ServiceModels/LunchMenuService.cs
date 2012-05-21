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

using LunchMenuApp.Data;
using VideoWall.Common;

#endregion

namespace LunchMenuApp.ServiceModels
{
    /// <summary>
    ///   The LunchMenuService.
    /// </summary>
    public class LunchMenuService : Notifier
    {
        private LunchMenu _lunchMenu;

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuService" /> class.
        /// </summary>
        /// <param name="lunchMenuReader"> The lunch menu reader. </param>
        public LunchMenuService(LunchMenuReader lunchMenuReader)
        {
            LunchMenuReader = lunchMenuReader;
            var k = LunchMenuReader.Html;
            // TODO: wie suche ich korrekt nach einem im HTML enthaltenen div-tag? -> workaround for weekends
            /* <div class="date-missing">
				<div class="date-missing-content">
					Für diesen Betrieb ist kein aktueller Menuplan verfügbar.
				</div>
			</div>*/
            LunchMenu = (string.IsNullOrEmpty(LunchMenuReader.Html) || LunchMenuReader.Html.Contains("date-missing-content")) ? null : new LunchMenu(LunchMenuReader.Html);
        }

        private LunchMenuReader LunchMenuReader { get; set; }

        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        public LunchMenu LunchMenu
        {
            get { return _lunchMenu; }
            set
            {
                _lunchMenu = value;
                Notify("LunchMenu");
            }
        }
    }
}
