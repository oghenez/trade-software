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

namespace application.Strategy
{
    public class CatList : List<commonClass.DataCategory>
    {
        public commonClass.DataCategory Find(string code)
        {
            for (int idx = 0; idx < this.Count; idx++)
            {
                if (this[idx].Code == code) return this[idx];
            }
            return null;
        }
    }
    
    //Meta data keeps descriptive information of a strategy
    public class StrategyMeta
    {
        public AppTypes.StrategyTypes Type =  AppTypes.StrategyTypes.Strategy;
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
                    paras[idx] =  (double)values[idx];
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

    public static class StrategyLibs
    {
        public static string GetMetaName(string code)
        {
            StrategyMeta meta = FindMetaByCode(code);
            return meta.ClassType.Name;
        }

        /// <summary>
        /// Calculated primary strategy databases. If an strategy has several output,one is called "primary data" 
        /// and others are calles "exatra data".
        /// </summary>
        /// <param name="myData"> Data used to calculate strategy databases.</param>
        /// <param name="meta">strategy meta data</param>
        /// <returns>Null if error</returns>
        public static StrategyData.TradePoints Analysis(AnalysisData myData, StrategyMeta meta)
        {
            //Fix loi do dai bang cach them myData.Close.Count
            string cacheName = "data-" + myData.DataStockCode + "-" +
                                         myData.DataTimeScale.Code + "-" + 
                                         myData.Close.Count + "-" +
                                         meta.ClassType.Name;

            object[] processParas = new object[2];
            processParas[0] = myData;
            processParas[1] = meta.Parameters;
            //First , find in cache
            StrategyData.TradePoints tradePoints = (StrategyData.TradePoints)StrategyData.FindInCache(cacheName);
            if (tradePoints != null) return tradePoints;

            //Then, Call Execute() method to get trading points.
            object strategyInstance = GetStrategyInstance(meta.ClassType);
            if (strategyInstance == null) return null;
            tradePoints = (StrategyData.TradePoints)meta.ClassType.InvokeMember("Execute",
                                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, strategyInstance, processParas);

            StrategyData.AddToCache(cacheName, tradePoints);
            return tradePoints;
        }
        public static StrategyData.TradePoints AnalysisStrategy(AnalysisData myData, string strategyCode)
        { 
            StrategyMeta meta = FindMetaByCode(strategyCode);
            if (meta == null) return null;
            return Analysis(myData,meta);
        }

        /// <summary>
        /// Get/Create strategy process. The function scans strategy .DLL files for assembly infomation 
        /// and create an instance for the require strategy type. It also cache the used instance to boost perfomance
        /// </summary>
        /// <param name="strategyName"></param>
        /// <returns> Instance object or null if not found </returns>
        private static object GetStrategyInstance(Type strategyType)
        {
            //First, find in cache. 
            string cacheName = "instance-" + strategyType.Name;
            object strategyInstance = StrategyData.FindInCache(cacheName);
            if (strategyInstance != null) return strategyInstance;

            //Then, create it if not in cache
            strategyInstance = Activator.CreateInstance(strategyType);
            StrategyData.AddToCache(cacheName, strategyInstance);
            return strategyInstance;
        }

        /// <summary>
        /// Get form that allow user to input parameters.
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static forms.baseStrategyForm GetStrategyForm(StrategyMeta meta)
        {
            string cacheName = "form-" + meta.ClassType.Name;
            forms.baseStrategyForm form = (forms.baseStrategyForm)StrategyData.FindInCache(cacheName);
            if (form != null) return form;
            form = (forms.baseStrategyForm)Activator.CreateInstance(meta.FormType, meta);
            StrategyData.AddToCache(cacheName, form);
            return form;
        }
        /// <summary>
        /// Find/Get strategy by name. Return null if not found
        /// </summary>
        /// <param name="MetaList">List keeps meta data</param>
        /// <param name="name">strategy name to find</param>
        /// <returns>Null if not found</returns>
        private static StrategyMeta FindMetaByName(common.DictionaryList MetaList, string name)
        {
            object obj = MetaList.Find(name);
            //TUAN - 29 Sept 2012 fix bug profit detail and all profit details
            foreach (application.Strategy.StrategyMeta item in MetaList.Values)
            {
                if(item.Name.Equals(name))
                {
                    obj = item;                
                    break;
                }
            }
            //TUAN - 29 Sept 2012 fix bug profit detail and all profit details
            if (obj == null) return null;
            return (StrategyMeta)obj;
        }

