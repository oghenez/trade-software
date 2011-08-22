using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using application;

namespace Indicators
{
    //Ready-to-use data 
    public class Data
    {
        public Data(global::data.baseDS.priceDataDataTable tbl)
        {
            this.priceDataTbl = tbl;
            Clear();
        }
        private global::data.baseDS.priceDataDataTable priceDataTbl = null;
        public myTypes.timeScales DataTimeScale = myTypes.timeScales.Daily;
        public DateTime DataStartDate = common.Consts.constNullDate;
        public DateTime DataEndDate = common.Consts.constNullDate;
        public string DataStockCode = "";
        public void Reload()
        {
            priceDataTbl.Clear();
            application.dataLibs.LoadData(this.priceDataTbl, this.DataTimeScale,
                                          this.DataStartDate, this.DataEndDate, this.DataStockCode);
            Clear();
        }

        private DataCache dataCache = new DataCache();
        private void Clear()
        {
            this.dataCache.Clear();
            //this._dateTime = null;
            //this._bars = null;
        }
        public DataSeries DateTime
        {
            get
            {
                object obj = dataCache.Find("DateTime");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.DateTime);
                dataCache.Add("DateTime",series);
                return series; 
            }
        }
        public DataSeries Close
        {
            get
            {
                object obj = dataCache.Find("Close");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.Close);
                dataCache.Add("Close", series);
                return series;
            }
        }
        public DataSeries High
        {
            get
            {
                object obj = dataCache.Find("High");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.High);
                dataCache.Add("High", series);
                return series;
            }
        }
        public DataSeries Low
        {
            get
            {
                object obj = dataCache.Find("Low");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.Low);
                dataCache.Add("Low", series);
                return series;
            }
        }
        public DataSeries Open
        {
            get
            {
                object obj = dataCache.Find("Open");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.Open);
                dataCache.Add("Open", series);
                return series;
            }
        }
        public DataSeries Volume
        {
            get
            {
                object obj = dataCache.Find("Volume");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = libs.GetData(this.priceDataTbl, 0, libs.DataType.Volume);
                dataCache.Add("Volume", series);
                return series;
            }
        }
        public DataBars Bars
        {
            get
            {
                object obj = dataCache.Find("Bars");
                if (obj != null) return (DataBars)obj;
                DataBars db = libs.GetData(this.priceDataTbl, 0);
                dataCache.Add("Bars", db);
                return db;
            }
        }
    }
    public class libs
    {
        public enum DataType : byte { High, Low, Open, Close, Volume, DateTime };
        public static DataSeries GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx, DataType type)
        {
            DataSeries ds = new DataSeries();
            switch (type)
            {
                case DataType.High:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].highPrice);
                    break;
                case DataType.Low:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].lowPrice);
                    break;
                case DataType.Open:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].openPrice);
                    break;
                case DataType.Close:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].closePrice);
                    break;
                case DataType.Volume:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].volume);
                    break;

                case DataType.DateTime:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add(dataTbl[i].onDate.ToOADate());
                    break;
                default:
                    common.system.ThrowException("Invalid dataField in MakeDataList()"); break;
            }
            return ds;
        }
        public static DataBars GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx)
        {
            DataBars bars = new DataBars();
            for (int idx = startIdx; idx < dataTbl.Count; idx++)
            {
                bars.Add((double)dataTbl[idx].openPrice, (double)dataTbl[idx].highPrice,
                         (double)dataTbl[idx].lowPrice, (double)dataTbl[idx].closePrice, (double)dataTbl[idx].volume);
            }
            return bars;
        }

        public static IndicatorMeta[] FindMetaByCat(IndicatorMeta[] metas, string category)
        {
            IndicatorMeta[] retMetas = new IndicatorMeta[0];
            category = category.Trim().ToLower();
            for (int idx = 0; idx < metas.Length; idx++)
            {
                if (metas[idx].Category.Trim().ToLower() != category) continue;
                Array.Resize(ref retMetas, retMetas.Length + 1);
                retMetas[retMetas.Length - 1] = metas[idx];
            }
            return retMetas;
        }
        public static IndicatorMeta FindMetaByName(IndicatorMeta[] metas, string name)
        {
            name = name.Trim().ToLower();
            for (int idx = 0; idx < metas.Length; idx++)
            {
                if (metas[idx].Type.Name.Trim().ToLower() == name) return metas[idx];
            }
            return null;
        }

        //Get IndicatorMeta from a DDL file name
        public static IndicatorMeta[] GetIndicatorMeta(string assemblyFile)
        {
            return GetIndicatorMeta(Assembly.LoadFile(assemblyFile));
        }
        public static IndicatorMeta[] GetIndicatorMeta(Assembly indicatorAss)
        {
            IndicatorMeta[] indicatorMetas = new IndicatorMeta[0];
            Type[] mTypes = indicatorAss.GetTypes();
            IndicatorMeta indicatorMeta;
            string IndicatorHelperTypeName = typeof(IndicatorHelper).Name; 
            foreach (Type type in mTypes)
            {
                if (type.BaseType.Name != IndicatorHelperTypeName) continue;
                Array.Resize(ref indicatorMetas, indicatorMetas.Length + 1);

                // get info about property: public double Number
                Type indicatorType = indicatorAss.GetType(type.FullName);
                //PropertyInfo propertyInfo = indicatorType.GetProperty("Description");

                //Type mType2 = indicatorAss.GetType(type.FullName);
                object indicatorInstance = Activator.CreateInstance(indicatorType);
                indicatorMeta = (IndicatorMeta)indicatorType.InvokeMember("GetInfo",
                                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, indicatorInstance, null);
                indicatorMetas[indicatorMetas.Length - 1] = indicatorMeta;
            }
            return indicatorMetas;
        }

        //Get IndicatorMeta from all indicator DDL in a drectory
        public static IndicatorMeta[] GetIndicatorMeta(string path,string files )
        {
            IndicatorMeta[] indicatorMetas = new IndicatorMeta[0];
            string[] dllFileList = Directory.GetFiles(path, files);
            for (int idx1 = 0; idx1 < dllFileList.Length; idx1++)
            {
                IndicatorMeta[] tmpList = libs.GetIndicatorMeta(dllFileList[idx1]);
                if (tmpList.Length == 0) continue;
                Array.Resize(ref indicatorMetas, indicatorMetas.Length + tmpList.Length);
                for (int idx2 = 0, idx3 = indicatorMetas.Length - tmpList.Length; idx2 < tmpList.Length; idx2++, idx3++)
                {
                    indicatorMetas[idx3] = tmpList[idx2];
                }
            }
            return indicatorMetas;
        }
        public static IndicatorMeta[] GetIndicatorMeta()
        {
            return Indicators.libs.GetIndicatorMeta(Application.StartupPath, "Indicators.dll");
        }
    }
}
