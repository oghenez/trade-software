using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using application;

namespace Indicators
{
    public class Data
    {
        public const string constAssemplyNamePattern = "*Indicators.dll";
        public const string constMetaFileName = "indicators.xml";

        public static Color sysDefaultLineColor = Color.Red;
        public static int sysDefaultLineWeight = 1;
        public static AppTypes.ChartTypes sysDefaultLineChartType = AppTypes.ChartTypes.Line;  

        public static string sysMetaFullFileName
        {
            get
            {
                return common.fileFuncs.ConcatFileName(sysFileDirectory, constMetaFileName);
            }
        }
        public static string sysFileDirectory
        {
            get
            {
                return Application.StartupPath;
            }
        }

        private static common.DictionaryList _Metas = null;
        /// <summary>
        /// List keeps all meta data dynamically collected from indicator .DLL files
        /// </summary>
        public static common.DictionaryList Metas
        {
            get
            {
                if (_Metas == null)
                {
                    _Metas = new common.DictionaryList();
                    Libs.GetMeta(Application.StartupPath, "Indicators.dll", _Metas);
                }
                return _Metas;
            }
        }
    }
    public class Helpers
    {
        private Meta MetaData = new Meta();
        public Meta GetInfo() { return MetaData; }

        protected void Init(Type indicatorType, Type indicatorFormType,string typeName,Type inputDataType,string xmlFileName)
        {
            MetaData.ClassType = indicatorType;
            MetaData.InputDataType = inputDataType;
            MetaData.FormType = indicatorFormType;
            Meta.GetMeta(MetaData);
        }
        protected void Init(Type indicatorType, Type indicatorFormType, Type inputDataType)
        {
            Init(indicatorType, indicatorFormType, indicatorType.Name, inputDataType, Data.sysMetaFullFileName);
        }
        protected void Init(Type indicatorType, Type indicatorFormType)
        {
            Init(indicatorType, indicatorFormType, indicatorType.Name, typeof(DataSeries), Data.sysMetaFullFileName);
        }
    }
    public class Meta
    {
        public class OutputInfo
        {
            public OutputInfo(Color cl, int w, AppTypes.ChartTypes chartType)
            {
                Color = cl;
                Weight = w;
                ChartType = chartType;
            }
            public Color Color = Data.sysDefaultLineColor;
            public int Weight = Data.sysDefaultLineWeight;
            public AppTypes.ChartTypes ChartType = Data.sysDefaultLineChartType;
        }

        public string Category = "";
        public Type FormType = typeof(forms.baseIndicatorForm);
        public Type ClassType = null;
        public Type InputDataType = typeof(DataSeries);
        public bool DrawInNewWindow = false;

        //Suggested default values : list of KeyPair(string, integer)
        public common.DictionaryList ParameterList = null;
        public common.DictionaryList OutputInfoList = null;
        
        //Parameter descriptions
        public IList<string> ParameterDescriptions = null;

