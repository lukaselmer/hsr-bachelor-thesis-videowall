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
using VideoWall.Common.Logging;

#endregion

namespace VideoWall.Common.Helpers
{
    /// <summary>
    ///   Contains PreOrPostCondition check features, which allows to throw exceptions or work with assertions.
    /// </summary>
    /// <remarks>
    ///   Contains parts from ScrumTable (HSR, 2010) Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public static class PreOrPostCondition
    {
        #region Methods

        /// <summary>
        ///   Asserts that the given value is in the specified range. Otherwise an exception (or assertion) will be thrown.
        /// </summary>
        /// <typeparam name="T"> The interface of the parameters. </typeparam>
        /// <param name="lower"> Specifies the lower bound (a valid value). </param>
        /// <param name="upper"> Specifies the upper bound (a valid value). </param>
        /// <param name="arg"> Specifies the argument to check. </param>
        /// <param name="name"> Specifies the name of the argument to check. </param>
        public static void AssertInRange<T>(T lower, T upper, T arg, string name)
            where T : IComparable<T>
        {
            AssertTrue(
                arg.CompareTo(lower) >= 0,
                () => new ArgumentOutOfRangeException(name, arg, string.Format("Argument {0} = {1} is too small, lower limit is {2}", name, arg, lower)));
            AssertTrue(
                arg.CompareTo(upper) <= 0,
                () => new ArgumentOutOfRangeException(name, arg, string.Format("Argument {0} = {1} is too big, upper limit is {2}", name, arg, upper)));
        }

        /// <summary>
        ///   Asserts that the given object is not null. Otherwise an exception will be thrown.
        /// </summary>
        /// <param name="arg"> Specifies the argument to check. </param>
        /// <param name="name"> Specifies the name of the argument to check. </param>
        public static void AssertNotNull(object arg, string name)
        {
            AssertTrue(arg != null, () => new ArgumentNullException(name));
        }

        /// <summary>
        ///   Asserts that the given object is not null or empty. Otherwise an exception will be thrown.
        /// </summary>
        /// <param name="arg"> The string to be checked. </param>
        /// <param name="name"> The name. </param>
        public static void AssertNotNullOrEmpty(string arg, string name)
        {
            AssertTrue(!String.IsNullOrEmpty(arg), () => new ArgumentNullException(name));
        }

        /// <summary>
        ///   Asserts that the given condition is true. Otherwise an exception will be thrown.
        /// </summary>
        /// <param name="condition"> Condition which should be true. </param>
        /// <param name="message"> Specifies the argument exception message to throw. </param>
        public static void AssertTrue(bool condition, string message)
        {
            AssertTrue(condition, () => new ArgumentException(message ?? "Argument must be true"));
        }

        /// <summary>
        ///   Asserts that the given condition is true. Otherwise an exception will be thrown.
        /// </summary>
        /// <param name="condition"> Condition which should be true. </param>
        /// <param name="name"> Specifies the name of the argument to check. </param>
        /// <param name="message"> Specifies the argument exception message to throw. </param>
        public static void AssertTrue(bool condition, string message, string name)
        {
            AssertTrue(condition, () => new ArgumentException(message ?? "Argument must be true", name ?? string.Empty));
        }

        /// <summary>
        ///   Asserts that the given condition is true. Otherwise the given exception will be thrown.
        /// </summary>
        /// <param name="condition"> Condition which should be true. </param>
        /// <param name="exception"> Specifies the exception to throw. </param>
        public static void AssertTrue(bool condition, Exception exception)
        {
            AssertTrue(condition, () => exception);
        }

        private static void AssertTrue(bool condition, Func<Exception> toEvaluateException)
        {
            if (condition) return;

            var exception = toEvaluateException();
            var errorMessage = exception.Message;

            Logger.Get.Error(String.Format("Precondition failed: {0}", errorMessage));

            throw exception;
        }

        #endregion
    }
}
