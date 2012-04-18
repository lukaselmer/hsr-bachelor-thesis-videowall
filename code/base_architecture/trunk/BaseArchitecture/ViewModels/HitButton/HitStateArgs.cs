using System.Windows;

namespace ViewModels.HitButton
{
    /// <summary>
    /// Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class HitStateArgs
    {
        public UIElement UIElement { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HitStateArgs"/> class.
        /// </summary>
        /// <param name="uiElement">The user interface element.</param>
        public HitStateArgs(UIElement uiElement)
        {
            UIElement = uiElement;
        }
    }
}
