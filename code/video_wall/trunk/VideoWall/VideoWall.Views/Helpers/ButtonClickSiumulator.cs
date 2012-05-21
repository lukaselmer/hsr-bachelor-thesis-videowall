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
    internal static class ButtonClickSiumulator
    {
        /// <summary>
        ///   Simulates a click on a button.
        /// </summary>
        /// <param name="button"> The button. </param>
        public static void SimulateClick(this Button button)
        {
            var peer = new ButtonAutomationPeer(button);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            if (invokeProv != null) invokeProv.Invoke();
        }
    }
}