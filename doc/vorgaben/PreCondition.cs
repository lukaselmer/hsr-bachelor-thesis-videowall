#region Header
// ------------------------ Licence / Copyright ------------------------
// 
// ScrumTable for Microsoft Team Foundation Server 2010
// Copyright © HSR - Hochschule für Technik Rapperswil 2010
// All Rights Reserved
// 
// Author:
//  Michael Gfeller Silvan Gehrig Patrick Boos
// 
// ---------------------------------------------------------------------
#endregion

using System.Diagnostics;
using ScrumTable.Common.Logging;
using ScrumTable.Common.Properties;

namespace ScrumTable.Common
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    /// Contains PreCondition check features, which allows to throw exceptions
    /// or work with assertions.
    /// </summary>
    public static class PreCondition
    {
        #region Declarations
        //--------------------------------------------------------------------
        // Declarations
        //--------------------------------------------------------------------

        private static volatile bool _assertionsEnabled = false;

        #endregion

        #region Properties
        //--------------------------------------------------------------------
        // Properties
        //--------------------------------------------------------------------

        /// <summary>
        /// Gets or sets if the Debug.Assert() statement should be used in
        /// order to check the conditions.
        /// </summary>
        public static bool EnableDebugAssertions
        {
            get { return _assertionsEnabled; }
            set { _assertionsEnabled = value; }
        }

        #endregion

        #region Constructors / Destructor
        //--------------------------------------------------------------------
        // Constructors / Destructor
        //--------------------------------------------------------------------

        #endregion

        #region Methods
        //--------------------------------------------------------------------
        // Methods
        //--------------------------------------------------------------------

        /// <summary>
        /// Asserts that the given value is in the specified range. Otherwise
        /// an exception (or assertion) will be thrown.
        /// </summary>
        /// <param name="arg">Specifies the argument to check.</param>
        /// <param name="name">Specifies the name of the argument to check.</param>
        /// <param name="lower">Specifies the lower bound (not a valid value).</param>
        /// <param name="upper">Specifies the upper bound (not a valid value).</param>
        public static void AssertInRange<T>(T lower, T upper, T arg, string name)
            where T : IComparable<T>
        {
            AssertTrue(
                arg.CompareTo(lower) > 0,
                () => new ArgumentOutOfRangeException(name, arg, string.Format(Resources.ExcArgOutOfRangeLower, name, arg, lower)));
            AssertTrue(
                arg.CompareTo(upper) < 0,
                () => new ArgumentOutOfRangeException(name, arg, string.Format(Resources.ExcArgOutOfRangeUpper, name, arg, upper)));
        }

        /// <summary>
        /// Asserts that the given string is not null and contains at least
        /// 1 character. Otherwise an exception (or assertion) will be
        /// thrown.
        /// </summary>
        /// <param name="arg">Specifies the argument to check.</param>
        /// <param name="name">Specifies the name of the argument to check.</param>
        public static void AssertNotNullOrEmpty(string arg, string name)
        {
            AssertTrue(!string.IsNullOrEmpty(arg), () => new ArgumentNullOrEmptyException(name));
        }

        /// <summary>
        /// Asserts that the given object is not null. Otherwise an
        /// exception will be thrown.
        /// </summary>
        /// <param name="arg">Specifies the argument to check.</param>
        /// <param name="name">Specifies the name of the argument to check.</param>
        public static void AssertNotNull(object arg, string name)
        {
            AssertTrue(arg != null, () => new ArgumentNullException(name));
        }

        /// <summary>
        /// Asserts that the given condition is true. Otherwise an
        /// exception will be thrown.
        /// </summary>
        /// <param name="condition">Condition which should be true.</param>
        /// <param name="message">Specifies the argument exception message to throw.</param>
        public static void AssertTrue(bool condition, string message)
        {
            AssertTrue(condition, () => new ArgumentException(message ?? Resources.ExcInvalidArgumentException));
        }

        /// <summary>
        /// Asserts that the given condition is true. Otherwise an
        /// exception will be thrown.
        /// </summary>
        /// <param name="condition">Condition which should be true.</param>
        /// <param name="name">Specifies the name of the argument to check.</param>
        /// <param name="message">Specifies the argument exception message to throw.</param>
        public static void AssertTrue(bool condition, string message, string name)
        {
            AssertTrue(condition, () => new ArgumentException(message ?? Resources.ExcInvalidArgumentException, name ?? string.Empty));
        }
        
        /// <summary>
        /// Asserts that the given condition is true. Otherwise the
        /// given exception will be thrown.
        /// </summary>
        /// <param name="condition">Condition which should be true.</param>
        /// <param name="exception">Specifies the exception to throw.</param>
        public static void AssertTrue(bool condition, Exception exception)
        {
            AssertTrue(condition, () => exception);
        }

        private static void AssertTrue(bool condition, Func<Exception> toEvaluateException)
        {
            if (!condition)
            {
                Exception exception = toEvaluateException();
                string errorMessage = exception.Message ?? string.Empty;
                Logger.ErrorFormat(Resources.LogPreConditionAssertionFailed, errorMessage);

                if (EnableDebugAssertions)
                {
                    Debug.WriteLine(string.Format(Resources.LogPreConditionAssertionFailed, errorMessage));
                    Debug.Assert(condition, errorMessage);
                }
                else
                {
                    throw exception;
                }
            }
        }

        #endregion
    }
}
