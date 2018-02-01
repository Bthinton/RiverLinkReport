using HtmlAgilityPack;
using OpenQA.Selenium;
using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using FileHelpers;
using System.IO;


namespace RiverLink.Automation
{
    /// <summary>
    /// The main <c>Automate</c> class
    /// Contains all automation methods
    /// </summary>
    /// <remarks>
    /// This class performs all navigating and data-getting
    /// </remarks>
    public class Automate
    {
        #region Fields
        private static int WebDriverWaitSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["WebDriverWaitSeconds"]);
        private static double ExplicitWaitSeconds = Convert.ToDouble(ConfigurationManager.AppSettings["PageLoadWaitSeconds"]);
        private IWebDriver driver { get; set; }
        private string StatusMessage = "";
        private delegate bool PageCheckDelegate(IWebDriver driver);
        private delegate bool PageCheckDelegateNumber(IWebDriver driver, int PageNumber);
        private string BaseURL = string.Empty;
        private int ShortWait = 1000;
        private int LongWait = 2000;
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string dataDirectory = $"{path}Data\\";
        private static string timeStamp = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
        
        #endregion Fields

        #region Events
        /// <summary>
        /// Used to print messages to console
        /// </summary>
        /// <param name="Message">
        /// The text that will be printed to the console
        /// </param>
        public delegate void StatusChangedEventHandler(string Message);
        /// <summary>
        /// Defines event name for console messages
        /// </summary>
        public event StatusChangedEventHandler StatusChanged;
        /// <summary>
        /// Performs the writing of messages to the console
        /// </summary>
        /// <param name="Message">
        /// The text that will be written to the console
        /// </param>
        protected virtual void OnStatusChanged(string Message)
        {
            StatusChanged?.Invoke(Message);
        }
        #endregion Events

        #region Constructors
        /// <summary>
        /// Sets variables for the driver, url, and wait times
        /// </summary>
        /// <param name="WebDriver">Defines driver</param>
        /// <param name="URL">Defines url</param>
        /// <param name="LWait">Defines Long wait time</param>
        /// <param name="SWait">Defines short wait time</param>
        public Automate(IWebDriver WebDriver, string URL, int LWait, int SWait)
        {
            driver = WebDriver;
            BaseURL = URL;
            LongWait = LWait;
            ShortWait = SWait;
        }
        #endregion Constructors

