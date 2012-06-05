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

using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

#endregion

namespace VideoWall.Views.Helpers
{
    /// <summary>
    /// This class is used to simulate a click on a button. This is used important for the kinect cursor.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal static class ButtonClickSimulator
    {
        #region Methods

        /// <summary>
        ///   Simulates a click on a button.
        /// </summary>
        /// <param name="button"> The button. </param>
        internal static void SimulateClick(this Button button)
        {
            var peer = new ButtonAutomationPeer(button);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            if (invokeProv != null) invokeProv.Invoke();
        }

        #endregion
    }
}