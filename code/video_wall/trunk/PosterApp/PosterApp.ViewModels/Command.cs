#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Windows.Input;

#endregion

namespace ViewModels.Helpers
{
    /// <summary>
    ///   Implementation of the ICommand Interface
    /// </summary>
    public class Command : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

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

        #region ICommand Members

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
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }

        /// <summary>
        ///   Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

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
    }
}