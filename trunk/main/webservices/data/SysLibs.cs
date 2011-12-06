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

namespace data
{
    public class SysLibs
    {
        private static string _dbConnectionString = null;
        public static string dbConnectionString
        {
            get
            {
                //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                return "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                if (_dbConnectionString == null) _dbConnectionString = common.configuration.GetDbConnectionString();
                return _dbConnectionString;
            }
            set
            {
                _dbConnectionString = value;
            }
        }
        public static bool CheckAllDbConnection()
        {
            if (!common.database.CheckDbConnection(dbConnectionString)) return false;
            return true;
        }
        public static void ClearConnectionString()
        {
            _dbConnectionString = null;
        }
    }
}