        /// <summary>
        /// Find/Get strategy by code. Return null if not found
        /// </summary>
        /// <param name="MetaList">List keeps meta data</param>
        /// <param name="name">strategy code to find</param>
        /// <returns>Null if not found</returns>
        private static StrategyMeta FindMetaByCode(common.DictionaryList MetaList, string code)
        {
            for (int idx = 0; idx < MetaList.Values.Length; idx++)
            { 
                if ( ((StrategyMeta)MetaList.Values[idx]).Code==code) return (StrategyMeta)MetaList.Values[idx];
            }
            return null;
        }

        /// <summary>
        /// Find/Get strategy by name. Return null if not found
        /// </summary>
        /// <param name="name">strategy name to find</param>/// 
        /// <returns>Null if not found</returns>
        public static StrategyMeta FindMetaByName(string name)
        {
            return FindMetaByName(StrategyData.MetaList, name);
        }

        /// <summary>
        /// Find/Get strategy by code. Return null if not found
        /// </summary>
        /// <param name="name">strategy code to find</param>/// 
        /// <returns>Null if not found</returns>
        public static StrategyMeta FindMetaByCode(string code)
        {
            return FindMetaByCode(StrategyData.MetaList, code);
        }

        /// <summary>
        ///  Find/Get all strategy of the same category
        /// </summary>
        /// <param name="metasList">List keeps meta data </param>
        /// <param name="category">What category to find/get </param>
        /// <returns></returns>
        private static StrategyMeta[] FindMetaByCat(common.DictionaryList metasList,AppTypes.StrategyTypes  strategyType, string category)
        {
            StrategyMeta[] retMetas = new StrategyMeta[0];
            category = category.Trim().ToLower();
            for (int idx = 0; idx < metasList.Values.Length; idx++)
            {
                StrategyMeta meta = (StrategyMeta)metasList.Values[idx];
                if ((meta.Type != strategyType) ||
                    (meta.Category.Trim().ToLower() != category) ) continue;
                Array.Resize(ref retMetas, retMetas.Length + 1);
                retMetas[retMetas.Length - 1] = meta;
            }
            return retMetas;
        }
        /// <summary>
        /// Find/Get all strategy of the same category
        /// </summary>
        /// <param name="name">What category to find/get</param>
        /// <returns></returns>
        public static StrategyMeta[] FindMetaByCat(string name, AppTypes.StrategyTypes strategyType)
        {
            return FindMetaByCat(StrategyData.MetaList, strategyType, name);
        }

        /// <summary>
        ///Get Meta from a DDL file name 
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="MetaList"></param>
        private static void GetMeta(string assemblyFile, common.DictionaryList MetaList)
        {
            GetMeta(Assembly.LoadFrom(assemblyFile), MetaList);
        }
        private static void GetMeta(Assembly strategyAss, common.DictionaryList MetaList)
        {
            Type[] mTypes = strategyAss.GetTypes();
            StrategyMeta Meta;
            string strategyHelperTypeName = typeof(baseHelper).Name;
            foreach (Type type in mTypes)
            {
                if (type.BaseType.Name != strategyHelperTypeName) continue;
                // get info about property
                Type strategyType = strategyAss.GetType(type.FullName);
                try
                {
                    object strategyInstance = Activator.CreateInstance(strategyType);
                    Meta = (StrategyMeta)strategyType.InvokeMember("GetInfo",
                                        BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, strategyInstance, null);
                    if (Meta.Code.Trim() == "") continue;
                    MetaList.Add(Meta.ClassType.Name, Meta);
                }
                catch(Exception er)
                {
                   commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"STR001",er);
                }
            }
            return;
        }

        /// <summary>
        /// Get Meta from all strategy DDL in a drectory
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
        ///  Create menu listing all strategies with click events. 
        /// - strategy having category existed in strategyCat table are grouped to that category
        /// - strategy having category NOT existed in strategyCat are placed under the category menus
        /// </summary>
        /// <param name="Metas">Meta infomation of plug-in strategy</param>
        /// <param name="toMenu">Menu where strategy menus are added</param>
        /// <param name="handler">Function fired on Click Event</param>
        private static void CreateMenu(common.DictionaryList Metas,AppTypes.StrategyTypes strategyType,
                                       ToolStripMenuItem toMenu,System.EventHandler handler)
            
