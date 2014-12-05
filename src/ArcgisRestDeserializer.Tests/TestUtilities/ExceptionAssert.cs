using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcgisRestDeserializer.Tests.TestUtilities
{
    /// <summary>
    /// Extensions for testing exceptions
    /// </summary>
    internal class ExceptionAssert
    {
        public static void Throws<TException>(string message, Action action, string assertMessage = null)
            where TException : Exception
        {
            try
            {
                action();

                Assert.Fail(assertMessage + Environment.NewLine + "Exception of type {0} expected; got none exception", typeof(TException).Name);
            }
            catch (TException ex)
            {
                if (message != null)
                    Assert.AreEqual(message, ex.Message,
                        assertMessage + Environment.NewLine + "Unexpected exception message." + Environment.NewLine + "Expected: " + message + Environment.NewLine + "Got: " + ex.Message +
                        Environment.NewLine + Environment.NewLine + ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(assertMessage + Environment.NewLine + "Exception of type {0} expected; got exception of type {1}.", typeof(TException).Name, ex.GetType().Name), ex);
            }
        }

        public static void Throws<TException>(Action action, string assertMessage = null)
            where TException : Exception
        {
            try
            {
                action();

                Assert.Fail(assertMessage + Environment.NewLine + "Exception of type {0} expected; got none exception", typeof(TException).Name);
            }
            catch (TException) { }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(assertMessage + Environment.NewLine + "Exception of type {0} expected; got exception of type {1}.", typeof(TException).Name, ex.GetType().Name), ex);
            }
        }
    }
}