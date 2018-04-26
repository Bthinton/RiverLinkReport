﻿using FileHelpers;
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
        private static List<VehicleClass> VehicleClassList = new List<VehicleClass>();

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
            List<VehicleClass> VehicleClasses = context.VehicleClasses.ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Vehicle> GetVehicleData(string FileName)
        {
            List<Vehicle> returnValue = new List<Vehicle>();
            var engine = new FileHelperEngine<VehicleData>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var result = engine.ReadFile(FileName);
            foreach (VehicleData vd in result)
            {
                Classifications Classification = Classifications.Class1;
                if (vd.VehicleClass.ToLower() == "class 1")
                {
                    Classification = Classifications.Class1;
                }
                if (vd.VehicleClass.ToLower() == "class 2")
                {
                    Classification = Classifications.Class2;
                }
                if (vd.VehicleClass.ToLower() == "class 3")
                {
                    Classification = Classifications.Class3;
                }
                PopulateVehicleClasses();
                Vehicle v = new Vehicle
                {
                    PlateNumber = vd.PlateNumber,
                    Make = vd.Make,
                    Model = vd.Model,
                    Year = vd.Year,
                    VehicleState = vd.VehicleState,
                    VehicleStatus = vd.VehicleStatus,
                    Classification = Classification,
                    VehicleClass = VehicleClassList.FirstOrDefault(x => x.Classification == Classification)
                };
                returnValue.Add(v);
            }
            return returnValue;
        }

        private static void PopulateVehicleClasses()
        {
            if (!VehicleClassList.Any())
            {
                using (var context = new DB())
                {
                    VehicleClassList = context.VehicleClasses.ToList();
                }
            }
        }

        public static List<Transponder> GetTransponderData(string FileName)
        {
            List<Transponder> returnValue = new List<Transponder>();
            var engine = new FileHelperEngine<VehicleData>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var result = engine.ReadFile(FileName);
            foreach (VehicleData v in result)
            {
                TransponderTypes TransponderType = TransponderTypes.Sticker;
                if (v.TransponderType.ToLower() == "ezp")
                {
                    TransponderType = TransponderTypes.EZPass;
                }
                Transponder t = new Transponder
                {
                    TransponderNumber = v.Transponder,
                    TransponderType = TransponderType
                };
                returnValue.Add(t);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the transaction data.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public static List<Transaction> GetTransactionData(string FileName)
        {
            List<Transaction> returnValue = new List<Transaction>();
            var engine = new FileHelperEngine<Transaction>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var result = engine.ReadFile(FileName);
            foreach (Transaction td in result)
            {
                Transaction t = new Transaction
                {
                    Plaza = td.Plaza,
                    TransactionStatus = td.TransactionStatus,
                    TransactionType = td.TransactionType,
                    Transaction_Id = td.Transaction_Id,
                    TransactionDate = td.TransactionDate,
                    PostedDate = td.PostedDate,
                    Journal_Id = td.Journal_Id,
                    Vehicle = td.Vehicle,
                    Amount = td.Amount,
                    Lane = td.Lane,
                    Transponder = td.Transponder,
                    TransactionDescription = td.TransactionDescription
                };
                returnValue.Add(t);
            }
            return returnValue;
        }

        public static bool InsertVehicleData(List<Vehicle> Vehicles)
        {
            bool returnValue = false;
            using (var context = new DB())
            {
                var ExistingVehicles = context.Vehicles.ToList();
                foreach (var v in Vehicles)
                {
                    var ExistingVehicle = ExistingVehicles.SingleOrDefault(x => x.PlateNumber == v.PlateNumber);
                    if (ExistingVehicle == null)
                    {
                        context.VehicleClasses.Attach(v.VehicleClass);
                        context.Vehicles.Add(v);
                    }
                }
                if (context.ChangeTracker.HasChanges())
                {
                    context.SaveChanges();
                }
            }
            return returnValue;
        }

        public static bool InsertTransponderData(List<Transponder> Transponders)
        {
            bool returnValue = false;
            using (var context = new DB())
            {
                var ExistingTransponders = context.Transponders.ToList();
                foreach (var t in Transponders)
                {
                    var ExistingTransponder = ExistingTransponders.SingleOrDefault(x => x.TransponderNumber == t.TransponderNumber);
                    if (ExistingTransponder == null)
                    {
                        context.Transponders.Add(t);
                    }
                }
                if (context.ChangeTracker.HasChanges())
                {
                    context.SaveChanges();
                }
            }
            return returnValue;
        }

        public static bool InsertTransactionData(List<Transaction> Transactions)
        {
            bool returnValue = false;
            using (var context = new DB())
            {
                var ExistingTransactions = context.Transactions.ToList();
                foreach (var t in Transactions)
                {
                    var ExistingTransaction = ExistingTransactions.SingleOrDefault(x => x.Transaction_Id == t.Transaction_Id);
                    if (ExistingTransaction == null)
                    {
                        context.Transactions.Add(t);
                    }
                }
                if (context.ChangeTracker.HasChanges())
                {
                    context.SaveChanges();
                }
            }
            return returnValue;
        }

        public static bool InsertData()
        {
            bool returnValue = false;
            string dataDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}\Data\";
            string filePath = string.Empty;
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (Directory.Exists(dataDirectory))
            {
                string[] filePaths = Directory.GetFiles(dataDirectory, "*.txt");
                foreach (var file in filePaths)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Name.ToLower().Contains("vehicle"))
                    {
                        List<Transponder> transponderList = GetTransponderData(file);
                        InsertTransponderData(transponderList);
                        List<Vehicle> vehicleList = GetVehicleData(file);
                        InsertVehicleData(vehicleList);
                    }
                    //if (fi.Name.ToLower().Contains("transaction"))
                    //{
                    //    List<Transaction> transactionList = GetTransactionData(file);
                    //    InsertTransactionData(transactionList);

                    //}
                }
            }
            else
            {
                throw new Exception($"Error {method}: Unable to find data directory {dataDirectory}");
            }
        return returnValue;
        }

        public List<Transponder> GetTransponders(string FileName)
        {
            List<Transponder> returnValue = new List<Transponder>();
            return returnValue;
        }

        public bool GetData()
        {
            bool returnValue = true;
            string Success = string.Empty;

            List<VehicleData> VehicleList = Worker.GetVehicleData(out Success);
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
