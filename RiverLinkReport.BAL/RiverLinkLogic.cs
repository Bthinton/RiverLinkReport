using FileHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RiverLink.Automation;
using RiverLink.DAL;
using RiverLink.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
        private static List<Transponder> TransponderList = new List<Transponder>();
        public static int month;
        public static int year;
        public static int transponderNumber;
        public static bool runHeadless;

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
            List<Transponder> TransponderList = context.Transponders.ToList();
            Worker = new Automate(driver, BaseURL, LongWait, ShortWait, VehicleClasses, TransponderList);
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

        public static List<string> GetYears(int Month = 0, int TransponderNumber = 0)
        {
            Month = month;
            TransponderNumber = transponderNumber;
            List<string> returnValue = new List<string>();
                try
                {
                    using (var context = new DB())
                    {
                        IQueryable<Transaction> q = context.Transactions;
                        if (Month > 0)
                        {
                            q = q.Where(x => x.TransactionDate.Month == Month);
                        }
                        if (TransponderNumber > 0)
                        {
                            q = q.Where(x => x.TransponderNumber == TransponderNumber);
                        }
                        returnValue = q.Where(l => l.TransactionType == "Toll").Select(x => x.TransactionDate.Year.ToString())
                            .Distinct().ToList();
                        var myComparer = new CustomComparer();
                        returnValue.Sort(myComparer);
                }
                    returnValue.Insert(0, "All");
            }
                catch (Exception e)
                {

                    throw e;
                }           
            return returnValue;
        }

        public static List<string> GetMonths(int Year = 0, int TransponderNumber = 0)
        {
            Year = year;
            TransponderNumber = transponderNumber;
            List<string> returnValue = new List<string>();
            try
                {
                    using (var context = new DB())
                    {
                        IQueryable<Transaction> q = context.Transactions;
                        if (Year > 0)
                        {
                            q = q.Where(x => x.TransactionDate.Year == Year);
                        }
                        if (TransponderNumber > 0)
                        {
                            q = q.Where(x => x.TransponderNumber == TransponderNumber);
                        }
                        returnValue = q.Where(l => l.TransactionType == "Toll").Select(x => x.TransactionDate.Month.ToString())
                        .Distinct().ToList();
                        var myComparer = new CustomComparer();
                        returnValue.Sort(myComparer);
                    }
                    returnValue.Insert(0, "All");
                }
                catch (Exception e)
                {

                    throw e;
                }
            return returnValue;
        }

        public static List<string> GetTransponderNumbers(int Year = 0, int Month = 0)
        {
            Month = month;
            Year = year;
            List<string> returnValue = new List<string>();
                try
                {
                    using (var context = new DB())
                    {
                        IQueryable<Transaction> q = context.Transactions;
                        if (Year > 0)
                        {
                            q = q.Where(x => x.TransactionDate.Year == Year);
                        }
                        if (Month > 0)
                        {
                            q = q.Where(x => x.TransactionDate.Month == Month);
                        }
                        returnValue = q.Where(l => l.TransactionType == "Toll").Select(x => x.TransponderNumber.ToString())
                            .Distinct().ToList();
                        var myComparer = new CustomComparer();
                        returnValue.Sort(myComparer);
                }
                    returnValue.Insert(0, "All");
                }
                catch (Exception e)
                {

                    throw e;
                }
            return returnValue;
        }

        public static List<Transaction> GetTransactions(int Year = 0, int Month = 0, int TransponderNumber = 0)
        {
            Year = year;
            Month = month;
            TransponderNumber = transponderNumber;
            List<Transaction> returnValue = new List<Transaction>();
            try
            {
                using (var context = new DB())
                {
                    var query = (from oData in context.Transactions select oData);
                    if (Year != 0)
                    {
                        query = query.Where(t => t.TransactionDate.Year == Year);
                    }
                    if (Month != 0)
                    {
                        query = query.Where(t => t.TransactionDate.Month == Month);
                    }
                    if (TransponderNumber != 0)
                    {
                        query = query.Where(t => t.TransponderNumber == TransponderNumber);
                    }
                    query = query.Where(p => p.TransactionType == "Toll");
                    returnValue = query.ToList();

                    //returnValue = context.Transactions.Where(t => t.TransactionDate.Year == Year)
                    //              .Where(x => x.TransactionDate.Month == Month)
                    //              .Where(l => l.TransponderNumber == TransponderNumber)
                    //              .Where(p => p.TransactionType == "Toll")
                    //              .ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return returnValue;
        }

        public static List<Transaction> GetPayments()
        {
            List<Transaction> returnValue = new List<Transaction>();
            try
            {
                using (var context = new DB())
                {
                    returnValue = context.Transactions.Where(p => p.TransactionType == "Payment").ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return returnValue;
        }

        public static List<Vehicle> GetVehicles()
        {
            List<Vehicle> returnValue = new List<Vehicle>();
            try
            {
                using (var context = new DB())
                {
                    returnValue = context.Vehicles.ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
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

        private static void PopulateTransponders()
        {
            if (!TransponderList.Any())
            {
                using (var context = new DB())
                {
                    TransponderList = context.Transponders.ToList();
                }
            }
        }

        public static List<Transponder> GetTransponderData(string FileName)
        {
            List<Transponder> returnValue = new List<Transponder>();
            var engine = new FileHelperEngine<TransponderData>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var result = engine.ReadFile(FileName);
            foreach (TransponderData td in result)
            {
                string PlateNumber = string.Empty;
                TransponderTypes TransponderType = TransponderTypes.Sticker;
                if (td.TransponderType.ToLower() == "ezp")
                {
                    TransponderType = TransponderTypes.EZPass;
                }
                else
                {
                    PlateNumber = td.PlateNumber;
                }
                Transponder t = new Transponder
                {
                    TransponderNumber = td.TransponderNumber,
                    TransponderType = TransponderType,
                    PlateNumber = PlateNumber
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
            var engine = new FileHelperEngine<TransactionData>();
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var result = engine.ReadFile(FileName);
            foreach (TransactionData td in result)
            {
                PopulateTransponders();
                PopulateVehicleClasses();
                Transponder Transponder = null;
                if (td.PlateNumber != null)
                {
                    Transponder = TransponderList.FirstOrDefault(x => x.PlateNumber == td.PlateNumber);
                }
                else
                {
                    TransponderList.FirstOrDefault(x => x.Transponder_Id == td.TransponderNumber);
                }

                Transaction t = new Transaction
                {
                    TransactionNumber = td.TransactionNumber,
                    Plaza = td.Plaza,
                    TransactionStatus = td.TransactionStatus,
                    TransactionType = td.TransactionType,
                    TransactionDate = td.TransactionDate,
                    RelatedJournal_Id = td.RelatedJournal_Id,
                    PostedDate = td.PostedDate,
                    Journal_Id = td.Journal_Id,
                    Amount = td.Amount,
                    PlateNumber = td.PlateNumber,
                    Lane = td.Lane,
                    Transponder = Transponder,
                    TransponderNumber = td.TransponderNumber,
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
                    var ExistingTransaction = ExistingTransactions.SingleOrDefault(x => x.Journal_Id == t.Journal_Id);
                    if (ExistingTransaction == null)
                    {
                        if (t.Transponder != null)
                        {
                            context.Transponders.Attach(t.Transponder);
                        }
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
                ArrayList vehicleFiles = new ArrayList();
                ArrayList transponderFiles = new ArrayList();
                ArrayList transactionFiles = new ArrayList();
                foreach (var file in filePaths)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Name.ToLower().Contains("vehicle"))
                    {
                        vehicleFiles.Add(file);
                    }
                    if (fi.Name.ToLower().Contains("transaction"))
                    {
                        transactionFiles.Add(file);
                    }
                    if (fi.Name.ToLower().Contains("transponder"))
                    {
                        transponderFiles.Add(file);
                    }
                }
                foreach (var vehicleFile in vehicleFiles)
                {
                    List<Vehicle> vehicleList = GetVehicleData(vehicleFile.ToString());
                    InsertVehicleData(vehicleList);
                }
                foreach (var transponderFile in transponderFiles)
                {
                    List<Transponder> transponderList = GetTransponderData(transponderFile.ToString());
                    InsertTransponderData(transponderList);
                }
                foreach (var transactionFile in transactionFiles)
                {
                    List<Transaction> transactionList = GetTransactionData(transactionFile.ToString());
                    InsertTransactionData(transactionList);
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

            List<TransponderData> TransponderList = Worker.GetTransponderData(out Success);
            if (Success != "Success")
            {
                return false;
            }

            Success = Worker.GoToTransactionHistory(string.Empty);
            if (Success != "Success")
            {
                return false;
            }

            DateTime lastDate = DateTime.Today;
            using (var context = new DB())
            {
                lastDate = context.Transactions.Max(x => x.TransactionDate);
                if (lastDate != null)
                {
                    Automate.LatestDate = lastDate;
                }
            }

            List<TransactionData> TransactionList = Worker.GetTransactionData(out Success);
            if (Success != "Success")
            {
                return false;
            }

            return returnValue;
        }

        public bool Login(string username, string password)
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
            Automate.username = username;
            Automate.password = password;
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
            if (runHeadless == false)
            {
                options.AddArgument("--disable-extensions --disable-accelerated-video-decode");
            }
            else
            {
                options.AddArgument("--disable-extensions --disable-accelerated-video-decode --headless");
            }            
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

    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var regex = new Regex(@"\d+");

            // run the regex on both strings
            var xRegexResult = regex.Match(x);
            var yRegexResult = regex.Match(y);

            // check if they are both numbers
            if (xRegexResult.Success && yRegexResult.Success)
            {
                return int.Parse(xRegexResult.Value).CompareTo(int.Parse(yRegexResult.Value));
            }

            // otherwise return as string comparison
            return x.CompareTo(y);
        }
    }
}
