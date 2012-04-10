using System.Windows;

namespace ViewModels.HitButton
{
    public class HitStateArgs
    {
        public UIElement UIElement { get; private set; }

        public HitStateArgs(UIElement uiElement)
        {
            UIElement = uiElement;
        }
    }
}