        {
            for (int idx1 = 0; idx1 < StrategyData.myCatList.Count; idx1++)
            {
                StrategyMeta[] tmpMetas = FindMetaByCat(Metas, strategyType, StrategyData.myCatList[idx1].Code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                ToolStripMenuItem catMenuItem = new ToolStripMenuItem();
                catMenuItem.Name = toMenu.Name + "-group-" + StrategyData.myCatList[idx1].Code;
                catMenuItem.Text = StrategyData.myCatList[idx1].Description;
                toMenu.DropDownItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = toMenu.Name + "-" + tmpMetas[idx2].ClassType.Name;
                    menuItem.Tag = tmpMetas[idx2];
                    menuItem.Text = tmpMetas[idx2].Name;
                    if (handler != null) menuItem.Click += new System.EventHandler(handler);
                    catMenuItem.DropDownItems.Add(menuItem);
                }
            }
            StrategyMeta meta;
            for (int idx2 = 0; idx2 < Metas.Values.Length; idx2++)
            {
                meta = (StrategyMeta)Metas.Values[idx2];
                if (meta.Type != strategyType) continue;
                if (StrategyData.myCatList.Find(meta.Category.Trim()) != null) continue;
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = toMenu.Name + "-group-" + meta.ClassType.Name;
                menuItem.Tag = meta;
                menuItem.Text = meta.Name;
                toMenu.DropDownItems.Add(menuItem);
                if (handler!=null) menuItem.Click += new System.EventHandler(handler);
            }
        }


        /// <summary>
        ///  Create menu listing all strategies with click events. 
        /// - strategy having category existed in strategyCat table are grouped to that category
        /// - strategy having category NOT existed in strategyCat are placed under the category menus
        /// </summary>
        /// <param name="toMenu">Menu where strategy menus are added</param>
        /// <param name="handler">Function fired on Click Event</param>
        public static void CreateMenu(AppTypes.StrategyTypes strategyType,
                                      ToolStripMenuItem toMenu, System.EventHandler handler)
        {
            if (toMenu!=null)
                CreateMenu(StrategyData.MetaList, strategyType, toMenu, handler);
        }


        /// <summary>
        ///  Load all strategies of scpecific type. 
        /// - strategy having category existed in strategyCat table are grouped to that category
        /// - strategy having category NOT existed in strategyCat are placed under the category menus
        /// </summary>
        /// <param name="strategyType"></param>
        /// <param name="toObj"></param>
        public static void LoadStrategy(AppTypes.StrategyTypes strategyType, ToolStripComboBox toObj)
        {
            common.DictionaryList Metas = StrategyData.MetaList;

            toObj.Items.Clear();
            for (int idx1 = 0; idx1 < StrategyData.myCatList.Count; idx1++)
            {
                StrategyMeta[] tmpMetas = FindMetaByCat(Metas, strategyType, StrategyData.myCatList[idx1].Code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                toObj.Items.Add(new common.myComboBoxItem("--" + StrategyData.myCatList[idx1].Description.Trim() + "--", ""));
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    toObj.Items.Add(new common.myComboBoxItem(tmpMetas[idx2].Name, tmpMetas[idx2].Code));
                }
            }
            //Donot have category
            StrategyMeta meta;
            bool flag = true;
            for (int idx2 = 0; idx2 < Metas.Values.Length; idx2++)
            {
                if (flag)
                {
                    toObj.Items.Add(new common.myComboBoxItem("--" + Languages.Libs.GetString("others") + "--", ""));
                    flag = false;
                }
                meta = (StrategyMeta)Metas.Values[idx2];
                if (meta.Type != strategyType) continue;
                if (StrategyData.myCatList.Find(meta.Category.Trim()) != null) continue;
                toObj.Items.Add(new common.myComboBoxItem(meta.Name, meta.Code));
            }
        }

        #region strategy estimation

        public class EstimationData
        {
            public AppTypes.TradeActions tradeAction = AppTypes.TradeActions.None;
            public DateTime onDate = common.Consts.constNullDate;
            public decimal price = 0;
            public decimal qty=0;
            public decimal amt = 0;
            public decimal feeAmt = 0;
            public decimal ownedQty = 0;
            public decimal ownedAmt = 0;
            public decimal cashAmt = 0;
            public decimal profitAmt = 0;
            public bool ignored = false;
        }
        public delegate void AfterEachEstimationFunc(EstimationData data,object retObj);
        public delegate void AfterEstimationFunc(EstimationData data, object retObj);

        /// <summary>
        /// Find index in [data] where the date is greater or equal [minDate]
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIdx">Index where start to find</param>
        /// <param name="endIdx">Index where end the find</param>
        /// <param name="minDate"></param>
        /// <returns>Index of date in [data] or -1 if not found</returns>
        private static int FindDateIdx(AnalysisData data, int startIdx, int endIdx, DateTime minDate)
        {
            for (int idx = startIdx; idx <= endIdx; idx++)
            {
                if (DateTime.FromOADate(data.DateTime[idx]).Date >= minDate)
                    return idx;
            }
            return -1;
        }

