using NLog;
using OpenQA.Selenium;
using RiverLinkReport.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RiverLinkReport.CLI
{
    class Program
    {
        private readonly static Logger nlogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly static string AppName = "RiverLinkReportCli";
        private readonly static int MillisecondsBetweenTransactions = 2000;
        private readonly static int TimeBetweenErrors = 2000;
        private delegate void DisplayDelegate(string text);
        public static IWebDriver driver;
        public static List<int> DriverProcessIds { get; set; }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                int userInput = 0;
                do
                {
                    userInput = DisplayMenu();

                    switch (userInput)
                    {
                        case 1:
                            TestUsernameAndPassword(string.Empty, string.Empty);
                            break;
                        case 2:
                            Console.WriteLine("You picked 2.");
                            break;                            
                        case 5:
                            RiverLinkLogic.ImportVehicleData();
                            break;
                        //case 6:
                        //    riverlinklogic.importtransactiondata();
                        //    break;
                        default:
                            break;
                    }

                } while (userInput != 5);
            } else
            {
                Console.WriteLine(args[0]);
            }

            
            Console.Read();
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("Report Data Manager");
            Console.WriteLine();
            Console.WriteLine("1. Test Password");
            Console.WriteLine("2. Send Email Alert");
            Console.WriteLine("3. Send SMS Alert");
            Console.WriteLine("4. Send Debug Package");
            Console.WriteLine("5. Import Vehicle Data");
            Console.WriteLine("6. Import Transaction Data");
            Console.WriteLine("7. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(GetNumbers(result));
        }

        private static string GetNumbers(string input)
        {
            string cleanString = new string(input.Where(c => char.IsDigit(c)).ToArray());
            if (cleanString == String.Empty)
            {
                cleanString = "0";
            }
            return cleanString;
        }

        private void PauseService(int SleepTime)
        {
            int minRemaining = (SleepTime / 1000) / 60;
            LogMessage(NLog.LogLevel.Debug, $"Service paused for {minRemaining} minutes...", 0, 0, string.Empty);

            while (SleepTime > 0)
            {
                minRemaining = (SleepTime / 1000) / 60;
                Console.Write($"\rService paused, {minRemaining} minutes remaining...");
                Thread.Sleep(TimeBetweenErrors);
                SleepTime -= TimeBetweenErrors;
            }
        }

        private static void LogMessage(NLog.LogLevel logLevel, string message, int AppId, int TransactionId, string ErrorName)
        {
            try
            {
                LogEventInfo theEvent = new LogEventInfo(logLevel, "", message);
                theEvent.Properties["appname"] = AppName;
                theEvent.Properties["appid"] = AppId;
                theEvent.Properties["transaction_id"] = TransactionId;
                theEvent.Properties["errorname"] = ErrorName;
                theEvent.LoggerName = nlogger.Name;
                nlogger.Log(theEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static bool TestUsernameAndPassword(string Username, string Password)
        {
            bool returnValue = false;
            if (Username == string.Empty && Password == string.Empty)
            {
                Console.Write("Please enter your username: ");
                Username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                Password = Console.ReadLine();
            }

            RiverLinkLogic worker = new RiverLinkLogic("https://riverlink.com/", 2000, 1000);
            worker.StatusChanged += Worker_StatusChanged;
            if (worker.Login())
            {
                Console.WriteLine("You have logged in");
            } else
            {
                Console.WriteLine("Login failed");
            }
            return returnValue;
        }

        private static void Worker_StatusChanged(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
