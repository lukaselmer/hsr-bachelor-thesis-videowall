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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using VideoWall.ViewModels.Cursor;

#endregion

namespace VideoWall.ViewModels.HitButton
{
    /// <summary>
    ///   The HitTestHelper. When the position of the ICursorViewModel is changed, this class 
    ///   will test if the cursor is over a button. A timer will be started as soon as the cursor 
    ///   is over an element. The element will be clicked after a timer elapsed.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 17.04.2012 
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class HitTestHelper
    {
        #region Declarations

        /// <summary>
        /// The click timer.
        /// </summary>
        private readonly DispatcherTimer _clickTimer;

        /// <summary>
        /// The cursor view model.
        /// </summary>
        private readonly ICursorViewModel _cursorViewModel;

        /// <summary>
        /// The window.
        /// </summary>
        private readonly Window _window;

        /// <summary>
        /// The current ui element
        /// </summary>
        private UIElement _currentElement;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the hit elements.
        /// </summary>
        /// <value> The hit elements. </value>
        public IEnumerable<UIElement> HitElements { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the timer is started.
        /// </summary>
        public event EventHandler<HitStateArgs> Started;

        /// <summary>
        ///   Occurs when the timer is stopped.
        /// </summary>
        public event EventHandler<HitStateArgs> Stopped;

        /// <summary>
        ///   Occurs when a element is clicked.
        /// </summary>
        public event EventHandler<HitStateArgs> Clicked;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="HitTestHelper" /> class.
        /// </summary>
        /// <param name="cursorViewModel"> The cursor view model. </param>
        /// <param name="window"> The window. </param>
        /// <param name="interval"> The interval. </param>
        public HitTestHelper(ICursorViewModel cursorViewModel, Window window, TimeSpan interval)
        {
            _cursorViewModel = cursorViewModel;
            _window = window;
            _cursorViewModel.PropertyChanged += OnModelChanged;
            _clickTimer = new DispatcherTimer { Interval = interval };
            _clickTimer.Tick += OnClickTimerElapsed;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Called when started.
        /// </summary>
        /// <param name="args"> The args. </param>
        private void OnStarted(HitStateArgs args)
        {
            if (Started != null) Started(this, args);
        }

        /// <summary>
        ///   Called when stopped.
        /// </summary>
        /// <param name="args"> The args. </param>
        private void OnStopped(HitStateArgs args)
        {
            if (Stopped != null) Stopped(this, args);
        }

        /// <summary>
        ///   Called when clicked.
        /// </summary>
        /// <param name="args"> The args. </param>
        private void OnClicked(HitStateArgs args)
        {
            if (Clicked != null) Clicked(this, args);
        }

        /// <summary>
        ///   Called when current timer has elapsed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The <see cref="System.Timers.ElapsedEventArgs" /> instance containing the event data. </param>
        private void OnClickTimerElapsed(object sender, EventArgs args)
        {
            if (_currentElement == null) return;
            if (_currentElement.Dispatcher.CheckAccess()) OnClicked(CreateHitStateArgs());
            else _currentElement.Dispatcher.Invoke(new Action(() => OnClicked(CreateHitStateArgs())));
        }

        /// <summary>
        ///   Called when model changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO: this could be refactored?

            foreach (var element in HitElements)
            {
                var relativePosition = _window.TranslatePoint(_cursorViewModel.Position, element);
                var hit = element.InputHitTest(relativePosition) != null;

                // if the current element is the same as the element but that one was not hit, stop the timer
                if (_currentElement == element && !hit)
                {
                    StopTimerAndResetCurrentElement();
                    continue;
                }

                // if the button was not hit, move to the next element
                if (!hit) continue;

                // if the current element is the hit element, than the timer has been started already
                if (_currentElement == element) continue;

                // if a new element is hit, the old timer must be stopped
                if (_currentElement != null) StopTimerAndResetCurrentElement();

                StartTimerAndSetCurrentElementTo(element);
            }
        }

        /// <summary>
        ///   Starts the timer and sets the current element to the given parameter.
        /// </summary>
        /// <param name="button"> The button. </param>
        private void StartTimerAndSetCurrentElementTo(UIElement button)
        {
            _currentElement = button;
            _clickTimer.Start();
            OnStarted(CreateHitStateArgs());
        }

        /// <summary>
        ///   Stops the timer ans resets the current element.
        /// </summary>
        private void StopTimerAndResetCurrentElement()
        {
            _clickTimer.Stop();
            OnStopped(CreateHitStateArgs());
            _currentElement = null;
        }

        /// <summary>
        ///   Creates the hit state arguments.
        /// </summary>
        /// <returns> </returns>
        private HitStateArgs CreateHitStateArgs()
        {
            return new HitStateArgs(_currentElement);
        }

        #endregion
    }
}