        /// <summary>
        /// Estimate the profit from advices produced by analysis process. 
        /// The function will produce a list of "transactions" assuming to be done from analysis advices. 
        /// </summary>
        /// <param name="data"> Data used for analysis </param>
        /// <param name="tradePoints">Trade point list generated by analysis process</param>
        /// <param name="options">User- specific options : captital, max Buy...</param>
        /// <param name="returnObj">Returned object </param>
        /// <param name="afterEachEstimationFunc">Call-back function at the end of each tradepoind estimation</param>
        /// <param name="afterEstimationFunc">Call-back function at the end of estimation process</param>
        /// 
        public static void EstimateTrading(AnalysisData data, TradePointInfo[] tradePoints, EstimateOptions options,
                           object returnObj, AfterEachEstimationFunc afterEachEstimationFunc, AfterEstimationFunc afterEstimationFunc)
        {
            EstimationData myEstimationData = new EstimationData();

            global::databases.baseDS.stockExchangeRow marketRow = databases.DbAccess.GetStockExchange(data.DataStockCode); 
            decimal initCapAmt = options.TotalCapAmt * options.MaxBuyAmtPerc / 100;
            decimal priceWeight = marketRow.priceRatio;
            decimal feePerc = marketRow.tranFeePerc / 100;
            short buy2SellInterval = marketRow.minBuySellDay;

            databases.baseDS.stockCodeRow stockCodeRow = application.SysLibs.FindAndCache_StockCode(data.DataStockCode);
            if (stockCodeRow == null) return;

            int transDataIdx, lastBuyId = -1;
            decimal stockQty = 0, qty;
            decimal maxBuyQty = (decimal)(stockCodeRow.noOutstandingStock * options.MaxBuyQtyPerc / 100);
            decimal stockAmt = 0, stockPrice = 0, amt, feeAmt, totalFeeAmt = 0;
            decimal cashAmt = initCapAmt;
            

            //DateTime transDate = common.Consts.constNullDate; ;
            for (int idx = 0; idx < tradePoints.Length; idx++)
            {
                transDataIdx = tradePoints[idx].DataIdx;
                qty = 0; amt = 0;
                myEstimationData.ignored = false;

                stockPrice = (decimal)data.Close[transDataIdx];
                switch (tradePoints[idx].TradeAction)
                {
                    case AppTypes.TradeActions.Buy:
                        //Assume that we can only buy if we have money 
                        qty = (stockPrice == 0 ? 0 : Math.Floor(cashAmt / ((stockPrice * priceWeight) * (1 + feePerc))));
                        if (qty > maxBuyQty) qty = maxBuyQty;
                        if (qty != 0)
                        {
                            amt = qty * stockPrice * priceWeight;
                            stockAmt += amt;
                            stockQty += qty;
                            feeAmt = Math.Round(amt * feePerc, 0);
                            cashAmt -= amt + feeAmt;
                            totalFeeAmt += feeAmt;
                            lastBuyId = transDataIdx;
                        }
                        else myEstimationData.ignored = true;
                        break;

                    case AppTypes.TradeActions.Sell:
                        //Can sell if own some stock
                        if (stockQty <= 0)
                        {
                            myEstimationData.ignored = true;
                            break;
                        }
                        // Not applicable to sell
                        if (lastBuyId < 0)
                        {
                            myEstimationData.ignored = true;
                            break;
                        }
                        //==========================
                        // Check T+4 contrainst 
                        //==========================
                        int minAllowSellPointIdx = lastBuyId + buy2SellInterval;

                        // [minAllowSellPoint] is out of data bound , ignore it.
                        if (minAllowSellPointIdx >= data.DateTime.Count)
                        {
                            myEstimationData.ignored = true;
                        }
                        
                        // Violate T4 contrainst ?
                        if (!myEstimationData.ignored && tradePoints[idx].DataIdx < minAllowSellPointIdx)
                        {
                            // Keep inapplicable Sells ??
                            if (Settings.sysKeepInApplicableSell)
                            {
                                //If it is the last trade point, make transaction (sell) at [minAllowSellPoint]
                                if (idx >= tradePoints.Length-1)
                                {
                                    transDataIdx = minAllowSellPointIdx;
                                }
                                else 
                                {
                                    //If there is some trade point between it and [minAllowSellPoint], ignore it
                                    if (tradePoints[idx + 1].DataIdx < minAllowSellPointIdx)
                                    {
                                        myEstimationData.ignored = true;
                                    }
                                    else
                                    {
                                        transDataIdx = minAllowSellPointIdx;
                                    }
                                }
                            }
                            else myEstimationData.ignored = true;
                        }
                        //Ok, sell it
                        if (myEstimationData.ignored != true)
                        {
                            stockPrice = (decimal)data.Close[transDataIdx];
                            qty = stockQty;
                            amt = qty * stockPrice * priceWeight;
                            stockQty = 0; stockAmt = 0;
                            feeAmt = Math.Round(amt * feePerc, 0);
                            cashAmt += amt - feeAmt;
                            totalFeeAmt += feeAmt;

                            //Adjust trade point to refresh chages by T4 constrainst
                            tradePoints[idx].DataIdx = transDataIdx;
                        }
                        else
                        {
                            tradePoints[idx].isValid = false;
                        }
                        break;
                }
                myEstimationData.tradeAction = tradePoints[idx].TradeAction;
                myEstimationData.onDate = DateTime.FromOADate(data.DateTime[transDataIdx]); 
                myEstimationData.price = stockPrice;
                myEstimationData.qty = qty;
                myEstimationData.amt = amt;
                myEstimationData.feeAmt = totalFeeAmt;
                myEstimationData.ownedQty = stockQty;
                myEstimationData.ownedAmt = stockAmt;
                myEstimationData.cashAmt = cashAmt;
                myEstimationData.profitAmt = cashAmt + stockAmt - initCapAmt;
                if (afterEachEstimationFunc != null)
                {
                    afterEachEstimationFunc(myEstimationData, returnObj);
                }
            }
            if (afterEstimationFunc != null)
            {
                afterEstimationFunc(myEstimationData, returnObj);
            }
        }


