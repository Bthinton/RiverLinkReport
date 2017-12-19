using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RiverLink.Automation;
using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Worker = new Automate(driver, BaseURL, LongWait, ShortWait);
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

        public void GetData()
        {
            ///Log in 
            ///Get vehicle data if not gotten
            ///Goto transaction page
            ///Set page record size max(1000) and verify 
            ///Count number of pages
            ///Goto each page and grab data
            ///insert data into database
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

            List<Vehicle> VehicleList = Worker.GetVehicleData(out Success);

            return returnValue;
        }

        private IWebDriver GetNewDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-extensions");

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
