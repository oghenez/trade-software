using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using commonTypes;

namespace databases
{
    public static class SysLibs
    {
        private static string _dbConnectionString = null;
        public static string dbConnectionString
        {
            get
            {
                if (_dbConnectionString == null)
                {                   
                    if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.localT440)
                        _dbConnectionString = "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                    else
                        if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.localHP)
                            _dbConnectionString = @"Data Source=HAIQUAN\MSSQLSERVER2008;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=123456";
                    else
                    if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.SIT440)
                        _dbConnectionString = "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                    if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.UAT)
                        //UAT and Prod                        
                        _dbConnectionString = "Data Source=(local);Initial Catalog=stock_uat;Persist Security Info=True;User ID=sa;Password=123456";
                    else
                        if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.Prod)
                        //UAT and Prod                        
                        _dbConnectionString = "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=123456";
                    
                }                
                return _dbConnectionString;
            }
            set
            {
                _dbConnectionString = value;
            }
        }

        private static string _importConnectionString = null;
        public static string importConnectionString
        {
            get
            {
                if (_importConnectionString == null)
                {
                    
                    if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.localT440)
                        _importConnectionString = "Data Source=(local);Initial Catalog=stock_import;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                    else
                        if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.localHP)
                            _importConnectionString = @"Data Source=HAIQUAN\MSSQLSERVER2008;Initial Catalog=stock_import;Persist Security Info=True;User ID=sa;Password=123456";
                        else
                            if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.SIT440)
                                _importConnectionString = "Data Source=(local);Initial Catalog=stock_import;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                            else
                    if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.UAT)
                        //UAT and Prod                        
                        _importConnectionString = "Data Source=(local);Initial Catalog=stock_import_uat;Persist Security Info=True;User ID=sa;Password=123456";
                    else
                        if (commonTypes.Settings.environmentMode == commonTypes.Settings.environmentDebugMode.Prod)
                            //UAT and Prod                        
                            _importConnectionString = "Data Source=(local);Initial Catalog=stock_import;Persist Security Info=True;User ID=sa;Password=123456";
                    
                }
                return _importConnectionString;                
            }
            set
            {
                _importConnectionString = value;
            }
        }       

        public static bool CheckAllDbConnection()
        {
            return  common.database.CheckDbConnection(dbConnectionString) &&
                    common.database.CheckDbConnection(importConnectionString);
        }
        public static void ClearConnectionString()
        {
            _dbConnectionString = null;
            _importConnectionString = null;
        }
    }
}