        /// <summary>
        /// Get estimated profit from adviced trade point
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tradePoints"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static decimal EstimateTrading_Profit(AnalysisData data, TradePointInfo[] tradePoints, EstimateOptions options)
        {
            EstimateSum myEstimateSum = new EstimateSum();
            EstimateTrading(data, tradePoints, options,myEstimateSum,null, AfterEstimation_GetProfit);
            return myEstimateSum.total; 

        }
        private static void AfterEstimation_GetProfit(EstimationData data, object retObj)
        {
            (retObj as EstimateSum).total = data.profitAmt;
        }
        private class EstimateSum
        {
            public decimal total = 0;
        }

        /// <summary>
        /// Get the estimation detail from adviced trade point
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tradePoints"></param>
        /// <param name="options"></param>
        /// <param name="toTbl"> Table of assumed transactions. Each row procides detail information of a transcation and it's profit</param>
        public static databases.tmpDS.tradeEstimateDataTable EstimateTrading_Details(AnalysisData data, TradePointInfo[] tradePoints, EstimateOptions options)
        {
            databases.tmpDS.tradeEstimateDataTable toTbl = new databases.tmpDS.tradeEstimateDataTable();
            EstimateTrading(data, tradePoints, options,toTbl, AfterEachEstimation_AddToTable,null);
            return toTbl;
        }
        private static void AfterEachEstimation_AddToTable(EstimationData data, object retObj)
        {
            databases.tmpDS.tradeEstimateRow row;
            row = (retObj as databases.tmpDS.tradeEstimateDataTable).NewtradeEstimateRow();
            row.ignored = data.ignored;
            row.tradeAction = data.tradeAction.ToString();
            row.onDate = data.onDate;
            row.price = data.price;
            row.qty = data.qty;
            row.amt = data.amt;
            row.feeAmt = data.feeAmt;
            row.stockQty = data.ownedQty;
            row.stockAmt = data.ownedAmt;
            row.cashAmt = data.cashAmt;
            row.totalAmt = row.cashAmt + row.stockAmt;
            row.profit = data.profitAmt;
            (retObj as databases.tmpDS.tradeEstimateDataTable).AddtradeEstimateRow(row);
        }

        public static List<decimal[]> Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale,
                                                             StringCollection stockCodeList, StringCollection strategyList,EstimateOptions option)
        {
            List<decimal[]> retList = new List<decimal[]>(); 

            commonClass.DataParams dataParm = new DataParams(timeScale.Code,timeRange,0);
            for (int rowId = 0; rowId < stockCodeList.Count; rowId++)
            {
                StrategyData.ClearCache();
                AnalysisData analysisData = new AnalysisData(stockCodeList[rowId],dataParm);
                decimal[] rowRetList = new decimal[strategyList.Count];
                for (int colId = 0; colId < strategyList.Count; colId++)
                {
                    StrategyData.TradePoints advices = AnalysisStrategy(analysisData, strategyList[colId]);
                    if (advices != null)
                    {
                        rowRetList[colId] = EstimateTrading_Profit(analysisData, ToTradePointInfo(advices), option);
                    }
                    else rowRetList[colId] = 0;
                }
                retList.Add(rowRetList);
            }
            return retList;
        }

