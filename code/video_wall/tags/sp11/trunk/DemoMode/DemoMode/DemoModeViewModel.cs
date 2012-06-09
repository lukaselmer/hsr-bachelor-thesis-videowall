using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace DemoMode
{
    public class DemoModeViewModel : Notifier
    {
        private readonly Random _random;
        private Color _currentColor;
        public DemoModeViewModel()
        {
            InitColors();
            ModeTimer = new ModeTimer();
            _random = new Random();
        }

        private void InitColors()
        {
            var blue = new Color() { R = 0, G = 98, B = 158, A = 255};
            var pink = new Color() {R = 200, G = 0, B = 89, A = 255};
            var green = new Color() { R = 132, G = 181, B = 16, A = 255 };
            var orange = new Color() {R = 242, G = 144, B = 0, A = 255};
            Colors = new List<Color>() { blue, pink, green, orange };
            CurrentColor = Colors.First();
        }

        public List<Color> Colors { get; set; }

        
        public Color CurrentColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                Notify("CurrentColor");
            }
        }

        public ModeTimer ModeTimer { get; set; }

        public void ChangeColor()
        {
            CurrentColor = Colors[_random.Next(0, Colors.Count)];
        }
    }
}
