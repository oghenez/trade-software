using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Xml;
using System.Reflection;
using application;
using commonTypes;
using commonClass;
using System.Runtime.Serialization;

namespace application.Strategy
{
    //Meta data keeps descriptive information of a strategy
    public class StrategyMeta
    {
        public AppTypes.StrategyTypes Type = AppTypes.StrategyTypes.Strategy;
        public string Category = "";
        public Type ClassType = null;
        public Type FormType = typeof(forms.baseStrategyForm);

        //Suggested default values : list of KeyPair(string, integer)
        public common.DictionaryList ParameterList = null;

        //Parameter descriptions
        public IList<string> ParameterDescriptions = null;

        //Name and Code of the strategy
        public string Code = "";
        public string Name = "";

        //Description of the strategy
        public string Description = "";
        //URL for more info
        public string URL = "";

        //Author
        public string Authors = "";
        //Version
        public string Version = "";

        public double[] Parameters
        {
            get
            {
                object[] values = this.ParameterList.Values;
                double[] paras = new double[values.Length];
                for (int idx = 0; idx < values.Length; idx++)
                {
                    paras[idx] = (double)values[idx];
                }
                return paras;
            }
            set
            {
                string[] keys = this.ParameterList.Keys;
                for (int idx = 0; idx < keys.Length; idx++)
                {
                    this.ParameterList.Add(keys[idx], value[idx]);
                }
            }
        }
        public int ParameterPrecision = 0;

        /// <summary>
        /// Set Parameters property from a formated string.
        /// </summary>
        /// <param name="str">String in the format <key=value>,...,<key=value></param>
        private static common.DictionaryList String2ParameterList(string str)
        {
            double para = 0;
            common.DictionaryList list = new common.DictionaryList();
            common.myKeyValueItem[] keyValues = common.system.String2KeyValueList(str, ",", "=");
            for (int idx = 0; idx < keyValues.Length; idx++)
            {
                if (!double.TryParse(keyValues[idx].Value, out para)) continue;
                list.Add(keyValues[idx].Key, para);
            }
            return list;
        }

        /// <summary>
        /// Convert ParameterList property into string in format <key=value>,...,<key=value>
        /// </summary>
        public string ParameterToString()
        {
            string retStr = "";
            string[] keys = this.ParameterList.Keys;
            object[] values = this.ParameterList.Values;
            for (int idx = 0; idx < keys.Length; idx++)
            {
                retStr += (retStr == "" ? "" : common.Settings.sysSeparatorList[0].ToString()) + keys[idx] + "=" + values[idx].ToString();
            }
            return retStr;
        }


        /// <summary>
        /// Get meta data from meta file
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static bool GetMeta(StrategyMeta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("Type");
            aFields.Add("Code");
            aFields.Add("Name");
            aFields.Add("Description");
            aFields.Add("Category");

            aFields.Add("Parameters");
            aFields.Add("ParameterPrecision");
            aFields.Add("ParameterDescriptions");

            aFields.Add("URL");
            aFields.Add("Authors");
            aFields.Add("Version");
            common.configuration.GetConfiguration(new string[] { "STRATEGY", meta.ClassType.Name }, aFields, StrategyData.sysXmlDocument, false);

            meta.Type = AppTypes.Text2StrategyType(aFields[0]);
            meta.Code = aFields[1];
            meta.Name = aFields[2];
            meta.Description = aFields[3];
            meta.Category = aFields[4];

            meta.ParameterList = String2ParameterList(aFields[5]);
            int num = 0; int.TryParse(aFields[6], out num);
            meta.ParameterPrecision = num;
            meta.ParameterDescriptions = common.system.String2List(aFields[7]);

            meta.URL = aFields[8];
            meta.Authors = aFields[9];
            meta.Version = aFields[10];
            return true;
        }
    }
}
