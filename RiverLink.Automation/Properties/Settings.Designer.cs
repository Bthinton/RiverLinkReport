﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiverLink.Automation.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("About RiverLink")]
        public string V_HomePage {
            get {
                return ((string)(this["V_HomePage"]));
            }
            set {
                this["V_HomePage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/RiverLink.External/Login")]
        public string U_Login {
            get {
                return ((string)(this["U_Login"]));
            }
            set {
                this["U_Login"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RiverLink Account Login")]
        public string V_LoginPage {
            get {
                return ((string)(this["V_LoginPage"]));
            }
            set {
                this["V_LoginPage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Account Number")]
        public string V_AccountOverview {
            get {
                return ((string)(this["V_AccountOverview"]));
            }
            set {
                this["V_AccountOverview"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"txtUserName\"]")]
        public string X_UserField {
            get {
                return ((string)(this["X_UserField"]));
            }
            set {
                this["X_UserField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"txtPassword\"]")]
        public string X_PassField {
            get {
                return ((string)(this["X_PassField"]));
            }
            set {
                this["X_PassField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"btnLogin\"]")]
        public string X_LoginBTN {
            get {
                return ((string)(this["X_LoginBTN"]));
            }
            set {
                this["X_LoginBTN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"MainContent_dashBoard_dvVehicles_groupPlaceholderContainer\"]//tr")]
        public string X_VehicleTable {
            get {
                return ((string)(this["X_VehicleTable"]));
            }
            set {
                this["X_VehicleTable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"MainContent_databound2_groupPlaceholderContainer\"]//tr")]
        public string X_TransactionTable {
            get {
                return ((string)(this["X_TransactionTable"]));
            }
            set {
                this["X_TransactionTable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Total Transactions Displayed")]
        public string V_TransactionHistory {
            get {
                return ((string)(this["V_TransactionHistory"]));
            }
            set {
                this["V_TransactionHistory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/RiverLink.External/Account/TransactionHistory")]
        public string U_Transaction {
            get {
                return ((string)(this["U_Transaction"]));
            }
            set {
                this["U_Transaction"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"MainContent_ddlResultsPerPage\"]")]
        public string X_ResultsPerPageBTN {
            get {
                return ((string)(this["X_ResultsPerPageBTN"]));
            }
            set {
                this["X_ResultsPerPageBTN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"MainContent_ddlResultsPerPage\"]/option[last()]")]
        public string X_MaxPerPage {
            get {
                return ((string)(this["X_MaxPerPage"]));
            }
            set {
                this["X_MaxPerPage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//*[@id=\"MainContent_dpgPagingArea\"]/a[last() - 1]")]
        public string X_TransactionNextBTN {
            get {
                return ((string)(this["X_TransactionNextBTN"]));
            }
            set {
                this["X_TransactionNextBTN"] = value;
            }
        }
    }
}
