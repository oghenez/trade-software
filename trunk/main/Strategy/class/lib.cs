using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms; 
using System.IO;
using System.Data;
using System.Xml;
using System.Reflection;
using application;

namespace Strategy
{
    //Meta data keeps descriptive information of a strategy
    public class Meta
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
                retStr += (retStr == "" ? "" : common.settings.sysSeparatorList[0].ToString()) + keys[idx] + "=" + values[idx].ToString();
            }
            return retStr;
        }

        /// <summary>
        /// Get meta data from meta file
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static bool GetMeta(Meta meta)
        {
            string xmlFileName = Data.sysMetaFullFileName;
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
            common.configuration.GetConfiguration(xmlFileName, "STRATEGY", meta.ClassType.Name, aFields, false);

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

        /// <summary>
        /// Save meta data to meta file
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static bool SaveMeta(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("Type");
            aFields.Add("Name");
            aFields.Add("Code");
            aFields.Add("Description");

            aFields.Add("Category");
            aFields.Add("Parameters");
            aFields.Add("ParameterDescriptions");

            aFields.Add("URL");
            aFields.Add("Authors");
            aFields.Add("Version");

            StringCollection aValues = new StringCollection();
            aValues.Clear();
            aValues.Add(meta.Type.ToString());
            aValues.Add(meta.Name);
            aValues.Add(meta.Code);
            aValues.Add(meta.Description);

            aValues.Add(meta.Category);
            aValues.Add(meta.ParameterToString());
            aValues.Add(meta.ParameterDescriptions.ToString());

            aValues.Add(meta.URL);
            aValues.Add(meta.Authors);
            aValues.Add(meta.Version);
            common.configuration.SaveConfiguration(Data.sysMetaFullFileName, "STRATEGY", meta.ClassType.Name, aFields, aValues);
            return true;
        }

        /// <summary>
        /// Save meta's Parameters property to meta file
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static bool SaveMeta_Parameters(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("Parameters");

            StringCollection aValues = new StringCollection();
            aValues.Clear();
            aValues.Add(meta.ParameterToString());
            common.configuration.SaveConfiguration(Data.sysMetaFullFileName, "STRATEGY", meta.ClassType.Name, aFields, aValues, false);
            return true;
        }
    }
    public class Libs
    {
        public static string GetMetaName(string code)
        {
            Meta meta = Libs.FindMetaByCode(code);
            return meta.ClassType.Name;
        }

        /// <summary>
        /// Calculated primary strategy data. If an strategy has several output,one is called "primary data" 
        /// and others are calles "exatra data".
        /// </summary>
        /// <param name="myData"> Data used to calculate strategy data.</param>
        /// <param name="meta">strategy meta data</param>
        /// <returns>Null if error</returns>
        public static wsData.TradePoints Analysis(application.Data myData, Meta meta)
        {
            string cacheName = "data-" + myData.DataStockCode + "-" + meta.ClassType.Name;

            object[] processParas = new object[2];
            processParas[0] = myData;
            processParas[1] = meta.Parameters;
            //First , find in cache
            wsData.TradePoints tradePoints = (wsData.TradePoints)Data.FindInCache(cacheName);
            if (tradePoints != null) return tradePoints;

            //Then, Call Execute() method to get trading points.
            object strategyInstance = GetStrategyInstance(meta.ClassType);
            if (strategyInstance == null) return null;
            tradePoints = (wsData.TradePoints)meta.ClassType.InvokeMember("Execute",
                                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, strategyInstance, processParas);

            Data.AddToCache(cacheName, tradePoints);
            return tradePoints;
        }
        public static wsData.TradePoints Analysis(application.Data myData, string strategyCode)
        { 
            Meta meta = FindMetaByCode(strategyCode);
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
            object strategyInstance = Data.FindInCache(cacheName);
            if (strategyInstance != null) return strategyInstance;

            //Then, create it if not in cache
            strategyInstance = Activator.CreateInstance(strategyType);
            Data.AddToCache(cacheName, strategyInstance);
            return strategyInstance;
        }

        /// <summary>
        /// Get form that allow user to input parameters.
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static forms.baseStrategyForm GetStrategyForm(Meta meta)
        {
            string cacheName = "form-" + meta.ClassType.Name;
            forms.baseStrategyForm form = (forms.baseStrategyForm)Data.FindInCache(cacheName);
            if (form != null) return form;
            form = (forms.baseStrategyForm)Activator.CreateInstance(meta.FormType, meta);
            Data.AddToCache(cacheName, form);
            return form;
        }
        /// <summary>
        /// Find/Get strategy by name. Return null if not found
        /// </summary>
        /// <param name="MetaList">List keeps meta data</param>
        /// <param name="name">strategy name to find</param>
        /// <returns>Null if not found</returns>
        private static Meta FindMetaByName(common.DictionaryList MetaList, string name)
        {
            object obj = MetaList.Find(name);
            if (obj == null) return null;
            return (Meta)obj;
        }

        /// <summary>
        /// Find/Get strategy by code. Return null if not found
        /// </summary>
        /// <param name="MetaList">List keeps meta data</param>
        /// <param name="name">strategy code to find</param>
        /// <returns>Null if not found</returns>
        private static Meta FindMetaByCode(common.DictionaryList MetaList, string code)
        {
            for (int idx = 0; idx < MetaList.Values.Length; idx++)
            { 
                if ( ((Meta)MetaList.Values[idx]).Code==code) return (Meta)MetaList.Values[idx];
            }
            return null;
        }

        /// <summary>
        /// Find/Get strategy by name. Return null if not found
        /// </summary>
        /// <param name="name">strategy name to find</param>/// 
        /// <returns>Null if not found</returns>
        public static Meta FindMetaByName(string name)
        {
            return Libs.FindMetaByName(Data.MetaList, name);
        }

        /// <summary>
        /// Find/Get strategy by code. Return null if not found
        /// </summary>
        /// <param name="name">strategy code to find</param>/// 
        /// <returns>Null if not found</returns>
        public static Meta FindMetaByCode(string code)
        {
            return Libs.FindMetaByCode(Data.MetaList, code);
        }

        /// <summary>
        ///  Find/Get all strategy of the same category
        /// </summary>
        /// <param name="metasList">List keeps meta data </param>
        /// <param name="category">What category to find/get </param>
        /// <returns></returns>
        private static Meta[] FindMetaByCat(common.DictionaryList metasList,AppTypes.StrategyTypes  strategyType, string category)
        {
            Meta[] retMetas = new Meta[0];
            category = category.Trim().ToLower();
            for (int idx = 0; idx < metasList.Values.Length; idx++)
            {
                Meta meta = (Meta)metasList.Values[idx];
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
        public static Meta[] FindMetaByCat(string name, AppTypes.StrategyTypes strategyType)
        {
            return Libs.FindMetaByCat(Data.MetaList,strategyType, name);
        }

        /// <summary>
        ///Get Meta from a DDL file name 
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="MetaList"></param>
        private static void GetMeta(string assemblyFile, common.DictionaryList MetaList)
        {
            GetMeta(Assembly.LoadFile(assemblyFile), MetaList);
        }
        private static void GetMeta(Assembly strategyAss, common.DictionaryList MetaList)
        {
            Type[] mTypes = strategyAss.GetTypes();
            Meta Meta;
            string strategyHelperTypeName = typeof(baseHelper).Name;
            foreach (Type type in mTypes)
            {
                if (type.BaseType.Name != strategyHelperTypeName) continue;
                // get info about property
                Type strategyType = strategyAss.GetType(type.FullName);
                object strategyInstance = Activator.CreateInstance(strategyType);
                Meta = (Meta)strategyType.InvokeMember("GetInfo",
                                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, strategyInstance, null);
                MetaList.Add(Meta.ClassType.Name, Meta);
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
                                       data.baseDS.strategyCatDataTable strategyCatTbl,
                                       ToolStripMenuItem toMenu,System.EventHandler handler)
            
        {
            for (int idx1 = 0; idx1 < strategyCatTbl.Count; idx1++)
            {
                Meta[] tmpMetas = Libs.FindMetaByCat(Metas,strategyType,strategyCatTbl[idx1].code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                ToolStripMenuItem catMenuItem = new ToolStripMenuItem();
                catMenuItem.Name = toMenu.Name + "-group-" + strategyCatTbl[idx1].code;
                catMenuItem.Text = strategyCatTbl[idx1].description;
                toMenu.DropDownItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = toMenu.Name + "-" + tmpMetas[idx2].ClassType.Name;
                    menuItem.Tag = tmpMetas[idx2].ClassType.Name;
                    menuItem.Text = tmpMetas[idx2].Name;
                    if (handler != null) menuItem.Click += new System.EventHandler(handler);
                    catMenuItem.DropDownItems.Add(menuItem);
                }
            }
            Meta meta;
            for (int idx2 = 0; idx2 < Metas.Values.Length; idx2++)
            {
                meta = (Meta)Metas.Values[idx2];
                if (meta.Type != strategyType) continue;
                if (strategyCatTbl.FindBycode(meta.Category.Trim()) != null) continue;
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = toMenu.Name + "-group-" + meta.ClassType.Name;
                menuItem.Tag = meta.ClassType.Name;
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
            data.baseDS.strategyCatDataTable strategyCatTbl = new data.baseDS.strategyCatDataTable();
            application.dataLibs.LoadData(strategyCatTbl);
            if (toMenu!=null)
                CreateMenu(Data.MetaList, strategyType, strategyCatTbl, toMenu, handler);
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
            common.DictionaryList Metas = Strategy.Data.MetaList;

            data.baseDS.strategyCatDataTable strategyCatTbl = new data.baseDS.strategyCatDataTable();
            application.dataLibs.LoadData(strategyCatTbl);

            toObj.Items.Clear();
            for (int idx1 = 0; idx1 < strategyCatTbl.Count; idx1++)
            {
                Meta[] tmpMetas = Libs.FindMetaByCat(Metas, strategyType, strategyCatTbl[idx1].code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                toObj.Items.Add(new common.myComboBoxItem("--" + strategyCatTbl[idx1].description.Trim() + "--", ""));
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    toObj.Items.Add(new common.myComboBoxItem(tmpMetas[idx2].Name, tmpMetas[idx2].Code));
                }
            }
            //Donot have category
            Meta meta;
            bool flag = true;
            for (int idx2 = 0; idx2 < Metas.Values.Length; idx2++)
            {
                if (flag)
                {
                    toObj.Items.Add(new common.myComboBoxItem("--" + language.GetString("others") + "--", ""));
                    flag = false;
                }
                meta = (Meta)Metas.Values[idx2];
                if (meta.Type != strategyType) continue;
                if (strategyCatTbl.FindBycode(meta.Category.Trim()) != null) continue;
                toObj.Items.Add(new common.myComboBoxItem(meta.Name, meta.Code));
            }
        }

        #region strategy estimation
        /// <summary>
        /// Estimate the profit from advices produced by analysis process. 
        /// The function will produce a list of "transactions" assuming to be done from analysis advices. 
        /// </summary>
        /// <param name="data"> Data used in the analysis </param>
        /// <param name="tradePoints"> Trade point list generated by analysis process</param>
        /// <param name="options">User- specific options : captital, max Buy...</param>
        /// <param name="toTbl"> Table of assumed transactions. Each row procides detail information of a transcation and it's profit</param>
        public static void EstimateTrading(application.Data data, wsData.TradePoints tradePoints, wsData.EstimateOptions options,
                                           data.tmpDS.tradeEstimateDataTable toTbl)
        {
            decimal initCapAmt = options.TotalCapAmt * options.MaxBuyAmtPerc / 100;
            decimal priceWeight = options.PriceWeight;
            decimal feePerc = options.TransFeecPerc / 100;
            short buy2SellInterval = options.Buy2SellInterval;

            global::data.baseDS.stockCodeRow stockCodeRow = dataLibs.FindAndCache_StockCode(data.DataStockCode);
            if (stockCodeRow == null) return;

            data.tmpDS.tradeEstimateRow row;
            int adviceDataIdx, lastBuyId = -1;
            decimal stockQty = 0, qty;
            decimal maxBuyQty = (decimal)(stockCodeRow.noOutstandingStock * options.MaxBuyQtyPerc / 100);
            decimal stockAmt = 0, stockPrice = 0, amt, feeAmt, totalFeeAmt = 0;
            decimal cashAmt = initCapAmt;
            toTbl.Clear();

            DateTime tmpDate, transDate = common.Consts.constNullDate; ;
            data.baseDS.priceDataRow priceDataRow;
            bool keepInApplicableSell = true;
            for (int idx = 0; idx < tradePoints.Count; idx++)
            {
                adviceDataIdx = tradePoints.GetItem(idx).DataIdx;
                qty = 0; amt = 0;
                row = toTbl.NewtradeEstimateRow();
                row.ignored = false;
                AppTypes.TradeActions action = tradePoints.GetItem(idx).TradeAction;

                stockPrice = (decimal)data.Close[adviceDataIdx];
                transDate = DateTime.FromOADate(data.DateTime[adviceDataIdx]);
                switch (action)
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
                            lastBuyId = adviceDataIdx;
                        }
                        else row.ignored = true;
                        break;
                    case AppTypes.TradeActions.Sell:
                        //Can sell if own some stock
                        if (stockQty <= 0)
                        {
                            row.ignored = true;
                            break;
                        }
                        // Not applicable to sell
                        if (lastBuyId < 0)
                        {
                            row.ignored = true;
                            break;
                        }
                        if (common.dateTimeLibs.DateDiffInDays(DateTime.FromOADate(data.DateTime[lastBuyId]).Date,
                                                               DateTime.FromOADate(data.DateTime[adviceDataIdx]).Date) < buy2SellInterval)
                        {
                            // Keep inapplicable Sells ??
                            if (keepInApplicableSell)
                            {
                                string realTimeType = AppTypes.MainDataTimeScale.Code;
                                DateTime minAllowSellDate = DateTime.FromOADate(data.DateTime[lastBuyId]).Date.AddDays(buy2SellInterval);
                                for (int idx2 = idx + 1; idx2 < tradePoints.Count; idx2++)
                                {
                                    //There is any advice from from [this date , this date +buy2SellInterval], ignore the inapplicable sell 
                                    if (DateTime.FromOADate(data.DateTime[tradePoints.GetItem(idx2).DataIdx]).Date <= minAllowSellDate)
                                    {
                                        row.ignored = true;
                                        break;
                                    }
                                    //No advice, keep this inapplicable sell. 
                                    if (DateTime.FromOADate(data.DateTime[tradePoints.GetItem(idx2).DataIdx]).Date > minAllowSellDate)
                                    {
                                        // minAllowSellDate may be a holiday so we need to find a sell date in range [minAllowSellDate, data.DateTime[advices.GetItem(idx2).dataIdx].Date]
                                        // We assume that there are no data on hodidays and use the price,date as transaction price/date
                                        tmpDate = DateTime.FromOADate(data.DateTime[tradePoints.GetItem(idx2).DataIdx]).Date;
                                        priceDataRow = dataLibs.GetNextPrice(minAllowSellDate, realTimeType, stockCodeRow.code);
                                        //priceDataRow == null : there must be some error.
                                        if (priceDataRow == null) row.ignored = true;
                                        else
                                        {
                                            stockPrice = priceDataRow.closePrice;
                                            transDate = priceDataRow.onDate;
                                        }
                                        break;
                                    }
                                }
                            }
                            else row.ignored = true;
                        }
                        //Ok, sell it
                        if (!row.ignored)
                        {
                            qty = stockQty;
                            amt = qty * stockPrice * priceWeight;
                            stockQty = 0; stockAmt = 0;
                            feeAmt = Math.Round(amt * feePerc, 0);
                            cashAmt += amt - feeAmt;
                            totalFeeAmt += feeAmt;
                        }
                        break;
                }
                row.tradeAction = action.ToString();
                row.onDate = transDate;
                row.price = stockPrice;
                row.qty = qty;
                row.amt = amt;
                row.feeAmt = totalFeeAmt;
                row.stockQty = stockQty;
                row.stockAmt = stockAmt;
                row.cashAmt = cashAmt;
                row.totalAmt = row.cashAmt + row.stockAmt;
                row.profit = row.totalAmt - initCapAmt;
                toTbl.AddtradeEstimateRow(row);
            }
        }

        //??
        public static void ExportData(string toFileName, application.Data data, params object[] paras)
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
            text.Add("01." + language.GetString("winStockPerc"));
            text.Add("02." + language.GetString("lossStockPerc"));
            text.Add("03." + language.GetString("maxWinAmt"));
            text.Add("04." + language.GetString("maxLossAmt"));
            text.Add("05." + language.GetString("averageWinAmt"));
            text.Add("06." + language.GetString("averageLossAmt"));
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
        public static void ShowStrategyForm(Meta meta)
        {
            GetUserSettings(meta);
            Strategy.forms.baseStrategyForm form = Strategy.Libs.GetStrategyForm(meta);
            form.ShowDialog();
        }
        //Read and save setting to users's XML file
        public static void GetUserSettings(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Add("params");
            if (configuration.ReadUserSettings(sysLibs.sysLoginCode, meta.ClassType.FullName, aFields))
                meta.Parameters = common.system.String2DoubleList(aFields[0]);
        }
        public static void SaveUserSettings(Meta meta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("params");
            StringCollection aValues = new StringCollection();
            aValues.Add(common.system.ToString(meta.Parameters));
            configuration.SetUserSettings(sysLibs.sysLoginCode, meta.ClassType.FullName, aFields, aValues);
        }

        //Load strategy to table
        public static void LoadStrategy(data.tmpDS.codeListDataTable tbl, AppTypes.StrategyTypes type)
        {
            Meta meta;
            data.tmpDS.codeListRow row;
            for(int idx=0;idx<Data.MetaList.Values.Length;idx++)
            {
                meta = (Meta)Data.MetaList.Values[idx];
                if (meta.Type != type) continue;
                row = tbl.NewcodeListRow();
                row.code = ((Meta)Data.MetaList.Values[idx]).Code;
                row.description = ((Meta)Data.MetaList.Values[idx]).Name;
                tbl.AddcodeListRow(row);
            }
        }
    }

    public class Data
    {
        public const string constAssemplyNamePattern = "*strategy.dll";
        public const string constMetaFileName = "strategyInfo.xml";

        public static string sysMetaFullFileName
        {
            get
            {
                string path = common.fileFuncs.ConcatFileName(sysFileDirectory, common.language.myCulture.Name);
                return common.fileFuncs.ConcatFileName(path, constMetaFileName);
            }
        }
        public static string sysFileDirectory
        {
            get
            {
                return Application.StartupPath;
            }
        }

        //Cache to boost performance
        private static common.DictionaryList dataCache = new common.DictionaryList();
        public static object FindInCache(string key)
        {
            return dataCache.Find(key);
        }
        public static void AddToCache(string key, object obj)
        {
            dataCache.Add(key,obj);
        }

        /// <summary>
        /// Clear cache that keep caculated data to speed up performance.
        /// </summary>
        public static void ClearCache()
        {
            dataCache.Clear();
        }

        public static void Clear()
        {
            ClearCache();
            _metaList = null;
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
                    Libs.GetMeta(sysFileDirectory, constAssemplyNamePattern, _metaList);
                }
                return _metaList;
            }
        }
    }

    /// <summary>
    /// Base Strategy
    /// </summary>
    public class baseStrategy
    {
    }

    /// <summary>
    /// Base Strategy helper
    /// </summary>
    public class baseHelper
    {
        private Meta MetaData = new Meta();
        public Meta GetInfo() { return MetaData; }

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
            Meta.GetMeta(this.MetaData);
        }
    }
}