        public int ParameterPrecision = 0;
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
                for (int idx = 0; idx < keys.Length && idx < value.Length; idx++)
                {
                    this.ParameterList.Add(keys[idx], value[idx]);
                }
            }
        }
        public OutputInfo[] Output
        {
            get
            {
                object[] values = this.OutputInfoList.Values;
                OutputInfo[] output = new OutputInfo[values.Length];
                for (int idx = 0; idx < values.Length; idx++)
                {
                    output[idx] = (OutputInfo)values[idx];
                }
                return output;
            }
            set
            {
                string[] keys = this.OutputInfoList.Keys;
                for (int idx = 0; idx < keys.Length && idx < value.Length; idx++)
                {
                    Color color = (value[idx] == null ? Data.sysDefaultLineColor : value[idx].Color);
                    int weight = (value[idx] == null ? Data.sysDefaultLineWeight : value[idx].Weight);
                    AppTypes.ChartTypes chartType = (value[idx] == null ? Data.sysDefaultLineChartType : value[idx].ChartType);
                    this.OutputInfoList.Add(keys[idx], new OutputInfo(color, weight, chartType));
                }
            }
        }

        public string ParameterString
        {
            get
            {
                return common.system.ToString(this.Parameters);
            }
            set
            {
                this.Parameters = common.system.String2DoubleList(value);
            }
        }

        public bool inNewWindows = false;

        //Name of the indicator
        public string Name = "";
        //Description of the indicator
        public string Description = "";
        //URL for more info
        public string URL = "";

        //Author
        public string Authors = "";
        //Version
        public string Version = "";

        /// <summary>
        /// Get meta data from meta file
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static bool GetMeta(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("Category");
            aFields.Add("Parameters");
            aFields.Add("ParameterPrecision");
            aFields.Add("ParameterDescriptions");
            aFields.Add("Output");
            aFields.Add("DrawInNewWindow");
            aFields.Add("Name");
            aFields.Add("Description");
            aFields.Add("URL");
            aFields.Add("Authors");
            aFields.Add("Version");

            common.configuration.GetConfiguration(Data.sysMetaFullFileName, "INDICATORS", meta.ClassType.Name, aFields, false);
            meta.Category = aFields[0];
            meta.ParameterList = String2ParameterList(aFields[1]);

            int num = 0; int.TryParse(aFields[2], out num);
            meta.ParameterPrecision = num;

            meta.ParameterDescriptions = common.system.String2List(aFields[3]);
            meta.OutputInfoList = String2OutputList(aFields[4]);
            meta.DrawInNewWindow = (aFields[5]==Boolean.TrueString);
            meta.Name = aFields[6];
            meta.Description = aFields[7];
            meta.URL = aFields[8];
            meta.Authors = aFields[9];
            meta.Version = aFields[10];
            return true;
        }

        /// <summary>
        /// Set Parameters property from a formated string.
        /// </summary>
        /// <param name="str">String in the format <key=value>,...,<key=value></param>
        private static common.DictionaryList String2ParameterList(string str)
        {
            double para = 0;
            common.DictionaryList list = new common.DictionaryList();
            common.myKeyValueItem[] keyValues = common.system.String2KeyValueList(str,"," , "=");
            for (int idx = 0; idx < keyValues.Length; idx++)
            {
                if (!double.TryParse(keyValues[idx].Value, out para)) continue;
                list.Add(keyValues[idx].Key, para);
            }
            return list;
        }
        /// <summary>
        /// Set Output property from a formated string.
        /// </summary>
        /// <param name="str"> In the format ([key]=[Color]:[Weight*]:[ChartType*])  </param>
        /// <returns></returns>
        private static common.DictionaryList String2OutputList(string str)
        {
            common.DictionaryList list = new common.DictionaryList();
            common.myKeyValueItem[] keyValues = common.system.String2KeyValueList(str, ",", "=");
            Color color = Data.sysDefaultLineColor;
            int weight = 1;
            AppTypes.ChartTypes chartType = Data.sysDefaultLineChartType; 
            for (int idx = 0; idx < keyValues.Length; idx++)
            {
                string[] parts = common.system.String2List(keyValues[idx].Value, ":", StringSplitOptions.None);
                color = (parts.Length > 0 ? ColorTranslator.FromHtml(parts[0]) : Data.sysDefaultLineColor);
                weight = Data.sysDefaultLineWeight;
                if (parts.Length > 1) int.TryParse(parts[1], out weight);
                chartType = (parts.Length > 2 ? AppTypes.Text2ChartType(parts[2]) : Data.sysDefaultLineChartType);
                list.Add(keyValues[idx].Key, new Meta.OutputInfo(color, weight, chartType));
            }
            return list;
        }

        //Convert Meta.OutputInfo to string and vice versa
        public static Meta.OutputInfo[] String2OutputInfo(string str)
        {
            Meta.OutputInfo[] outputInfoList = new Meta.OutputInfo[0];
            string[] items = common.system.String2List(str);
            for (int idx = 0; idx < items.Length; idx++)
            {
                string[] parts = common.system.String2List(items[idx], ":");
                Color color = Data.sysDefaultLineColor;
                if (parts.Length > 0) color = ColorTranslator.FromHtml(parts[0]);
                int weight = 1;
                if (parts.Length > 1) int.TryParse(parts[1], out weight);

                AppTypes.ChartTypes chartType = AppTypes.ChartTypes.Line;
                if (parts.Length > 2) chartType = AppTypes.Text2ChartType(parts[2]); 
                Array.Resize(ref  outputInfoList, outputInfoList.Length + 1);
                outputInfoList[outputInfoList.Length - 1] = new Meta.OutputInfo(color, weight, chartType);
            }
            return outputInfoList;
        }
        public static string OutputInfo2Tring(Meta.OutputInfo[] outputInfoList)
        {
            string str = "";
            for (int idx = 0; idx < outputInfoList.Length; idx++)
            {
                str += (str == "" ? "" : ",") +
                       ColorTranslator.ToHtml(outputInfoList[idx].Color) + ":" + outputInfoList[idx].Weight.ToString();
            }
            return str;
        }
    }
    
    public class Libs
    {
        // To cache data used in indicator chart
        private static common.DictionaryList dataCache = new common.DictionaryList();

        /// <summary>
        /// Clear cache that keep caculated data to speed up performance.
        /// </summary>
        public static void ClearCache() 
        {
            dataCache.Clear();
        }

        /// <summary>
        /// Calculated primary indicator data. If an indicator has several output,one is called "primary data" 
        /// and others are calles "exatra data".
        /// </summary>
        /// <param name="myData"> Data used to calculate indicator data.</param>
        /// <param name="meta">Indicator meta data</param>
        /// <param name="periods">List of indicator parametters</param>
        /// <returns></returns>
        public static DataSeries GetIndicatorData(application.Data myData, Meta meta)
        {
            string cacheName = myData.DataStockCode + "-" + meta.ClassType.Name;
            object[] para = new object[1];
            
            if (meta.InputDataType == typeof(DataBars))  para[0] = myData.Bars;


            else para[0] = myData.Close;
            for (int idx = 0; idx < meta.Parameters.Length; idx++)
            {
                Array.Resize(ref para, para.Length + 1);
                para[para.Length - 1] = meta.Parameters[idx];
                cacheName += "-" + meta.Parameters[idx].ToString();
            }
            Array.Resize(ref para, para.Length + 1);
            para[para.Length - 1] = meta.Name;

            DataSeries indicatorSeries = (DataSeries)dataCache.Find(cacheName);
            if (indicatorSeries == null)
            {
                indicatorSeries = (DataSeries)Activator.CreateInstance(meta.ClassType, para);
                dataCache.Add(cacheName, indicatorSeries);
            }
            return indicatorSeries;
        }

        /// <summary>
        /// Get extra indicator data.
        /// Some indicator such as MACD having more than one output series which can be accessed by "ExtraSeries".
        /// "ExtraSeries" properties must be implemented in multi-ouput indicator.
        /// </summary>
        /// <param name="ds"> The primary data returned by Indicator</param>
        /// <param name="meta">Indicator meta data</param>
        /// <param name="extraInfo">Information(period,color,wegiht...) about EXTRA output.It's the "ExtraInfo" properties from Indicator form.</param>
        /// <returns></returns>
        public static DataSeries[] GetIndicatorData(DataSeries ds, Meta meta)
        {
            PropertyInfo propertyInfo = meta.ClassType.GetProperty("ExtraSeries");
            if (propertyInfo == null) return null;
            return (DataSeries[])propertyInfo.GetValue(ds, null);
        }

        /// <summary>
        /// Get indictor form that allow user to input parameters.
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static forms.baseIndicatorForm GetIndicatorForm(Meta meta)
        {
            return (forms.baseIndicatorForm)Activator.CreateInstance(meta.FormType, meta);
        }
        /// <summary>
        /// Find/Get indicator by name. Return null if not found
        /// </summary>
        /// <param name="MetaList">List keeps meta data</param>
        /// <param name="name">Indicator name to find</param>
        /// <returns></returns>
        private static Meta FindMetaByName(common.DictionaryList MetaList, string name)
        {
            object obj = MetaList.Find(name);
            if (obj == null) return null;
            return (Meta)obj;
        }

        /// <summary>
        /// Find/Get indicator by name. Return null if not found
        /// </summary>
        /// <param name="name">Indicator name to find</param>/// 
        /// <returns></returns>
        public static Meta FindMetaByName(string name)
        {
            return Libs.FindMetaByName(Data.Metas, name);
        }

        /// <summary>
        ///  Find/Get all indicator of the same category
        /// </summary>
        /// <param name="metasList">List keeps meta data </param>
        /// <param name="category">What category to find/get </param>
        /// <returns></returns>
        private static Meta[] FindMetaByCat(common.DictionaryList metasList, string category)
        {
            Meta[] retMetas = new Meta[0];
            category = category.Trim().ToLower();
            for (int idx = 0; idx < metasList.Values.Length; idx++)
            {
                Meta meta = (Meta)metasList.Values[idx];
                if (meta.Category.Trim().ToLower() != category) continue;
                Array.Resize(ref retMetas, retMetas.Length + 1);
                retMetas[retMetas.Length - 1] = meta;
            }
            return retMetas;
        }
        /// <summary>
        /// Find/Get all indicator of the same category
        /// </summary>
        /// <param name="name">What category to find/get</param>
        /// <returns></returns>
        public static Meta[] FindMetaByCat(string name)
        {
            return Libs.FindMetaByCat(Data.Metas, name);
        }

        /// <summary>
        ///Get Meta from a DDL file name 
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="MetaList"></param>
        public static void GetMeta(string assemblyFile, common.DictionaryList MetaList)
        {
            GetMeta(Assembly.LoadFile(assemblyFile), MetaList);
        }
        private static void GetMeta(Assembly indicatorAss, common.DictionaryList MetaList)
        {
            Type[] mTypes = indicatorAss.GetTypes();
            Meta Meta;
            string HelpersTypeName = typeof(Helpers).Name;
            foreach (Type type in mTypes)
            {
                if (type.BaseType.Name != HelpersTypeName) continue;
                // get info about property
                Type indicatorType = indicatorAss.GetType(type.FullName);
                object indicatorInstance = Activator.CreateInstance(indicatorType);
                Meta = (Meta)indicatorType.InvokeMember("GetInfo",
                                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, indicatorInstance, null);
                MetaList.Add(Meta.ClassType.Name, Meta);
            }
            return;
        }

        /// <summary>
        /// Get Meta from all indicator DDL in a drectory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="files"></param>
        /// <param name="MetaList"></param>
        public static void GetMeta(string path, string files, common.DictionaryList MetaList)
        {
            string[] dllFileList = Directory.GetFiles(path, files);
            for (int idx1 = 0; idx1 < dllFileList.Length; idx1++)
            {
                GetMeta(dllFileList[idx1], MetaList);
            }
        }

        /// <summary>
        ///  Create menu listing all indictors with click events. 
        /// - Indicators having category existed in indicatorCat table are grouped to that category
        /// - Indicators having category NOT existed in indicatorCat are placed under the category menus
        /// </summary>
        /// <param name="Metas">Meta infomation of plug-in indicators</param>
        /// <param name="toMenu">Menu where indicator menus are added</param>
        /// <param name="ShowIndicatorHandler">Function fired on Click Event</param>
        private static void CreateIndicatorMenu(common.DictionaryList Metas, ToolStripMenuItem toMenu, System.EventHandler ShowIndicatorHandler)
        {
            data.baseDS.indicatorCatDataTable indicatorCatTbl = new data.baseDS.indicatorCatDataTable();
            application.dataLibs.LoadData(indicatorCatTbl);
            for (int idx1 = 0; idx1 < indicatorCatTbl.Count; idx1++)
            {
                Indicators.Meta[] tmpMetas = Libs.FindMetaByCat(Metas, indicatorCatTbl[idx1].code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                ToolStripMenuItem catMenuItem = new ToolStripMenuItem();
                catMenuItem.Name = toMenu.Name + "-group-" + indicatorCatTbl[idx1].code;
                catMenuItem.Text = indicatorCatTbl[idx1].description;
                toMenu.DropDownItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = toMenu.Name + "-" + tmpMetas[idx2].ClassType.Name;
                    menuItem.Tag = tmpMetas[idx2].ClassType.Name;
                    menuItem.Text = tmpMetas[idx2].Name;
                    menuItem.Click += new System.EventHandler(ShowIndicatorHandler);
                    catMenuItem.DropDownItems.Add(menuItem);
                }
            }
            Indicators.Meta meta;
            for (int idx2 = 0; idx2 < Metas.Values.Length; idx2++)
            {
                meta = (Indicators.Meta)Metas.Values[idx2];
                if (indicatorCatTbl.FindBycode(meta.Category.Trim()) != null) continue;
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = toMenu.Name + "-group-" + meta.ClassType.Name;
                menuItem.Tag = meta.ClassType.Name;
                menuItem.Text = meta.Name;
                toMenu.DropDownItems.Add(menuItem);
                menuItem.Click += new System.EventHandler(ShowIndicatorHandler);
            }
        }

        /// <summary>
        ///  Create menu listing all indictors with click events. 
        /// - Indicators having category existed in indicatorCat table are grouped to that category
        /// - Indicators having category NOT existed in indicatorCat are placed under the category menus
        /// </summary>
        /// <param name="toMenu">Menu where indicator menus are added</param>
        public static void CreateIndicatorMenu(ToolStripMenuItem toMenu, System.EventHandler ShowIndicatorHandler)
        {
            CreateIndicatorMenu(Data.Metas, toMenu, ShowIndicatorHandler);
        }

        //Read and save setting to users's XML file
        public static void GetUserSettings(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Add("params");
            aFields.Add("output");
            aFields.Add("drawInNewWindow");
            if (!configuration.ReadUserSettings(sysLibs.sysLoginCode, meta.ClassType.FullName, aFields)) return;
            meta.Parameters = common.system.String2DoubleList(aFields[0]);
            Meta.OutputInfo[] saveMetaOutput = meta.Output;
            meta.Output = Meta.String2OutputInfo(aFields[1]);

            //Do not allow to change ChartType
            for(int idx=0;idx<meta.Output.Length;idx++)
            {
                meta.Output[idx].ChartType = saveMetaOutput[idx].ChartType;
            }
            meta.DrawInNewWindow = (aFields[2]==Boolean.TrueString);
        }
        public static void SaveUserSettings(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("params");
            aFields.Add("output");
            aFields.Add("drawInNewWindow");
            StringCollection aValues = new StringCollection();
            aValues.Add(common.system.ToString(meta.Parameters));
            aValues.Add(Meta.OutputInfo2Tring(meta.Output));
            aValues.Add(meta.DrawInNewWindow.ToString());
            configuration.SetUserSettings(sysLibs.sysLoginCode, meta.ClassType.FullName, aFields, aValues);
        }
    }
}
