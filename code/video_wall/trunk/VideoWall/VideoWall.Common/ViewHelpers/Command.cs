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

using System;
using System.Windows.Input;

#endregion

namespace VideoWall.Common.ViewHelpers
{
    /// <summary>
    ///   Implementation of the ICommand Interface
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class Command : ICommand
    {
        #region Declarations

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="execute"> The execute action. </param>
        /// <param name="canExecute"> The canexecute predicate. </param>
        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="execute"> The execute action. </param>
        public Command(Action<object> execute)
        {
            _execute = execute;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"> Data used by the command. If the command does not require data to be passed, this object can be set to null. </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        ///   Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter"> Data used by the command. If the command does not require data to be passed, this object can be set to null. </param>
        /// <returns> true if this command can be executed; otherwise, false. </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        ///   Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}