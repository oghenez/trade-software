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
                //if (common.Settings.sysDebugMode)
                    //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                    //return "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                if (_dbConnectionString == null)
                {
                    common.dbConnectionInfo dbInfo = common.configuration.GetDbConectionInfo(0, true); //The first connection string
                    _dbConnectionString = common.database.BuidConnectionString(dbInfo);
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
                //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                //return "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                if (_importConnectionString == null)
                {
                    common.dbConnectionInfo dbInfo = common.configuration.GetDbConectionInfo(1, false); //The second connection string
                    //Use the first connection string if the second one doesnot exist
                    if (dbInfo!=null) _importConnectionString = common.database.BuidConnectionString(dbInfo);
                    else _importConnectionString = dbConnectionString;
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
