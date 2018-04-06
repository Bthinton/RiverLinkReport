using FileHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RiverLink.Automation;
using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RiverLink.DAL;
using System.Data.Entity;


namespace RiverLinkReport.BAL
{
    public class RiverLinkLogic
    {
        #region Fields
        private string StatusMessage = string.Empty;
        public IWebDriver driver;
        public List<int> DriverProcessIds { get; set; }
        private string BaseURL = string.Empty;
        private int ShortWait = 1000;
        private int LongWait = 2000;

        private Automate Worker;
        #endregion Fields

        #region Constructors
        public RiverLinkLogic(string URL, int LWait, int SWait)
        {

            driver = GetNewDriver();
            BaseURL = URL;
            LongWait = LWait;
            ShortWait = SWait;
            var context = new RiverLink.DAL.DB();
            List<VehicleClass> VehicleClasses = context.VehicleClassess.ToList();
            Worker = new Automate(driver, BaseURL, LongWait, ShortWait, VehicleClasses);
            Worker.StatusChanged += Worker_StatusChanged;
        }

        #endregion Constructors

        #region Events
        public delegate void StatusChangedEventHandler(string Message);

        public event StatusChangedEventHandler StatusChanged;
        protected virtual void OnStatusChanged(string Message)
        {
            if (StatusChanged != null)
                StatusChanged(Message);
        }
        #endregion Events

        public static void ImportVehicleData()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            string dataDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}\Data\";
            string filePath = string.Empty;
            var engine = new FileHelperEngine<Vehicle>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (Directory.Exists(dataDirectory))
            {
                string[] filePaths = Directory.GetFiles(dataDirectory, "Vehicle*.txt");
                foreach (var file in filePaths)
                {
                    var result = engine.ReadFile(file);
                    foreach (Vehicle v in result)
                    {
                        Console.WriteLine("Vehicle Info:");
                        Console.WriteLine(v.Model + " - ");
                        using (var context = new DB())
                        {
                            context.Vehicles.Add(v);
                            context.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                throw new Exception($"Error {method}: Unable to find data directory {dataDirectory}");
            }
        }

        public bool GetData()
        {
            bool returnValue = true;
            string Success = string.Empty;

            List<Vehicle> VehicleList = Worker.GetVehicleData(out Success);
            if (Success != "Success")
            {
                return false;
            }

            Success = Worker.GoToTransactionHistory(string.Empty);
            if (Success != "Success")
            {
                return false;
            }

            List<Transaction> TransactionList = Worker.GetTransactionData(out Success);

            ///Log in 
            ///Get vehicle data if not gotten
            ///Goto transaction page
            ///Set page record size max(1000) and verify 
            ///Count number of pages
            ///Goto each page and grab data
            ///insert data into database

            return returnValue;
        }

        public bool Login()
        {
            bool returnValue = true;
            string Success = string.Empty;

            Success = Worker.GoToHomePage(string.Empty);
            if (Success != "Success")
            {
                return false;
            }
            Success = Worker.GoToLoginPage(string.Empty);
            if (Success != "Success")
            {
                return false;
            }
            Success = Worker.Login(string.Empty);
            if (Success != "Success")
            {
                return false;
            }

            GetData();

            return returnValue;
        }

        private IWebDriver GetNewDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-extensions --disable-accelerated-video-decode");

            Process[] before = Process.GetProcessesByName("chrome");
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            Process[] after = Process.GetProcessesByName("chrome");
            List<int> beforeIds = before.Select(x => x.Id)?.ToList();
            List<int> afterIds = after.Select(x => x.Id)?.ToList();
            DriverProcessIds = afterIds.Except(beforeIds).ToList();

            return driver;
        }

        public static Process GetProcByID(int id)
        {
            Process[] processlist = Process.GetProcesses();
            return processlist.FirstOrDefault(pr => pr.Id == id);
        }

        public static void KillById(int processId)
        {
            Process process = GetProcByID(processId);
            if (process != null && !process.HasExited)
                process.Kill();
        }

        private void Worker_StatusChanged(string Message)
        {
            OnStatusChanged(Message);
        }

    }
}
