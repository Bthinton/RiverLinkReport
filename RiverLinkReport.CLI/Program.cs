using CommandLine;
using NLog;
using OpenQA.Selenium;
using RiverLink.Automation;
using RiverLink.CLI;
using RiverLinkReport.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace RiverLinkReport.CLI
{
    public class Program
    {
        private static readonly Logger nlogger = LogManager.GetCurrentClassLogger();
        private static readonly string AppName = "RiverLinkReportCli";
        private static readonly int MillisecondsBetweenTransactions = 2000;
        private static readonly int TimeBetweenErrors = 2000;
        private delegate void DisplayDelegate(string text);
        public static IWebDriver driver;
        public static List<int> DriverProcessIds { get; set; }
        public static bool test;
        public static string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public static void Main(string[] args)
        {
            try
            {
                if (args.Any())
                {
                    var cmdOptions = Parser.Default.ParseArguments<ProgramOptions>(args);
                    cmdOptions.WithParsed(
                        options => {
                            HandleCommandLine(options);
                        });
                }
                else
                {
                    DisplayMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{methodName} unexpected error: {e}");
                throw new Exception($"{methodName} unexpected error: {e}");
            }
        }

        private static void HandleCommandLine(ProgramOptions options)
        {
            if (options.Username != null)
            {
                Automate.username = options.Username;
            }

            if (options.Password != null)
            {
                Automate.password = options.Password;
            }

            if (options.Operation != null)
            {
                driver = RiverLinkLogic.GetNewDriver();
                runProgram();
            }
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

        private static void runProgram()
        {
            try
            {
                RiverLinkLogic Logic = new RiverLinkLogic("https://riverlink.com/", 2000, 1000, driver);
                Logic.PrimaryStatusChanged += Logic_PrimaryStatusChanged;
                Logic.SecondaryStatusChanged += Logic_SecondaryStatusChanged;
                Logic.Login(Automate.username, Automate.password);
                Logic.GetData();
                Logic.InsertData();
                driver.Close();
                appExit();
            }
            catch (Exception)
            {
                closeBrowser();
                
                throw;
            }
            finally
            {
                closeBrowser();
            }        
        }

        private static void Logic_PrimaryStatusChanged(string Message)
        {
            Console.WriteLine(Message);
        }

        private static void Logic_SecondaryStatusChanged(string Message)
        {
            Console.WriteLine(Message);
        }

        private static void closeBrowser()
        {
            if (driver != null)
            {
                driver.Close();
            }
            foreach (var process in RiverLinkLogic.DriverProcessIds)
            {
                RiverLinkLogic.KillById(process);
            }
        }

        private static void appExit()
        {
            Application.Exit();
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

        public static bool TestUsernameAndPassword(string Username, string Password)
        {
            bool returnValue = false;
            if (Username == string.Empty && Password == string.Empty)
            {
                Console.Write("Please enter your username: ");
                Username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                Password = Console.ReadLine();
            }
            driver = RiverLinkLogic.GetNewDriver();
            RiverLinkLogic worker = new RiverLinkLogic("https://riverlink.com/", 2000, 1000, driver);
            worker.StatusChanged += Worker_StatusChanged;
            if (worker.Login(Username, Password))
            {
                Console.WriteLine("Operation Successful");
                test = true;
            }
            else
            {
                Console.WriteLine("Operation failed");
                test = false;
            }
            return returnValue;
        }

        private static void Worker_StatusChanged(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
