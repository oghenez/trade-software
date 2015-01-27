using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace common
{
    public class Consts
    {
        public const string constCRLF = "\r\n";
        public const char constTab = (char)9;
        //===============================================
        //Hotkeys 
        //===============================================
        public const Keys constHotKeyAddNew = Keys.F3;
        public const Keys constHotKeySave = Keys.F2;
        public const Keys constHotKeyEdit = Keys.F4;
        public const Keys constHotKeyAddLine = Keys.F5;
        public const Keys constHotKeyDeleteLine = Keys.F8;
        public const Keys constHotKeyViewSize = Keys.F9;

        //Microsoft system : http://support.microsoft.com/kb/320584
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SYSKEYDOWN = 0x104;
    }
    public class settings
    {
        public const bool sysDebugMode = false;
        public const string sysApplicationName = "Quan ly";
        public const bool   sysEnterSameAsTabKey = true;
        public const string sysNeedFindMarker = "?";
        public const string sysNewDataAutoNumberMarker = "<AUTO>";
        public const string sysConfigurationFile = "sysconfig.xml";
        public const string sysLogFile = "syslog.txt";
        public static char[] sysSeparatorList = new char[] {','};
        public static char[] sysSeparatorsWord = new char[] { ' ', '-', ',' };
    }

    public delegate void myEventHandler(object sender, myExceptionEventArgs e);
    public class myExceptionEventArgs : EventArgs
    {
        private Exception _myException = null;
        public Exception myException
        {
            get { return _myException; }
            set { _myException = value; }
        }
    }
    public class distribution
    {
        private class distributeObj
        {
            public distributeObj(decimal w, decimal v)
            {
                this.weight = w; this.value = v;
            }
            public decimal weight = 0, value = 0;
        }
        private decimal totalWeight;
        private SortedList distributionList;
        public distribution()
        {
            this.totalWeight = 0;
            this.distributionList = new SortedList();
        }

        public void Remove(string code)
        {
            if (this.distributionList.ContainsKey(code))
            {
                distributeObj obj = (distributeObj)this.distributionList[code];
                this.distributionList.Remove(code);
                this.totalWeight -= obj.weight;
            }
        }
        public void Add(string code, decimal weight)
        {
            if (this.distributionList.ContainsKey(code))
            {
                distributeObj obj = (distributeObj)this.distributionList[code];
                obj.weight += weight;
                this.distributionList[code] = obj;
            }
            else this.distributionList.Add(code, new distributeObj(weight, 0));
            this.totalWeight += weight;

        }
        public bool Distribute(decimal value)
        {
            return Distribute(value, 0);
        }
        public bool Distribute(decimal value, int precision)
        {
            if (value == 0) return true;
            if (this.totalWeight == 0) return false;
            decimal remainValue = value, tmp;
            distributeObj obj;
            int idx = 0;
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                idx++;
                if (idx == this.distributionList.Count) tmp = remainValue;
                else tmp = Math.Round(value * obj.weight / this.totalWeight, precision);
                obj.value += tmp;
                remainValue -= tmp;
            }
            return true;
        }
        public void ResetValues()
        {
            foreach (DictionaryEntry item in this.distributionList)
            {
                ((distributeObj)item.Value).value = 0;
            }
        }
        public void Reset()
        {
            this.distributionList.Clear();
            this.totalWeight = 0;
        }
        public SortedList GetDistribution()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.value);
            }
            return retList;
        }
        public SortedList GetWeights()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.weight);
            }
            return retList;
        }
        public SortedList GetValues()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.value);
            }
            return retList;
        }
        public decimal GetWeight(string code)
        {
            if (this.distributionList.ContainsKey(code))
                return ((distributeObj)this.distributionList[code]).weight;
            return 0;
        }
        public decimal GetValue(string code)
        {
            if (this.distributionList.ContainsKey(code))
                return ((distributeObj)this.distributionList[code]).value;
            return 0;
        }
        public distribution Clone()
        {
            distributeObj obj;
            distribution clone = new distribution();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                clone.Add(item.Key.ToString(), obj.weight);
            }
            return clone;
        }
    }
}
