using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;
using System.Windows;

namespace ViewModels.HitButton
{
    public class HitTestHelper
    {
        private readonly ICursorViewModel _cursorViewModel;
        private readonly Window _window;
        private readonly Timer _currentTimer;

        private UIElement _currentElement;

        public event HitStateChanged Started;
        public event HitStateChanged Stopped;
        public event HitStateChanged Clicked;

        private void OnStarted(HitStateArgs args) { if (Started != null) Started(this, args); }
        private void OnStopped(HitStateArgs args) { if (Stopped != null) Stopped(this, args); }
        private void OnClicked(HitStateArgs args) { if (Clicked != null) Clicked(this, args); }

        public HitTestHelper(ICursorViewModel cursorViewModel, Window window, double interval)
        {
            _cursorViewModel = cursorViewModel;
            _window = window;
            _cursorViewModel.PropertyChanged += ModelChanged;
            _currentTimer = new Timer(interval) { AutoReset = true, Enabled = false };
            _currentTimer.Elapsed += OnCurrentTimerOnElapsed;

            Started += (sender, args) => Console.WriteLine("UIElement " + args.UIElement + " started!");
            Stopped += (sender, args) => Console.WriteLine("UIElement " + args.UIElement + " stopped!");
            Clicked += (sender, args) => Console.WriteLine("UIElement " + args.UIElement + " clicked!");
        }

        private void OnCurrentTimerOnElapsed(object sender, ElapsedEventArgs args)
        {
            if (_currentElement != null)
            {
                if (_currentElement.Dispatcher.CheckAccess())
                {
                    OnClicked(CreateHitStateArgs());
                }
                else
                {
                    _currentElement.Dispatcher.Invoke(new Action(() => OnClicked(CreateHitStateArgs())));
                }
            }
        }

        private void ModelChanged(object sender, PropertyChangedEventArgs e)
        {
            foreach (var button in HitElements)
            {
                var relativePosition = _window.TranslatePoint(_cursorViewModel.Position, button);
                var hit = button.InputHitTest(relativePosition) != null;

                // if the current element is the hit button and it is not hit, stop the timer
                if (_currentElement == button && !hit) { StopTimer(); continue; }

                // if the element was not hit, move to the nexe element
                if (!hit) continue;

                // if the current element is the hit element, than the timer has been started already
                if (_currentElement == button) continue;

                // if a new element is hit, the old timer must be stopped
                if (_currentElement != null) StopTimer();

                StartTimer(button);
            }
        }

        private void StartTimer(UIElement button)
        {
            _currentElement = button;
            _currentTimer.Start();
            OnStarted(CreateHitStateArgs());
        }

        private void StopTimer()
        {
            _currentTimer.Stop();
            OnStopped(CreateHitStateArgs());
            _currentElement = null;
        }

        private HitStateArgs CreateHitStateArgs()
        {
            return new HitStateArgs(_currentElement);
        }

        public IEnumerable<UIElement> HitElements { get; set; }
    }
}