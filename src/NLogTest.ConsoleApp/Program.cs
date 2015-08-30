using System;
using NLog;

namespace NLogTest.ConsoleApp
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                SingleException();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An unhandled exception occurred");
            }

            try
            {
                InnerException();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An unhandled exception occurred");
            }

            Logger.Info("This is just an informational logging string.");

            Console.WriteLine("Press ENTER to quit...");
            Console.ReadLine();
        }

        static void SingleException()
        {
            throw new Exception("This is a single exception");
        }

        static void InnerException()
        {
            try
            {
                var one = 1;
                var zero = 0;
                var result = one / zero;
            }
            catch (Exception ex)
            {
                throw new Exception("This is a new exception with an inner exception", ex);
            }
        }
    }
}