        public static List<double[]> Estimate_Matrix_LastBizWeight(commonClass.DataParams dataParm,StringCollection stockCodeList, StringCollection strategyList)
        {
            //System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            //stopWatch.Start();
            List<double[]> retList = new List<double[]>();
            for (int rowId = 0; rowId < stockCodeList.Count; rowId++)
            {
                StrategyData.ClearCache();
                AnalysisData analysisData = new AnalysisData(stockCodeList[rowId], dataParm);
                double[] rowRetList = new double[strategyList.Count];
                for (int colId = 0; colId < strategyList.Count; colId++)
                {
                    StrategyData.TradePoints tradePoints = AnalysisStrategy(analysisData, strategyList[colId]);
                    if (tradePoints != null && tradePoints.Count>0)
                    {
                        rowRetList[colId] = (tradePoints[tradePoints.Count - 1] as TradePointInfo).BusinessInfo.Weight;
                        //if (common.Settings.sysDebugMode && (tradePoints[tradePoints.Count - 1] as TradePointInfo).DataIdx != analysisData.Close.Count - 1)
                        //{
                        //    commonClass.SysLibs.WriteSysLog( AppTypes.SyslogTypes.Others,stockCodeList[rowId], strategyList[colId]);
                        //}
                    }
                    else rowRetList[colId] = double.NaN;
                }
                retList.Add(rowRetList);
            }
            //stopWatch.Stop();
            //string tmp = common.dateTimeLibs.TimeSpan2String(stopWatch.Elapsed);
            return retList;
        }
        
