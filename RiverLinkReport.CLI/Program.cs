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
        private Automate auto;

        public static void Main(string[] Args)
        {
            if (Args.Any())
            {
                int option = 0;
                Console.WriteLine("Execute Automated");
                Thread.Sleep(1000);
                while ((option = GetOpt.GetOptions(Args, "u:p:o")) != -1)
                {
                    switch ((char)option)
                    {
                        case 'u':
                            Automate.username = GetOpt.Text;
                            break;
                        case 'p':
                            Automate.password = GetOpt.Text;                          
                            break;
                        case 'o':

                            break;
                        default:
                            return;
                    }
                }
                driver = RiverLinkLogic.GetNewDriver();
                runProgram();
            }
            else
            {              
                DisplayMenu();
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

        public bool TestUsernameAndPassword(string Username, string Password)
        {
            bool returnValue = false;
            if (Username == string.Empty && Password == string.Empty)
            {
                Console.Write("Please enter your username: ");
                Username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                Password = Console.ReadLine();
            }
            
            RiverLinkLogic worker = new RiverLinkLogic("https://riverlink.com/", 2000, 1000, driver);
            worker.StatusChanged += Worker_StatusChanged;
            if (worker.Login(Automate.username, Automate.password))
            {
                Console.WriteLine("Operation Successful");
            }
            else
            {
                Console.WriteLine("Operation failed");
            }
            return returnValue;
        }

        private static void Worker_StatusChanged(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
