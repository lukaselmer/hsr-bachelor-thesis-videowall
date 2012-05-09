using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Views.Helpers
{
    static class ButtonClickSiumulator
    {
        /// <summary>
        /// Simulates a click on a button.
        /// </summary>
        /// <param name="button">The button.</param>
        public static void SimulateClick(this Button button)
        {
            var peer = new ButtonAutomationPeer(button);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            Debug.Assert(invokeProv != null, "invokeProv != null");
            invokeProv.Invoke();
        }
    }
}