        #region Navigation
        //Naviagtes to RiverLink Home Page
        /// <summary>
        /// Navigates to RiverLink home page and verfies the driver made it to the correct page
        /// </summary>
        /// <param name="Success">Passed to Login method in RiverLinkLogic.cs</param>
        /// <returns>If failed or succeeded</returns>
        public string GoToHomePage(string Success)
        {
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }
            string returnValue = "Failed";
            try
            {
                StatusMessage = $"Going To {BaseURL}...";
                OnStatusChanged(StatusMessage);
                driver.Url = BaseURL;
                Thread.Sleep(ShortWait);
                if (IsHomePage(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Home Page Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
                else
                {
                    StatusMessage = $"Home Page Not Loaded";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page could not be verified";
                    OnStatusChanged(StatusMessage);
                }
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                StatusMessage = $"{methodName} Error: Unexpected Error {ex}";
                OnStatusChanged(StatusMessage);
            }
            return returnValue;
        }

        //Navigates to Login Page
        /// <summary>
        /// Navigates to RiverLink login page and verfies the driver made it to the correct page
        /// </summary>
        /// <param name="Success">Passed to Login method in RiverLinkLogic.cs</param>
        /// <returns>If failed or succeeded</returns>
        public string GoToLoginPage(string Success)
        {
            string returnValue = "Failed";
            try
            {
                StatusMessage = $"Going To {BaseURL}{Properties.Settings.Default.U_Login}...";
                OnStatusChanged(StatusMessage);
                driver.Url = $"{BaseURL}{Properties.Settings.Default.U_Login}";
                Thread.Sleep(ShortWait);
                if (IsLoginPage(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Login Page Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
                else
                {
                    StatusMessage = $"Login Page Not Loaded";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page could not be verified";
                    OnStatusChanged(StatusMessage);
                }
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                StatusMessage = $"{methodName} Error: Unexpected Error {ex}";
                OnStatusChanged(StatusMessage);
            }
            return returnValue;
        }

        //Navigates to Transaction History Page
        /// <summary>
        /// Navigates to Transaction History page and verfies the driver made it to the correct page
        /// </summary>
        /// <param name="success">Passed to Login method in RiverLinkLogic.cs</param>
        /// <returns>If failed or succeeded</returns>
        public string GoToTransactionHistory(string success)
        {
            string returnValue = "Failed";

            try
            {
                StatusMessage = $"Going To {BaseURL}{Properties.Settings.Default.U_Transaction}...";
                OnStatusChanged(StatusMessage);
                driver.Url = $"{BaseURL}{Properties.Settings.Default.U_Transaction}";
                Thread.Sleep(ShortWait);
                if (IsTransactionHistory(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Transaction History Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
                else
                {
                    StatusMessage = $"Transaction History Not Loaded";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page could not be verified";
                    OnStatusChanged(StatusMessage);
                }
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                StatusMessage = $"{methodName} Error: Unexpected Error {ex}";
                OnStatusChanged(StatusMessage);
            }

            if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_ResultsPerPageBTN)))
            {
                StatusMessage = $"Switching to largest result per page.";
                OnStatusChanged(StatusMessage);

                driver.FindElement(By.XPath(Properties.Settings.Default.X_ResultsPerPageBTN)).Click();
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath(Properties.Settings.Default.X_MaxPerPage)).Click();

                StatusMessage = $"Filter option changed.";
                OnStatusChanged(StatusMessage);
            }
            else
            {
                throw new Exception("Error EditAd: unable to access filter button. (Results per page)");
            }
            return returnValue;
        }

        //Navigates to Transaction Detail Pages
        /// <summary>
        /// Navigates to the Transaction Detail pages and verfies the driver made it to the correct page
        /// </summary>
        /// <param name="Success">Passed to Login method in RiverLinkLogic.cs</param>
        /// <param name="detailBTNX_Path">Button used to access detail page</param>
        /// <returns>If failed or succeeded</returns>
        public string GotoTransactionDetail(string Success, string detailBTNX_Path)
        {
            string returnValue = "Failed";
            if (IsElementDisplayed(driver, By.XPath(detailBTNX_Path)))
            {
                StatusMessage = $"Navigating To Detail Page...";
                OnStatusChanged(StatusMessage);
                driver.FindElement(By.XPath(detailBTNX_Path)).Click();
                if (IsDetailPage(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Detail Page Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
            }
            return returnValue;
        }

        //Navigates to next Transaction History Page
        /// <summary>
        /// Navigates to the next Transaction History page and verifies the driver made it to the correct page
        /// Checks to see if it pulled all transactions currently on the page before navigating to next page
        /// </summary>
        /// <param name="Success">Passed to GetData method in RiverLinkLogic.cs</param>
        /// <param name="transactionNextBTNX_Path">Button for navigating to next Transaction History page</param>
        /// <returns>If failed or succeeded</returns>
        public string GotoNextTransactionPage(string Success, string transactionNextBTNX_Path)
        {
            string returnValue = "Failed";
            int x = driver.FindElements(By.XPath(Properties.Settings.Default.X_TransactionTable)).Count;
            if (x >= 1000)
            {
                StatusMessage = $"Next button verified...";
                OnStatusChanged(StatusMessage);
                StatusMessage = $"Navigating To Next Transaction Page...";
                OnStatusChanged(StatusMessage);
                driver.FindElement(By.XPath(Properties.Settings.Default.X_TransactionNextBTN)).Click();
                GetTransactionData(out string success);
                if (IsTransactionHistory(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Next Transaction Page Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
            }
            return returnValue;
        }

        #endregion Navigation

        #region Actions

        //Logs in to riverlink account
        /// <summary>
        /// Logs in to RiverLink account by verifying input fields, entering username/password, then clicking the button
        /// </summary>
        /// <param name="Success">Passed to Login method in RiverLinkLogic.cs</param>
        /// <returns>If failed or succeeded</returns>
        public string Login(string Success)
        {
            string returnValue = "Failed";
            try
            {
                if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_UserField)))
                {
                    StatusMessage = "Selecting Username Field...";
                    OnStatusChanged(StatusMessage);
                    driver.FindElement(By.XPath(Properties.Settings.Default.X_UserField)).Clear();
                    System.Threading.Thread.Sleep(3000);
                    StatusMessage = $"Entering Username...";
                    OnStatusChanged(StatusMessage);
                    driver.FindElement(By.XPath("//*[@id=\"txtUserName\"]")).SendKeys("username");
                }
                else
                {
                    throw new Exception("Error EditAd: unable to change the Username field.");
                }
                if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_PassField)))
                {
                    StatusMessage = "Selecting Password Field...";
                    OnStatusChanged(StatusMessage);

                    driver.FindElement(By.XPath(Properties.Settings.Default.X_PassField)).Clear();
                    System.Threading.Thread.Sleep(3000);
                    StatusMessage = $"Entering Password...";
                    OnStatusChanged(StatusMessage);
                    driver.FindElement(By.XPath("//*[@id=\"txtPassword\"]")).SendKeys("password");
                }
                else
                {
                    throw new Exception("Error EditAd: unable to change the Password field.");
                }
                if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_LoginBTN)))
                {
                    StatusMessage = "Logging In...";
                    OnStatusChanged(StatusMessage);

                    driver.FindElement(By.XPath(Properties.Settings.Default.X_LoginBTN)).Click();
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    throw new Exception("Error EditAd: unable to access Login button.");
                }
                if (IsAccountOverview(driver))
                {
                    returnValue = "Success";
                    StatusMessage = $"Overview Page Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);
                }
                else
                {
                    throw new Exception("Error EditAd: unable to access Overview page.");
                }
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                StatusMessage = $"{methodName} Error: Unexpected Error {ex}";
                OnStatusChanged(StatusMessage);
            }
            return returnValue;
        }

        //Pulls vehicle data from overview page
        /// <summary>
        /// Data-getter for vehicle data on Account Overview page
        /// </summary>
        /// <param name="Success">Passed to GetData method in RiverLinkLogic.cs</param>
        /// <returns>If failed or succeeded</returns>
        public List<Vehicle> GetVehicleData(out string Success)
        {            
            List<Vehicle> ReturnValue = null;
            Success = "failed";

            if (IsAccountOverview(driver))
            {
                Success = "Success";
                StatusMessage = $"Overview Page Loaded...";
                OnStatusChanged(StatusMessage);
                StatusMessage = $"Page Verified...";
                OnStatusChanged(StatusMessage);
                StatusMessage = "Verifying Vehicle Table...";
                OnStatusChanged(StatusMessage);
                if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_VehicleTable)))
                {
                    StatusMessage = "Vehicle Table Verified...";
                    OnStatusChanged(StatusMessage);
                    string html = driver.PageSource;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    for (int i = 1; i < doc.DocumentNode.SelectNodes(Properties.Settings.Default.X_VehicleTable).Count; i++)
                    {
                        var engine = new FileHelperEngine<Vehicle>();
                        var engine2 = new FileHelperEngine<Transponder>();
                        Vehicle v = new Vehicle();
                        //string transponderNumber = string.Empty;
                        HtmlDocument rowDoc = new HtmlDocument();
                        rowDoc.LoadHtml(doc.DocumentNode.SelectNodes(Properties.Settings.Default.X_VehicleTable)[i].InnerHtml);
                        var cells = rowDoc.DocumentNode.SelectNodes("//td/span");
                        for (int j = 0; j < cells.Count; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    v.Make = cells[0].InnerHtml;
                                    break;
                                case 1:
                                    v.Model = cells[1].InnerHtml;
                                    break;
                                case 2:
                                    v.Year = GetVehicleYear(cells[2].InnerHtml);
                                    break;
                                case 3:
                                    string[] statePlateArray = cells[3].InnerHtml?.Split(':');
                                    if (statePlateArray.Length == 2)
                                    {
                                        v.VehicleState = statePlateArray[0].Trim();
                                        v.PlateNumber = statePlateArray[1].Trim();
                                    }
                                    break;
                                case 4:
                                    v.VehicleStatus = cells[4].InnerHtml;
                                    break;                                
                                case 5:
                                    VehicleClass vc = new VehicleClass
                                    {
                                        Classification = GetVehiclePriceClass(cells[5].InnerHtml)
                                    };
                                    List<VehicleClass> vcList = new List<VehicleClass>
                                    {
                                        vc
                                    };
                                    v.VehiclePriceClass = vcList;
                                    break;
                                case 6:
                                    int transponderNumber = GetTransponderNumber(cells[6].InnerHtml);
                                    break;
                                case 7:                                   
                                    Transponder t = new Transponder
                                    {
                                        Transponder_Id = GetTransponderNumber(cells[6].InnerHtml),
                                        TransponderType = GetTransponderType(cells[7].InnerHtml)
                                    };
                                    List<Transponder> tList = new List<Transponder>
                                    {
                                        t
                                    };
                                    v.Transponders = tList;
                                    if (System.IO.File.Exists($"{dataDirectory}Transponders-{timeStamp}.Txt"))
                                    {
                                        engine2.AppendToFile($"{dataDirectory}Transponders-{timeStamp}.Txt", tList);
                                    }
                                    else
                                    {
                                        engine2.HeaderText = "Transponder_Id";
                                        engine2.WriteFile($"{dataDirectory}Transponders-{timeStamp}.Txt", tList);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (ReturnValue == null)
                        {
                            ReturnValue = new List<Vehicle>();
                        }
                        ReturnValue.Add(v);
                        engine.HeaderText = engine.GetFileHeader();
                        engine.WriteFile($"{dataDirectory}Vehicles-{timeStamp}.Txt", ReturnValue);
                    }
                }
                else
                {
                    throw new Exception("Error EditAd: unable to access Vehicle table.");
                }
            }
            else
            {
                throw new Exception("Error EditAd: unable to access Overview page.");
            }
            return ReturnValue;
        }

        //Pulls Transaction History
        /// <summary>
        /// Gets transaction data from the Transaction History Page
        /// </summary>
        /// <param name="Success">Passed to GetData method in RiverLinkLogic.cs</param>
        /// <returns>If succeeded or failed</returns>
        public List<Transaction> GetTransactionData(out string Success)
        {
            List<Transaction> ReturnValue = null;
            string method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Success = "failed";
            try
            {
                if (IsTransactionHistory(driver))
                {
                    Success = "Success";
                    StatusMessage = $"Transaction History Loaded...";
                    OnStatusChanged(StatusMessage);
                    StatusMessage = $"Page Verified...";
                    OnStatusChanged(StatusMessage);

                    if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_TransactionTable)))
                    {
                        StatusMessage = $"Transaction Table Verified...";
                        OnStatusChanged(StatusMessage);
                        string html = driver.PageSource;
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(html);
                        for (int i = 1; i < doc.DocumentNode.SelectNodes(Properties.Settings.Default.X_TransactionTable).Count; i++)
                        {
                            string detailBTNX_Path = string.Format(Properties.Settings.Default.X_TransactionDetailBTN, i - 1);
                            Transaction t = new Transaction();
                            HtmlDocument rowDoc = new HtmlDocument();
                            rowDoc.LoadHtml(doc.DocumentNode.SelectNodes(Properties.Settings.Default.X_TransactionTable)[i].InnerHtml);
                            var cells = rowDoc.DocumentNode.SelectNodes("//td/span");
                                    t.TransactionType = GetTransactionType(cells[0].InnerHtml);
                                    t.Amount = GetTransactionAmount(cells[1].InnerHtml);
                                    t.TransactionDate = GetTransactionDate(cells[2].InnerHtml);
                                    t.TransactionDescription = cells[3].InnerHtml.Trim();
                                    t.Lane = GetLane(cells[4].InnerHtml);
                                    t.Plaza = GetPlaza(cells[5].InnerHtml);                                      
                                    t.Transponder = GetTransponderInfo(cells[6].InnerHtml);
                                    t.PlateNumber = cells[7].InnerHtml.Trim();
                                    //Pulls data from detail page
                                    GotoTransactionDetail(Success, detailBTNX_Path);
                                    if (Success != "Success")
                                    {
                                        throw new Exception($"Error {method}: Could not navigate to detail page");
                                    }
                                    t.Transaction_Id = GetTransactionId(driver.FindElement(By.XPath(Properties.Settings.Default.X_TransactionIdField)).Text);
                                    t.Journal_Id = GetJournalId(driver.FindElement(By.XPath(Properties.Settings.Default.X_TransactionJournalId)).Text);
                                    t.PostedDate = GetPostedDate(driver.FindElement(By.XPath(Properties.Settings.Default.X_PostedDate)).Text);
                                    t.RelatedJournal_Id = new List<int>();
                                    if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_DetailPageTable)))
                                    {
                                        StatusMessage = $"Detail Page Table Verified...";
                                        OnStatusChanged(StatusMessage);
                                        StatusMessage = $"Pulling Related Transactions...";
                                        OnStatusChanged(StatusMessage);
                                        string html2 = driver.PageSource;
                                        HtmlDocument doc2 = new HtmlDocument();
                                        doc2.LoadHtml(html2);
                                        List<int> relatedTransactions = null;
                                        for (int m = 1; m < doc2.DocumentNode.SelectNodes(Properties.Settings.Default.X_DetailPageTable).Count; m++)
                                        {
                                            HtmlDocument rowDoc2 = new HtmlDocument();
                                            rowDoc2.LoadHtml(doc2.DocumentNode.SelectNodes(Properties.Settings.Default.X_DetailPageTable)[m].InnerHtml);
                                            var detailCells = rowDoc2.DocumentNode.SelectNodes("//td");
                                            int detailJournalId = GetRelatedJournalId(detailCells[1].InnerHtml);
                                            if (relatedTransactions == null)
                                            {
                                                relatedTransactions = new List<int>();
                                            }                                                           
                                            relatedTransactions.Add(detailJournalId);
                                            t.RelatedJournal_Id = relatedTransactions;
                                        }
                                    }
                                    else
                                    {
                                        StatusMessage = $"No Detail Page Table Available...";
                                        OnStatusChanged(StatusMessage);
                                    }
                            driver.Navigate().Back();                                
                            
                            if (ReturnValue == null)
                            {
                                ReturnValue = new List<Transaction>();
                            }
                            ReturnValue.Add(t);
                        }
                        var engine = new FileHelperEngine<Transaction>();
                        if (System.IO.File.Exists($"{dataDirectory}Transactions-{timeStamp}.Txt"))
                        {
                            engine.AppendToFile($"{dataDirectory}Transactions-{timeStamp}.Txt", ReturnValue);
                        }
                        else
                        {
                            engine.HeaderText = engine.GetFileHeader();
                            engine.WriteFile($"{dataDirectory}Transactions-{timeStamp}.Txt", ReturnValue);
                        }

                        string transactionNextBTNX_Path = string.Format(Properties.Settings.Default.X_TransactionNextBTN);
                        GotoNextTransactionPage(Success, transactionNextBTNX_Path);
                        if (Success != "Success")
                        {
                            throw new Exception($"Error {method}: Could not navigate to next transaction page");
                        }
                    }
                }
                else
                {
                    throw new Exception("Error EditAd: unable to access Transaction History page.");
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"{method} Error: Unexpected Error {ex}";
                OnStatusChanged(StatusMessage);
            }
            return ReturnValue;
        }

        //public Dictionary<string, string> GetRowDetail()
        //{
        //    Dictionary<string, string> returnValue = new Dictionary<string, string>();

        //    StatusMessage = $"Looking for the URL...";
        //    OnStatusChanged(StatusMessage);

        //    string html = driver.PageSource;

        //    //get the ad url
        //    string AdUrl = GetAttributeValueFromHtml(html, Settings.Default.X_ManagePage_AdUrl, "href", "");
        //    returnValue.Add("AdUrl", AdUrl);
        //    StatusMessage = $"AdUrl: {AdUrl}";
        //    OnStatusChanged(StatusMessage);

        //    //get the price
        //    string price = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_PostedPrice, "0");
        //    string cleanPrice = Regex.Replace(price, "[^0-9]", "");
        //    returnValue.Add("PostedPrice", cleanPrice);
        //    StatusMessage = $"PostedPrice: {cleanPrice}";
        //    OnStatusChanged(StatusMessage);

        //    //get the vin
        //    string vin = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_VehicleVin, "").Replace("VIN: ", "");
        //    returnValue.Add("VehicleVin", vin);
        //    StatusMessage = $"VehicleVin: {vin}";
        //    OnStatusChanged(StatusMessage);

        //    //get the id
        //    string id = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_Id, "").Replace("post id: ", "").Trim();
        //    returnValue.Add("Id", id);
        //    StatusMessage = $"Id: {id}";
        //    OnStatusChanged(StatusMessage);

        //    //get the Inventory_ID
        //    string InventoryId = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_Inventory_ID, "0").Replace("ID: ", "");
        //    returnValue.Add("Inventory_ID", InventoryId);
        //    StatusMessage = $"InventoryID: {InventoryId}";
        //    OnStatusChanged(StatusMessage);

        //    //get the BatchId
        //    string BatchId = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_BatchId, "").Replace("BatchID: ", "");
        //    returnValue.Add("BatchId", BatchId);
        //    StatusMessage = $"BatchId: {BatchId}";
        //    OnStatusChanged(StatusMessage);

        //    //get the image count
        //    string ImageCount = GetElementCountFromHtml(html, Settings.Default.X_ManagePage_ImageCount, 0).ToString();
        //    returnValue.Add("ImageCount", ImageCount);
        //    StatusMessage = $"ImageCount: {ImageCount}";
        //    OnStatusChanged(StatusMessage);

        //    //get the PostedDate
        //    string PostedDate = GetAttributeValueFromHtml(html, Settings.Default.X_ManagePage_PostedDate, "title", "1753-01-01");
        //    returnValue.Add("PostedDate", PostedDate);
        //    StatusMessage = $"PostedDate: {PostedDate}";
        //    OnStatusChanged(StatusMessage);

        //    //get the PostingTitle
        //    string PostingTitle = GetElementTextFromHtml(html, Settings.Default.X_ManagePage_PostingTitle, "-");
        //    returnValue.Add("PostingTitle", PostingTitle);
        //    StatusMessage = $"PostingTitle: {PostingTitle}";
        //    OnStatusChanged(StatusMessage);

        //    return returnValue;
        //}
        #endregion Actions

        #region PageVerify
        /// <summary>
        /// Verfies if the driver made it to the RiverLink home page
        /// </summary>
        /// <param name="driver">browser being used</param>
        private bool IsHomePage(IWebDriver driver)
        {
            //See if we're on the home page
            if (driver.PageSource.Contains(Properties.Settings.Default.V_HomePage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies if the driver made it to the transaction detail page
        /// </summary>
        /// <param name="driver">browser being used</param>
        private bool IsDetailPage(IWebDriver driver)
        {
            if (driver.PageSource.Contains(Properties.Settings.Default.V_DetailPage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies if the driver made it to RiverLink's login page
        /// </summary>
        /// <param name="driver">browser being used</param>
        private bool IsLoginPage(IWebDriver driver)
        {
            //See if we're on the login page
            if (driver.PageSource.Contains(Properties.Settings.Default.V_LoginPage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verfies if the driver made it to the Account Overview page
        /// </summary>
        /// <param name="driver">browser being used</param>
        /// <returns></returns>
        private bool IsAccountOverview(IWebDriver driver)
        {
            //See if we're on the account page
            if (driver.PageSource.Contains(Properties.Settings.Default.V_AccountOverview))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies if the driver made it to the Transaction History page
        /// </summary>
        /// <param name="driver">browser being used</param>
        private bool IsTransactionHistory(IWebDriver driver)
        {
            //See if we're on the transaction history page
            if (driver.PageSource.Contains(Properties.Settings.Default.V_TransactionHistory))
            {
                return true;
            }
            else
            {
                return false;
            }
        }    
        #endregion PageVerify

        #region Helper Methods
        /// <summary>
        /// Parses the cell's text into the transponder id and passes it to a transponder
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>transponder associated with the transaction</returns>
        private Transponder GetTransponderInfo(string cellText)
        {
            string transponderNumber = cellText;
            Int32.TryParse(transponderNumber, out int number);
            Transponder transponder = new Transponder
            {
                Transponder_Id = number
            };
            return transponder;
        }
        /// <summary>
        /// Compares the cell's text to string specified and returns the Vehicle classification
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>vehicle's price class associated with the transaction</returns>
        private Classifications GetVehiclePriceClass(string cellText)
        {
            string vehiclePriceClass = cellText;
            if (vehiclePriceClass == "Class 1")
            {
                return Classifications.Class1;
            }
            if (vehiclePriceClass == "Class 2")
            {
                return Classifications.Class2;
            }
            if (vehiclePriceClass == "Class 3")
            {
                return Classifications.Class3;
            }
            return Classifications.None;
        }
        /// <summary>
        /// Parses the cell's data into the vehicle year and returns it
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>year of vehicle associated with the transaction</returns>
        private int GetVehicleYear(string cellText)
        {
            string year = cellText;
            Int16.TryParse(year, out Int16 vehicleYear);
            return vehicleYear;
        }
        /// <summary>
        /// Compares cell's text to string specified and returns the Transponder Type
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>type of transponder associated with the transaction</returns>
        private TransponderTypes GetTransponderType(string cellText)
        {
            string transponderType = cellText;
            if (transponderType == "EZP")
            {
                return TransponderTypes.EZPass;
            }
            else
            {
                return TransponderTypes.Sticker;
            }
        }
        /// <summary>
        /// Parses the cell's text into the transponder id and returns it
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>The number associated with the transponder</returns>
        private int GetTransponderNumber(string cellText)
        {
            string transponderNumber = cellText;
            Int32.TryParse(transponderNumber, out int number);
            return number;
        }
        /// <summary>
        /// Parses cell's text and returns the transaction id
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>
        /// transaction id associated with transaction
        /// </returns>
        private int GetTransactionId(string cellText)
        {            
            if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_TransactionIdField)))
            {
                string transactionId = cellText;
                int.TryParse(transactionId, out int transId);
                return transId;
            }
            else
            {
                return 0;
            }       
        }
        /// <summary>
        /// Parses cell's text and return the journal id
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>journal id associated with the transaction</returns>
        private int GetJournalId(string cellText)
        {
            if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_TransactionJournalId)))
            {
                string journalId = cellText;
                int.TryParse(journalId, out int journId);
                return journId;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Parses cell's text and returns date/time 
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>posted date of the transaction</returns>
        private DateTime? GetPostedDate(string cellText)
        {
            if (IsElementDisplayed(driver, By.XPath(Properties.Settings.Default.X_PostedDate)))
            {

                string postedTransDate = cellText;
                DateTime.TryParse(postedTransDate, out DateTime postedDate);
                return postedDate;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Parses cell's text and returns related journal ids
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>journal ids that are related to the transaction</returns>
        private int GetRelatedJournalId(string cellText)
        {
            string detailJournId = cellText;
            int.TryParse(detailJournId, out int detailJournalId);
            return detailJournalId;
        }
        /// <summary>
        /// Compares cell's text to specified string and returns plaza
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>plaza associated with the transaction</returns>
        private Plazas GetPlaza(string cellText)
        {
            string plaza = cellText;
            if (plaza == "East End Crossing - SB")
            {
                return Plazas.EastEndSB;
            }
            if (plaza == "East End Crossing - NB")
            {
                return Plazas.EastEndNB;
            }
            if (plaza == "Lincoln Bridge - SB")
            {
                return Plazas.LincolnSB;
            }
            if (plaza == "Lincoln Bridge - NB")
            {
                return Plazas.LincolnNB;
            }
            if (plaza == "Kennedy Bridge - SB")
            {
                return Plazas.KennedySB;
            }
            if (plaza == "Kennedy Bridge - NB")
            {
                return Plazas.KennedyNB;
            }
            return Plazas.None;
        }
        /// <summary>
        /// Compares cell's data to specified string and returns Transaction Type
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>type of transaction made</returns>
        private TransactionTypes GetTransactionType(string cellText)
        {
            string transactionType = cellText;
            if (transactionType == "Toll")
            {
                return TransactionTypes.Toll;
            }
            if (transactionType == "Payment")
            {
                return TransactionTypes.Payment;
            }
            if (transactionType == "Discount")
            {
                return TransactionTypes.Discount;
            }
            if (transactionType == "Fee")
            {
                return TransactionTypes.Fee;
            }
            return TransactionTypes.None;
        }
        /// <summary>
        /// Parses cell's data and returns lane
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>lane associated with transaction</returns>
        private int GetLane(string cellText)
        {
            int.TryParse(cellText, out int lane);
            return lane;
        }
        /// <summary>
        /// Parses cell's text and returns date/time
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>date of transaction</returns>
        private DateTime GetTransactionDate(string cellText)
        {
            string transDate = cellText;
            DateTime transactionDate = DateTime.Parse(transDate);
            return transactionDate;
        }
        /// <summary>
        /// Parses cell's text and returns amount
        /// </summary>
        /// <param name="cellText">the cell the data is located within the table</param>
        /// <returns>monetary amount of transaction</returns>
        private double GetTransactionAmount(string cellText)
        {
            double.TryParse(cellText, out double amount);
            return amount;
        }
                                                   
        private string GetElementTextFromHtml(string Html, string Xpath, string DefaultValue)
        {
            string returnValue = DefaultValue;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Html);

            if (doc.DocumentNode.SelectSingleNode(Xpath) != null)
            {
                returnValue = doc.DocumentNode.SelectSingleNode(Xpath).InnerText;
            }

            returnValue = HttpUtility.HtmlDecode(SqueezeSpaces(returnValue.Trim()));

            return returnValue;
        }

        private string GetAttributeValueFromHtml(string Html, string Xpath, string Attribute, string DefaultValue)
        {
            string returnValue = "";

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Html);

            if (doc.DocumentNode.SelectSingleNode(Xpath) != null)
            {
                returnValue = doc.DocumentNode.SelectSingleNode(Xpath).GetAttributeValue(Attribute, DefaultValue);
            }

            returnValue = HttpUtility.HtmlDecode(SqueezeSpaces(returnValue.Trim()));

            return returnValue;
        }

        private string GetAttributeValue(string Xpath, string Attribute, string DefaultValue)
        {
            string returnValue = DefaultValue;

            if (IsElementDisplayed(driver, By.XPath(Xpath)))
            {
                returnValue = driver.FindElement(By.XPath(Xpath)).GetAttribute(Attribute).ToString();
            }

            return returnValue;
        }

        private string GetElementText(string Xpath, string DefaultValue)
        {
            string returnValue = DefaultValue;

            if (IsElementDisplayed(driver, By.XPath(Xpath)))
            {
                returnValue = driver.FindElement(By.XPath(Xpath)).Text;
            }

            return returnValue;
        }

        private string GetElementTextWithinElement(IWebElement Element, string Xpath, string DefaultValue)
        {
            string returnValue = DefaultValue;
            if (IsElementDisplayedWithinElement(Element, By.XPath(Xpath)))
            {
                returnValue = Element.FindElement(By.XPath(Xpath)).Text;
            }
            return returnValue;
        }

        private string GetAttributeValueWithinElement(IWebElement Element, string Xpath, string Attribute, string DefaultValue)
        {
            string returnValue = DefaultValue;
            if (IsElementDisplayedWithinElement(Element, By.XPath(Xpath)))
            {
                returnValue = Element.FindElement(By.XPath(Xpath)).GetAttribute(Attribute).ToString();
            }
            return returnValue;
        }

        private string GetHtml()
        {
            return driver.PageSource;
        }

        private IWebElement GetElement(string Xpath)
        {
            if (IsElementDisplayed(driver, By.XPath(Xpath)))
            {
                return driver.FindElement(By.XPath(Xpath));
            }
            else
            {
                return null;
            }
        }

        private List<HtmlNode> GetHtmlNodes(string XPath)
        {
            List<HtmlNode> returnValue = null;
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(driver.PageSource);

                returnValue = new List<HtmlNode>();

                foreach (var item in doc.DocumentNode.SelectNodes(XPath))
                {
                    returnValue.Add(item);
                }
            }
            catch (Exception)
            {

            }

            return returnValue;
        }

        private IWebElement GetWebElement(string XPath)
        {
            IWebElement returnValue = null;

            try
            {
                returnValue = driver.FindElement(By.XPath(XPath));
            }
            catch (Exception)
            {
            }

            return returnValue;
        }

        private string GetInnerText(HtmlNode Node)
        {
            string returnValue = "";

            if (Node == null)
            {
                return returnValue;
            }

            returnValue = Node.InnerText.Replace("\r", "").Replace("\n", "").Trim();

            return returnValue;
        }
        /// <summary>
        /// Navigates to url specified
        /// </summary>
        /// <param name="Url">The address being navigated to</param>
        public void Navigate(string Url)
        {
            driver.Url = Url;
            driver.Navigate();
            //wait after naviogation
            Thread.Sleep(2000);
        }

        private string GetCurrentUrl()
        {
            return driver.Url;
        }

        private HtmlNode GetHtmlNode(string XPath)
        {
            HtmlNode returnValue = null;
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(driver.PageSource);

                returnValue = doc.DocumentNode.SelectSingleNode(XPath);
            }
            catch (Exception)
            {

            }

            return returnValue;
        }
        /// <summary>
        /// Checks to see if element specified is displayed on page
        /// </summary>
        /// <param name="driver">browser being used</param>
        /// <param name="element">specific element being checked for</param>
        public bool IsElementDisplayed(IWebDriver driver, By element)
        {

            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
                    if (elements.Count > 0)
                    {
                        return elements.ElementAt(0).Displayed;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was raised on locating element: " + e.Message);
                    Thread.Sleep(1000);
                }
            }

            //throw new ElementNotVisibleException(by.ToString());


            return false;
        }
        /// <summary>
        /// Checks to see if element is displayed within browser element
        /// </summary>
        /// <param name="Element">Specified element being checked for</param>
        /// <param name="FindBy">Mechanism used to find element</param>
        public bool IsElementDisplayedWithinElement(IWebElement Element, By FindBy)
        {

            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    IReadOnlyCollection<IWebElement> elements = Element.FindElements(FindBy);
                    if (elements.Count > 0)
                    {
                        return elements.ElementAt(0).Displayed;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was raised on locating element: " + e.Message);
                    Thread.Sleep(1000);
                }
            }

            //throw new ElementNotVisibleException(by.ToString());


            return false;
        }

        //Enabled
        /// <summary>
        /// Checks to see if element is enabled
        /// </summary>
        /// <param name="driver">browser being used</param>
        /// <param name="element">element being checked</param>
        public bool IsElementEnabled(IWebDriver driver, By element)
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Enabled;
            }
            return false;
        }

        private bool WaitForPageToLoad(string PageName, PageCheckDelegate pcd, IWebDriver driver)
        {
            bool returnValue = pcd(driver);
            int MaxPageLoadWait = 5;

            //wait for the account page to load
            while (!returnValue == false && MaxPageLoadWait > 0)
            {
                if (pcd(driver))
                {
                    StatusMessage = String.Format("{0} Page Loaded.", PageName);
                    OnStatusChanged(StatusMessage);
                    returnValue = true;
                    break;
                }

                StatusMessage = String.Format("{0} Page doesn't seem to be loaded yet, wait 2 seconds and check again.", PageName);
                OnStatusChanged(StatusMessage);

                //sleep for 2 seconds then check the page again
                System.Threading.Thread.Sleep(2000);
                MaxPageLoadWait--;

                StatusMessage = String.Format("Checking {0} Page again, {1} attempts remaining.", PageName, MaxPageLoadWait);
                OnStatusChanged(StatusMessage);
            }

            return returnValue;
        }

        private bool WaitForPageToLoad(string PageName, PageCheckDelegateNumber pcd, IWebDriver driver, int PageNumber)
        {
            bool returnValue = pcd(driver, PageNumber);
            int MaxPageLoadWait = 5;

            //wait for the account page to load
            while (!returnValue == false && MaxPageLoadWait > 0)
            {
                if (pcd(driver, PageNumber))
                {
                    StatusMessage = String.Format("{0} Page Loaded.", PageName);
                    OnStatusChanged(StatusMessage);
                    returnValue = true;
                    break;
                }

                StatusMessage = String.Format("{0} Page doesn't seem to be loaded yet, wait 2 seconds and check again.", PageName);
                OnStatusChanged(StatusMessage);

                //sleep for 2 seconds then check the page again
                System.Threading.Thread.Sleep(2000);
                MaxPageLoadWait--;

                StatusMessage = String.Format("Checking {0} Page again, {1} attempts remaining.", PageName, MaxPageLoadWait);
                OnStatusChanged(StatusMessage);
            }

            return returnValue;
        }

        private string SqueezeSpaces(string StringToSqeeze)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            return regex.Replace(StringToSqeeze, " ");
        }
        #endregion Helper Methods
    }
}