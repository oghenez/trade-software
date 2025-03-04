using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Xml; 
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace common
{
    public class errorHandler
    {
        private static string _lastErrorMsg = "";
        public static string lastErrorMessage
        {
            get
            {
                string tmp = _lastErrorMsg; _lastErrorMsg = ""; return tmp;
            }
            set { _lastErrorMsg = value; }
        }
    }

    public class globalSettings
    {
        public static CultureInfo GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }
    }
    public class configuration
    {
        private const string constRootXMLElementStr = "Configuration";
        public static bool GetConfiguration(string XMLFile, string encryptKey, 
                                    string subNode, string childNode, ref ArrayList aFields)
        {
            string saveEncryptionKey = cryption.encryptionKey;
            bool fEncryption = (encryptKey != "");
            if (fEncryption) cryption.encryptionKey = encryptKey; 

            XmlDocument XMLDoc = configuration.OpenXML(XMLFile);
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                aFields[idx] = configuration.SearchInXML(XMLDoc, subNode, childNode, aFields[idx].ToString());
                if (aFields[idx] == null) aFields[idx] = "";
                if (fEncryption && (aFields[idx].ToString().Trim() != ""))
                {
                    aFields[idx] = cryption.Decrypt(aFields[idx].ToString());
                }
            }
            if (fEncryption) cryption.encryptionKey = saveEncryptionKey; 
            return true;
        }

        public static bool SaveConfiguration(string XMLFile,string encryptKey,
                                    string subNode, string childNode, ArrayList aFields, ArrayList aValues)
        {
            string saveEncryptionKey = cryption.encryptionKey;
            bool fEncryption = ( encryptKey!="");
            if (fEncryption) cryption.encryptionKey = encryptKey; 

            string value;
            XmlDocument XMLDoc = configuration.OpenXML(XMLFile);
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                value = aValues[idx].ToString();
                if (fEncryption && (value.Trim() != ""))
                {
                    value = cryption.Encrypt(value);
                }
                configuration.WriteToXML(XMLDoc, subNode, childNode, aFields[idx].ToString(), value);
            }
            configuration.SaveXML(XMLDoc, XMLFile);
            if (fEncryption) cryption.encryptionKey = saveEncryptionKey; 
            return true;
        }

        public static XmlDocument OpenXML(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                //if file is not found, create a new xml file
                XmlTextWriter xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                //xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement(constRootXMLElementStr);
                xmlWriter.Close();
                xmlDoc.Load(fileName);
            }
            return xmlDoc;
        }

        public static bool SaveXML(XmlDocument xmlDoc, string fileName)
        {
            xmlDoc.Save(fileName);
            return true;
        }

        public static bool WriteToXML(string fileName, string nodeName, string childNodeName, string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                return AddToXML(fileName, nodeName, childNodeName, key, value);
            }
            WriteToXML(xmlDoc, nodeName, childNodeName, key, value);
            xmlDoc.Save(fileName);
            return true;
        }

        public static bool WriteToXML(XmlDocument xmlDoc, string nodeName, string childNodeName, string key, string value)
        {
            if (SearchInXML(xmlDoc, nodeName, childNodeName, key) == null)
            {
                AddToXML(xmlDoc, nodeName, childNodeName, key, value);
            }
            else
            {
                UpdateToXML(xmlDoc, nodeName, childNodeName, key, value);
            }
            return true;
        }

        public static bool AddToXML(string fileName, string nodeName, string childNodeName, string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
            }
            catch (System.IO.FileNotFoundException)
            {
                //if file is not found, create a new xml file
                XmlTextWriter xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                //xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement(constRootXMLElementStr);
                xmlWriter.Close();
                xmlDoc.Load(fileName);
            }
            AddToXML(xmlDoc, nodeName, childNodeName, key, value);
            xmlDoc.Save(fileName);
            return true;
        }

        public static bool AddToXML(XmlDocument xmlDoc, string nodeName, string childNodeName, string key, string value)
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlElement childNode = xmlDoc.CreateElement(nodeName);
            XmlElement childNode2 = xmlDoc.CreateElement(childNodeName);

            root.AppendChild(childNode);
            childNode.AppendChild(childNode2);
            childNode2.SetAttribute(key, value);
            return true;
        }

        public static bool UpdateToXML(string fileName, string nodeName, string childNodeName, string key, string newValue)
        {
            XmlDocument XMLDom = new XmlDocument();
            XMLDom.Load(fileName);
            UpdateToXML(XMLDom, nodeName, childNodeName, key, newValue);
            XMLDom.Save(fileName);
            return true;
        }

        public static bool UpdateToXML(XmlDocument XMLDom, string nodeName, string childNodeName, string key, string newValue)
        {
            try
            {
                XmlNodeList newXMLNodes = XMLDom.SelectNodes("/" + constRootXMLElementStr + "/" + nodeName + "/" + childNodeName);
                foreach (XmlNode newXMLNode in newXMLNodes)
                {
                    if (newXMLNode.Attributes[0].Name == key) newXMLNode.Attributes[0].Value = newValue;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveFromXML(string fileName, string nodeName, string childNodeName)
        {
            try
            {
                XmlDocument XMLDom = new XmlDocument();
                XMLDom.Load(fileName);
                RemoveFromXML(XMLDom, nodeName, childNodeName);
                XMLDom.Save(fileName);
                XMLDom = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveFromXML(XmlDocument XMLDom, string nodeName, string childNodeName)
        {
            try
            {
                XmlNodeList newXMLNodes = XMLDom.SelectNodes("/" + constRootXMLElementStr + "/" + nodeName + "/" + childNodeName);
                foreach (XmlNode newXMLNode in newXMLNodes)
                {
                    newXMLNode.ParentNode.RemoveAll();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string SearchInXML(string fileName, string nodeName, string childNodeName, string key)
        {
            XmlDocument XMLDom = new XmlDocument();
            XMLDom.Load(fileName);
            return SearchInXML(XMLDom, nodeName, childNodeName, key);
        }

        public static string SearchInXML(XmlDocument XMLDom, string nodeName, string childNodeName, string key)
        {
            XmlNodeList newXMLNodes = XMLDom.SelectNodes("/" + constRootXMLElementStr + "/" + nodeName + "/" + childNodeName);
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                if (newXMLNode.Attributes[0].Name == key) return newXMLNode.Attributes[0].Value.Trim();
            }
            return null; ;
        }

        public static bool SaveConnectionStringToConfig(string type, string server, string dbName, string account, string password)
        {
            if (settings.sysConfigurationFile.Trim() == "") return false;
            ArrayList aFields = new ArrayList();
            ArrayList aValues = new ArrayList();
            aFields.Add("SERVER"); aValues.Add(server);
            aFields.Add("DBNAME"); aValues.Add(dbName);
            aFields.Add("ACCOUNT"); aValues.Add(account);
            aFields.Add("PASSWORD"); aValues.Add(password);
            return common.configuration.SaveConfiguration(settings.sysConfigurationFile, "", "DBCONNECTION", type, aFields, aValues);
        }

        public static bool GetConnectionFromConfig(string type, ref ArrayList aFields)
        {
            if ( settings.sysConfigurationFile.Trim() == "") return false;
            common.configuration.GetConfiguration(settings.sysConfigurationFile, "", "DBCONNECTION", type, ref aFields);
            return true;
        }

        public static string GetConnectionStringFromConfig(string type)
        {
            ArrayList aFields = new ArrayList();
            aFields.Add("serverName"); aFields.Add("database");
            aFields.Add("account"); aFields.Add("password"); aFields.Add("timeout");
            if (!GetConnectionFromConfig(type, ref aFields)) return null;
            return database.BuidConnectionString(aFields[0].ToString(), aFields[1].ToString(), aFields[2].ToString(), 
                                                 aFields[3].ToString(), aFields[4].ToString());
        }
    }

    public class myComboBoxItem
    {
        private string _text;
        private string _value;

        public myComboBoxItem(string text, string value)
        {
            _text = text;
            _value = value;
        }
        //The item will display in the combo box based on how you implemented
        //ToString(). In this case, the name is displayed. But, when the object is
        //selected, you have this object, which may contain as much data as you need.
        public override string ToString()
        {
            return _text;
        }
        public virtual string Value
        {
            get {return _value;}
            set {_value =value;}
        }
        
        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
    public class Settings
    {
        public const char sysFindMarker = '?';
    }
    public static class sysLibs
    {
        public static bool sysIsDesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }

        public static void ShowCurrorWait()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        public static void ShowCurrorDefault()
        {
            Cursor.Current = Cursors.Default;
        }

        public static bool HaveFindMarker(ref string code)
        {
            bool retVal = HaveFindMarker(code);
            if (retVal) code = code.Replace(Settings.sysFindMarker.ToString(), "");
            return retVal;
        }
        public static bool HaveFindMarker(string code)
        {
            return code.Contains(Settings.sysFindMarker.ToString());
        }

        public static int VisibleGridColumnWidth(DataGridView gv)
        {
            int w = 0;
            for (int idx = 0; idx < gv.Columns.Count; idx++)
            {
                if (gv.Columns[idx].Visible)
                    w += gv.Columns[idx].Width;
            }
            return w;
        }

        public static void AutoFitGridColumn(DataGridView gv, string colName)
        {
            if (gv.Columns[colName] == null) return;
            int w = VisibleGridColumnWidth(gv);
            w -= gv.Columns[colName].Width - gv.RowHeadersWidth - SystemInformation.VerticalScrollBarThumbHeight - 2;
            gv.Columns[colName].Width = gv.Width - w;
        }

        public static bool MakeDate(int day, int month, int year, out DateTime dt)
        {
            dt = DateTime.Today;
            dt = dt.AddDays(day - dt.Day).AddMonths(month - dt.Month).AddYears(year - dt.Year);
            return (dt.Day == day && dt.Month == month && dt.Year == year);
        }

        public static string ValidateFileName(string fn)
        {
            //fn.Replace("\\", "-");
            //fn.Replace("/", "-");
            //char[] invalidChar = System.IO.Path.GetInvalidFileNameChars();
            for (int idx = 0; idx < fn.Length; idx++)
            {
                if (!Char.IsLetterOrDigit(fn[idx])) fn = fn.Replace(fn[idx], '-');
            }
            return fn;
        }
        public static bool ContainNeedFindMarker(ref string code)
        {
            bool retVal = code.Contains(settings.sysNeedFindMarker);
            if (retVal) code = code.Replace(settings.sysNeedFindMarker, "");
            return retVal;
        }

        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage()
        {
            MessageBox.Show("Hệ thống gặp lỗi", settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static string MakeConditionStr(string items, string prefixStr, string postfixStr, string operatorStr)
        {
            if (items == null) return "";
            string retStr = "";
            for (int idx = 0; idx < items.Length; idx++)
            {
                if (items[idx].ToString().Trim() == "") continue;
                retStr += (retStr == "" ? "" : " " + operatorStr + " ") +
                    "(" + prefixStr + items[idx].ToString() + postfixStr + ")";
            }
            return retStr;
        }

        public static string SayNumber(double number, string sepaChar, string unitStr)
        {
            string tmp = number.ToString();
            string[] numSplit = tmp.Split(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToCharArray());
            long p1 = 0; 
            if(numSplit.Length>0) long.TryParse(numSplit[0], out p1);
            long p2 = 0;
            if (numSplit.Length > 1) long.TryParse(numSplit[1], out p2);
            if (p2 != 0)
                 return SayNumber(p1, sepaChar,"") + " lẻ " + SayNumber(p2, sepaChar,"") + " " + unitStr;
            else return SayNumber(p1, sepaChar, unitStr);
        }

        public static string SayNumber(long number, string sepaChar, string unitStr)
        {
            int unitCount = 0;
            long remainder;
            bool flag = (number%1000)==0;
            string result = "";
            while (true)
            {
                remainder = number % 1000;
                number = (number - remainder) / 1000;
                if (remainder != 0)
                {
                    if (result != "") result = sepaChar + result;
                    result = NumberToString(remainder) + UnitStr(unitCount) + result;
                }
                if (number == 0) break;
                unitCount = unitCount + 1;
            }
            if (result != "")
            {
                result += " " + unitStr; 
                if (flag) result += " chẵn";
            }
            result = result.Trim();
            if(result!="") result = result.Substring(0,1).ToUpper() + result.Substring(1); 
            return result;
        }

        private static string UnitStr(int column)
        {
            switch (column)
            {
                case 0: return "";
                case 1: return " ngàn";
                case 2: return " triệu";
                case 3: return " tỉ";
                case 4: return " ngàn tỉ";
            }
            return "*";
        }

        private static string NumberToString(long number)
        {
            string result = "";
            long remainder = number % 100;
            long lcM100 = (number - remainder) / 100;
            if (lcM100 != 0)
            {
                if (result != "") result += " ";
                result += BasicNumberToString(lcM100, 0) + " trăm";
            }
            number = remainder;

            remainder = number % 10;
            long  lcM10 = (number - remainder) / 10;
            if (lcM10 != 0)
            {
                if (lcM10 == 1)
                {
                    result += " mười";
                    if (remainder != 0)
                    {
                        if (result != "") result += " ";
                    }
                    result += BasicNumberToString(remainder, 2);
                }
                else
                {
                    if (result != "") result += " ";
                    result += BasicNumberToString(lcM10, 0) + " mươi";
                    if (remainder != 0)
                    {
                        if (result != "") result += " ";
                        result += BasicNumberToString(remainder, 3);
                    }
                }
                return result;
            }

            if (remainder != 0)
            {
                if (lcM100 != 0) result += " lẻ";
                if (result != "") result += " ";
            }
            result += BasicNumberToString(remainder, 0);
            return result;
        }

        private static string BasicNumberToString(long num, int opt)
        {
            switch (num)
            {
                case 0: return ""; 
                case 1: 
                    return (opt == 1 || opt == 3) ? "mốt" : "một";
                case 2: return "hai";
                case 3: return "ba";
                case 4: return "bốn";
                case 5: return (opt == 2 || opt == 3) ? "lăm" : "năm";
                case 6: return "sáu";
                case 7: return "bảy";
                case 8: return "tám";
                case 9: return "chín";
            }
            return "*";
        }

        public static string UniqueString()
        {
            return Guid.NewGuid().ToString().Replace("-",""); 
        }

        public static string DateTimeToString(DateTime dt)
        {
            return dt.ToString(globalSettings.GetCurrentCulture());
        }

        /// <summary>
        /// Convert a formated-string to a double number
        /// </summary>
        /// <param name="doublStr">a formated-string of a double numer</param>
        /// <param name="db"> double nubmer converted form [doublStr]</param>
        /// <returns></returns>
        public static bool StrToDouble(string doublStr,out double db)
        {
            return double.TryParse(doublStr, NumberStyles.Float | NumberStyles.AllowThousands,globalSettings.GetCurrentCulture(), out db);
        }
        
        /// <summary>
        /// Convert a string to date time 
        /// </summary>
        /// <param name="dateTimeTxt"> Dateime-formated string</param>
        /// <param name="dt"> Datetime from dateTimeTxt (if valid)</param>
        /// <returns></returns>
        public static bool StringToDateTime(string dateTimeTxt,out DateTime convertedDateTime)
        {
            return DateTime.TryParse(dateTimeTxt,globalSettings.GetCurrentCulture(), DateTimeStyles.NoCurrentDateDefault, out convertedDateTime); 
        }

        /// <summary>
        /// In SQL command, a double string is always  99999999.999 (no thousand separator and period is used as decimal placeholder) 
        /// The function convert a double to a string for use in a SQL command
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ConvertToSQLDoubleString(double db)
        {
            decimal dec = (decimal)db;
            decimal d1 = Math.Ceiling(dec);
            decimal d2 = dec - d1;
            return d1.ToString("#####################0").Trim() + "." + d2.ToString("####0").Trim();
        }
        
        /// <summary>
        /// In SQL command, a date is a string of MM/DD/YYYY hh:mm:ss OR YYYY/MM/DD hh:mm:ss. The function convert any date to SQL Date-stype.
        /// Return "" if the date is invalid
        /// </summary>
        /// <param name="dateTxt">Date time string in current culture format</param>
        /// <returns></returns>
        public static string ConvertToSQLDateString(string dateTxt)
        {
            return ConvertToSQLDateString(dateTxt, true);
        }

        public static string ConvertToSQLDateString(string dateTxt,bool dateOnly)
        {
            DateTime date;
            string tmp = "";
            if (DateTime.TryParse(dateTxt, globalSettings.GetCurrentCulture(), DateTimeStyles.NoCurrentDateDefault, out date))
            {
                tmp = date.Year.ToString() +"/" + date.Month.ToString().PadLeft(2,'0')+ "/" + date.Day.ToString().PadLeft(2,'0');
                if (!dateOnly)
                    tmp += " " + date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            }
            return tmp;
        }

        /// <summary>
        /// In SQL command, a date is a string of MM/DD/YYYY hh:mm:ss. The function convert any date to SQL Date-stype.
        /// Return "" if the date is invalid
        /// </summary>
        /// <param name="date">DateTime in current format</param>
        /// <returns></returns>
        public static string ConvertToSQLDateString(DateTime date)
        {
            return ConvertToSQLDateString(date,true);
        }
        public static string ConvertToSQLDateString(DateTime date,bool dateOnly)
        {
            string tmp = date.Year.ToString() +"/"+ date.Month.ToString() + "/" + date.Day.ToString();
            if (!dateOnly)   tmp += " " +  date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            return tmp;
        }

        // Return : what field to be used as unit price 
        public static string GetPriceSetting()
        {
            return "price1";
        }


        public static bool ExecuteSQLCmd(string strQuery, string connStr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                if (!ExecuteSQLCmd(strQuery, conn)) return false;
                conn.Close(); conn.Dispose();
            }
            catch (Exception er)
            {
                sysLibs.ShowErrorMessage(er.Message);
                return false;
            }
            return true;
        }

        public static bool ExecuteSQLCmd(string strQuery, SqlConnection conn)
        {
            try
            {
                SqlCommand tmpCommand = new SqlCommand(strQuery, conn);
                tmpCommand.ExecuteNonQuery();
                tmpCommand.Dispose();
            }
            catch (Exception er)
            {
                sysLibs.ShowErrorMessage(er.Message);
                return false;
            }
            return true;
        }
        public static bool LoadToListBox(ListBox lb, string SQLCmd, string fld, string connStr)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    lb.Items.Add(reader[fld].ToString().Trim());
                }
            }
            catch(Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
                return false;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return true;
        }

        public static ArrayList LoadToArrayList(string SQLCmd, string fld, string connStr)
        {
            ArrayList arr = new ArrayList();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    arr.Add(reader[fld].ToString().Trim());
                }
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
                return null;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return arr;
        }

        public static string GetSubStr(string orgStr, int numberOfWords)
        {
            return GetSubStr(orgStr, numberOfWords, "...");
        }
        public static string GetSubStr(string orgStr, int numberOfWords, string postFix)
        {
            orgStr = orgStr.Trim();
            string[] wordList = orgStr.Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for (int idx = 0; idx < wordList.Length; idx++)
            {
                result += (result == "" ? "" : " ") + wordList[idx];
                if (idx >= numberOfWords - 1)
                {
                    result += postFix;
                    break;
                }
            }
            return result;
        }
        public static string MakeConditionStr(ArrayList myArrayList, string prefixStr, string postfixStr, string operatorStr)
        {
            if (myArrayList == null) return "";
            string retStr = "";
            for (int idx = 0; idx < myArrayList.Count; idx++)
            {
                if (myArrayList[idx].ToString().Trim() == "") continue;
                retStr += (retStr == "" ? "" : " " + operatorStr + " ") +
                    "(" + prefixStr + myArrayList[idx].ToString() + postfixStr + ")";
            }
            return retStr;
        }

        public static bool LoadToListBox(ListBox lb, ArrayList list)
        {
            try
            {
                lb.Items.Clear();
                for (int idx = 0; idx < list.Count; idx++)
                    lb.Items.Add(list[idx].ToString());
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
                return false;
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb, SortedList sList)
        {
            cb.Items.Clear();
            foreach (DictionaryEntry de in sList)
            {
                myComboBoxItem cbItem = new myComboBoxItem(de.Value.ToString(), de.Key.ToString());
                cb.Items.Add(cbItem);
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb, ArrayList list)
        {
            cb.Items.Clear();
            for (int idx=0;idx<list.Count;idx++)
            {
                //myComboBoxItem cbItem = new myComboBoxItem(de.Value.ToString(), de.Key.ToString());
                myComboBoxItem cbItem = (myComboBoxItem) list[idx];
                cb.Items.Add(cbItem);
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb,string SQLCmd, string valueFld, string textFld, string connStr)
        {
            try
            {
                SortedList sList = new SortedList();
                if (!LoadToSortedList(sList, SQLCmd, valueFld, textFld, connStr)) return false;
                LoadToComboBox(cb, sList);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool LoadToSortedList(SortedList sList, string SQLCmd, string valueFld, string textFld, string connStr)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    sList.Add(reader[valueFld].ToString().ToString().Trim(), reader[textFld].ToString().ToString().Trim());
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return true;
        }

        //Alloting an amount 
        public static ArrayList Apportion(double totalAmt, ArrayList weightList)
        {
            return Apportion(totalAmt, weightList, 0);
        }
        public static ArrayList Apportion(double totalAmt, ArrayList weightList, int precision)
        {
            try
            {
                ArrayList retList = new ArrayList();
                double totalWeight = 0;
                for (int idx = 0; idx < weightList.Count; idx++) totalWeight += (double)weightList[idx];
                if (totalWeight == 0) return null;

                double remainAmt, amt;
                int lastApportionIdx = -1;
                remainAmt = totalAmt;
                for (int idx = 0; idx < weightList.Count; idx++)
                {
                    amt = Math.Round(totalAmt * (double)weightList[idx] / totalWeight,precision);
                    retList.Add(amt);  remainAmt -= amt;
                    if ( amt!=0 ) lastApportionIdx = idx;
                }
                if (remainAmt != 0)
                {
                    if (lastApportionIdx < 0) return null;
                    retList[lastApportionIdx] = (double)retList[lastApportionIdx] + remainAmt;
                }
                return retList;
            }
            catch (Exception er) 
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
            }
            return null;
        }

        public static bool ApportionGrid(double totalAmt,DataGridView detailGrid,string weightColName,string allotedColName)
        {
            return ApportionGrid(totalAmt,detailGrid,weightColName, allotedColName, 0);
        }
        public static bool ApportionGrid(double totalAmt,DataGridView detailGrid,string weightColName,string allotedColName,int precision)
        {
            try
            {
                string tmp; double amt=0;
                ArrayList weightList = new ArrayList();
                for (int idx = 0; idx < detailGrid.Rows.Count; idx++)
                {
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    tmp = detailGrid.Rows[idx].Cells[weightColName].Value.ToString().Trim();
                    amt=0; double.TryParse(tmp,out amt); weightList.Add(amt);
                }
                ArrayList retList = Apportion(totalAmt, weightList,precision);
                if (retList == null) return false;
                int retListId = 0;
                for (int idx = 0; idx < detailGrid.Rows.Count; idx++)
                {
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    tmp = detailGrid.Rows[idx].Cells[weightColName].ToString().Trim();
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    if (detailGrid.Rows[idx].Cells[allotedColName].Value != null)
                        detailGrid.Rows[idx].Cells[allotedColName].Value = (double)retList[retListId]; 
                    retListId++;
                }
                return true;
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
            }
            return false;
        }

        public static int TurnBitOn(int number, int position)
        {
            return number | (1 << position);
        }

        public static int TurnBitOff(int number, int position)
        {
            int tmp=1;
            tmp = 1 << position;
            tmp = ~tmp;
            return tmp & number;
        }

        public static bool BitIsOn(int number, int position)
        {
            int tmp;
            tmp = 1 << position;
            return ((number & tmp) > 0);
        }

        public static bool InList(string[] list, string item)
        {
            return InList(list,item, false);
        }
        public static bool InList(string[] list, string item,bool force)
        {
            item = item.Trim();
            if (list == null) return true;
            if (force)
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item==list[idx]) return true;
                }
            }
            else
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item.Contains(list[idx])) return true;
                }
            }
            return false;
        }

        public static int IndexOf(string[] list, string s)
        {
            for (int idx = 0; idx < list.Length; idx++)
                if (list[idx] == s) return idx;
            return -1;
        }
        public static string List2String(string[] list)
        {
            return List2String(list, settings.sysSeparatorList[0].ToString());
        }
        public static string List2String(string[] list, string separator)
        {
            string retStr = "";
            for (int idx = 0; idx < list.Length; idx++)
            {
                retStr += (retStr == "" ? "" : separator) + list[idx];
            }
            return retStr;
        }

        public static decimal String2Decimal(string str)
        {
            decimal d = 0;
            decimal.TryParse(str, out d);
            return d;
        }
        public static int String2Int(string str)
        {
            int d = 0;
            int.TryParse(str, out d);
            return d;
        }

        public static void DeleteAll(BindingSource data)
        {
            while (data.Count > 0) data.RemoveAt(0);
        }

        public static void ThrowException(string msg)
        {
            throw new System.ArgumentException(msg);
        }
        public static void ThrowException(Exception er)
        {
            throw new System.ArgumentException(er.Message);
        }

        public static void WriteError(Exception er)
        {
            try
            {
                common.fileFuncs.WriteFile(er.Message + common.Consts.constTab + er.Source + common.Consts.constTab + er.TargetSite, common.settings.sysLogFile);
            }
            catch{}
        }
        public static void ExitApplication()
        {
            ExitApplication(0);
        }
        public static void ExitApplication(int code)
        {
            if (sysLibs.sysIsDesignMode)
            {
                sysLibs.ShowMessage("Exit Application");
                return;
            }
            else  Application.Exit();
            System.Environment.Exit(code);
        }
        
    }
    public class database
    {
        public static string BuidConnectionString(string serverAddr, string dbName, string account, string password)
        {
            return BuidConnectionString(serverAddr, dbName, account, password, "");
        }
        public static string BuidConnectionString(string serverAddr, string dbName, string account, string password,string timeout)
        {
            string configStr = "Data Source=" + serverAddr.Trim() + ";Initial Catalog=" + dbName.Trim() +
                                ";Persist Security Info=True;User ID=" + account.Trim();
            if (password.Trim() != "") configStr += ";password=" + password;
            if (timeout.Trim() != "") configStr += ";Connection Timeout=" + timeout;
            return configStr;
        }

        public static void CheckDbConnection(string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open(); conn.Close(); conn.Close();
        }
    }

    public static class EnvironmentLibs
    {
        public static string GetExecutePath()
        {
            return fileFuncs.FileNamePath(Application.ExecutablePath);
        }
        public static string GetExecuteFullPath()
        {
            return Application.ExecutablePath;
        }

        public static string GetWebRootPath()
        {
            return System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        }
        public static string GetWebVirtualPath()
        {
            return System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
        }
        public static string GetWebName()
        {
            return System.Web.Hosting.HostingEnvironment.SiteName;
        }
    }
}