        //??
        public static void ExportData(string toFileName, AnalysisData data, params object[] paras)
        {
            if (paras.Length == 0) return;
            // Define the new datatable
            DataTable tbl = new DataTable();
            DataColumn col0 = new DataColumn(data.DateTime.ToString(), typeof(DateTime)); tbl.Columns.Add(col0);
            DataColumn col1 = new DataColumn(data.Open.ToString(), typeof(Decimal)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn(data.Close.ToString(), typeof(Decimal)); tbl.Columns.Add(col2);
            DataColumn col3 = new DataColumn(data.High.ToString(), typeof(Decimal)); tbl.Columns.Add(col3);
            DataColumn col4 = new DataColumn(data.Low.ToString(), typeof(Decimal)); tbl.Columns.Add(col4);
            DataColumn col5 = new DataColumn(data.Volume.ToString(), typeof(Decimal)); tbl.Columns.Add(col5);
            for (int colId = 0; colId < paras.Length; colId++)
            {
                DataColumn col = new DataColumn("val" + colId.ToString().Trim(), typeof(Decimal));
                tbl.Columns.Add(col);
            }
            double[] val = new double[paras.Length];
            int rowCount = ((double[])paras[0]).Length;
            DataRow row;
            for (int rowId = 0; rowId < rowCount; rowId++)
            {
                row = tbl.Rows.Add();
                row[0] = DateTime.FromOADate(data.DateTime[rowId]);
                row[1] = data.Open[rowId];
                row[2] = data.Close[rowId];
                row[3] = data.High[rowId];
                row[4] = data.Low[rowId];
                row[5] = data.Volume[rowId];
                for (int colId = 0; colId < paras.Length; colId++)
                {
                    row[colId + 6] = ((double[])paras[colId])[rowId];
                }
            }
            common.Export.ExportToExcel(tbl, toFileName);
        }
        
        //Estimate for one stock ; ??Will be done

        //Structure represent the estimation criteria for the "strategy accuracry" on specific stock.
        public class OneStockStrategyStats
        {
            public string strategyCode = "";
            public decimal startAmt = 0, closingAmt = 0;
            public int totalTrans = 0, noWinTrans = 0, noLossTrans = 0;
            public decimal winPerc = 0, lossPerc = 0;
            public decimal maxAmtInWin = 0, maxAmtInLoss = 0, avgAmtInWin = 0, avgAmtInLoss = 0;
            public decimal totalWinAmt = 0, totalLossAmt = 0;
            public decimal avgNoDayHoldStockInWin = 0;   //average of the number of days to hlod stock in win transaction;
            public decimal maxNoTransWinInRow = 0, maxNoTransLossInRow = 0;
        }

        //Estimate for all stock
        private class StrategyStats
        {
            public int winStockCount = 0, lossStockCount = 0;
            public double winStockPerc = 0, lossStockPerc = 0;
            public double maxWinAmt = 0, maxLossAmt = 0;
            public double avgWinAmt = 0, avgLossAmt = 0;
            public double totalWinAmt = 0, totalLossAmt = 0;
        }

        //Structure represent the estimation criteria for the "strategy accuracry" on all stocks.
        private static StrategyStats EstimateStrategy(decimal[] list)
        {
            StrategyStats estData = new StrategyStats();
            for (int rowId = 0; rowId < list.Length; rowId++)
            {
                if (list[rowId] > 0)
                {
                    estData.winStockCount++;
                    if ((double)list[rowId] > estData.maxWinAmt) estData.maxWinAmt = (double)list[rowId];
                    estData.totalWinAmt += (double)list[rowId];
                }
                if (list[rowId] < 0)
                {
                    estData.lossStockCount++;
                    if ((double)list[rowId] < estData.maxLossAmt) estData.maxLossAmt = (double)list[rowId];
                    estData.totalLossAmt += (double)list[rowId];
                }
            }
            if (list.Length > 0)
            {
                estData.winStockPerc = 100 * estData.winStockCount / (double)list.Length;
                estData.lossStockPerc = 100 * estData.lossStockCount / (double)list.Length;
            }
            if (estData.winStockCount > 0)
            {
                estData.avgWinAmt = estData.totalWinAmt / (double)estData.winStockCount;
            }
            if (estData.lossStockCount > 0)
            {
                estData.avgLossAmt = estData.totalLossAmt / (double)estData.lossStockCount;
            }
            return estData;
        }

        public static StringCollection GetStrategyStatsText()
        {
            StringCollection text = new StringCollection();
            text.Add("01." + Languages.Libs.GetString("winStockPerc"));
            text.Add("02." + Languages.Libs.GetString("lossStockPerc"));
            text.Add("03." + Languages.Libs.GetString("maxWinAmt"));
            text.Add("04." + Languages.Libs.GetString("maxLossAmt"));
            text.Add("05." + Languages.Libs.GetString("averageWinAmt"));
            text.Add("06." + Languages.Libs.GetString("averageLossAmt"));
            return text;
        }
        public static DataTable GetStrategyStats(DataTable tbl)
        {
            ArrayList estDataList = new ArrayList();
            decimal[] dataList = new decimal[tbl.Rows.Count];
            for (int colId = 1; colId < tbl.Columns.Count; colId++)
            {
                //Convert to list
                for (int rowId = 0; rowId < tbl.Rows.Count; rowId++) dataList[rowId] = (decimal)tbl.Rows[rowId][colId];
                estDataList.Add(EstimateStrategy(dataList));
            }
            //Create table to store data
            DataTable retTbl = tbl.Clone();
            StrategyStats estData;

            //GetStrategyStatsText() will return text for this text
            retTbl.Rows.Add("");
            retTbl.Rows.Add("");
            retTbl.Rows.Add("");
            retTbl.Rows.Add("");
            retTbl.Rows.Add("");
            retTbl.Rows.Add(""); 

            //retTbl.Rows.Add("07.Số lượng CP lời");      //winStockCount 
            //retTbl.Rows.Add("08.Số lượng CP lỗ");       //lossStockCount
            //retTbl.Rows.Add("09.Tổng lời");             //totalWinAmt 
            //retTbl.Rows.Add("10.Tồng lỗ");              //totalLossAmt
            for (int colId = 0; colId < estDataList.Count; colId++)
            {
                estData = (StrategyStats)estDataList[colId];

                retTbl.Rows[0][colId + 1] = estData.winStockPerc;
                retTbl.Rows[1][colId + 1] = estData.lossStockPerc;

                retTbl.Rows[2][colId + 1] = estData.maxWinAmt;
                retTbl.Rows[3][colId + 1] = estData.maxLossAmt;

                retTbl.Rows[4][colId + 1] = estData.avgWinAmt;
                retTbl.Rows[5][colId + 1] = estData.avgLossAmt;

                //retTbl.Rows[6][colId + 1] = estData.winStockCount;
                //retTbl.Rows[7][colId + 1] = estData.lossStockCount;
                //retTbl.Rows[8][colId + 1] = estData.totalWinAmt;
                //retTbl.Rows[9][colId + 1] = estData.totalLossAmt;
            }
            return retTbl;
        }
        #endregion


        /// <summary>
        /// Show strategy form that allow user to change default setting and save these settings
        /// </summary>
        /// <param name="meta"></param>
        public static void ShowStrategyForm(StrategyMeta meta)
        {
            GetUserSettings(meta);
            forms.baseStrategyForm form = GetStrategyForm(meta);
            form.ShowDialog();
        }
        //Read and save setting to users's XML file
        public static bool GetUserSettings(StrategyMeta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Add("params");
            if (!Configuration.GetLocalUserConfig(meta.ClassType.FullName, aFields))
                return false;
            meta.Parameters = common.system.String2DoubleList(aFields[0]);
            return true;
        }
        public static bool SaveUserSettings(StrategyMeta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("params");
            StringCollection aValues = new StringCollection();
            aValues.Add(common.system.ToString(meta.Parameters));
            if (!Configuration.SaveLocalUserConfig(meta.ClassType.FullName, aFields, aValues)) return false;
            return true;
        }

        //Load strategy to table
        public static void LoadStrategy(databases.tmpDS.codeListDataTable tbl, AppTypes.StrategyTypes type)
        {
            StrategyMeta meta;
            databases.tmpDS.codeListRow row;
            for (int idx = 0; idx < StrategyData.MetaList.Values.Length; idx++)
            {
                meta = (StrategyMeta)StrategyData.MetaList.Values[idx];
                if (meta.Type != type) continue;
                row = tbl.NewcodeListRow();
                row.code = ((StrategyMeta)StrategyData.MetaList.Values[idx]).Code;
                row.description = ((StrategyMeta)StrategyData.MetaList.Values[idx]).Name;
                tbl.AddcodeListRow(row);
            }
        }

        //Convert
        public static StrategyData.TradePoints ToTradePoints(TradePointInfo[] tradePointInfos)
        {
            StrategyData.TradePoints tradePointList = new StrategyData.TradePoints();
            for (int idx = 0; idx < tradePointInfos.Length; idx++)
            {
                tradePointList.Add(tradePointInfos[idx]);
            }
            return tradePointList;
        }
        public static TradePointInfo[] ToTradePointInfo(StrategyData.TradePoints tradePoints)
        {
            TradePointInfo[] tradePointInfos = new TradePointInfo[tradePoints.Count];
            for (int idx = 0; idx < tradePoints.Count; idx++)
            {
                tradePointInfos[idx] = (TradePointInfo)tradePoints[idx];
            }
            return tradePointInfos;
        }
    }

    public static class StrategyData
    {
        public const string constAssemplyNamePattern = "*strategy.dll";

        //Cache to boost performance
        private static common.DictionaryList dataCache = new common.DictionaryList();
        public static object FindInCache(string key)
        {
            return dataCache.Find(key);
        }
        public static void AddToCache(string key, object obj)
        {
            dataCache.Add(key, obj);
        }

        public static void Clear()
        {
            ClearCache();
            sysXmlDocument = null;
            _metaList = null;
            _myCatList = null;
        }

        /// <summary>
        /// Clear cache that keep caculated data to speed up performance.
        /// </summary>
        public static void ClearCache()
        {
            dataCache.Clear();
        }
        private static XmlDocument _sysXmlDocument = null;
        public static XmlDocument sysXmlDocument
        {
            get
            {
                if (_sysXmlDocument == null)
                {
                    _sysXmlDocument = commonClass.Configuration.GetLocalXmlDocSTRATEGY();
                    if (common.Settings.sysDebugMode)
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"STR002","Use local STRATEGY XML");
                }
                return _sysXmlDocument;
            }
            set
            {
                _sysXmlDocument = value;
            }
        }

        private static CatList _myCatList = null;
        public static CatList myCatList
        {
            get
            {
                if (_myCatList == null)
                {
                    _myCatList = new CatList();
                    StringCollection aFields = new StringCollection();
                    int count = 0;
                    while (true)
                    {
                        aFields.Clear();
                        aFields.Add("Code");
                        aFields.Add("Description");
                        if (!common.configuration.GetConfiguration(new string[] { "CATEGORY", "CAT" + count.ToString() }, aFields, StrategyData.sysXmlDocument, false)) break;
                        _myCatList.Add(new commonClass.DataCategory(aFields[0], aFields[1]));
                        count++;
                    }
                }
                return _myCatList;
            }
        }

        /// <summary>
        /// List keeps all meta data dynamically collected from strategy .DLL files
        /// </summary>
        private static common.DictionaryList _metaList = null;
        public static common.DictionaryList MetaList
        {
            get
            {
                if (_metaList == null)
                {
                    _metaList = new common.DictionaryList();
                    StrategyLibs.GetMeta(Settings.sysExecuteDirectory, constAssemplyNamePattern, _metaList);
                }
                return _metaList;
            }
        }

        //List of all possible trading points
        public class TradePoints : ArrayList
        {
            public TradePoints() { }
            public void Add(AppTypes.TradeActions action, int idx, BusinessInfo info)
            {
                this.Add(new TradePointInfo(action, idx, info));
            }
            public void Add(AppTypes.TradeActions action, int idx)
            {
                this.Add(new TradePointInfo(action, idx));
            }
        }
    }

    /// <summary>
    /// Base Strategys
    /// </summary>
    public class baseStrategy
    {
    }

    /// <summary>
    /// Base Strategy helper
    /// </summary>
    public class baseHelper
    {
        private StrategyMeta MetaData = new StrategyMeta();
        public StrategyMeta GetInfo() { return MetaData; }

        protected baseHelper(Type strategyType)
        {
            Init(strategyType, typeof(forms.baseStrategyForm));
        }
        protected baseHelper(Type strategyType, Type formType)
        {
            Init(strategyType, formType);
        }
        protected void Init(Type strategyType, Type formType)
        {
            this.MetaData.ClassType = strategyType;
            this.MetaData.FormType = formType;
            StrategyMeta.GetMeta(this.MetaData);
        }
    }
}
