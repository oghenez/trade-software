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
    public class Data
    {
        private static common.DictionaryList _indicatorMetas = null;
        /// <summary>
        /// List keeps all meta data dynamically collected from indicator .DLL files
        /// </summary>
        public static common.DictionaryList IndicatorMetas
        {
            get
            {
                if (_indicatorMetas == null)
                {
                    _indicatorMetas = new common.DictionaryList();
                    Libs.GetIndicatorMeta(Application.StartupPath, "Indicators.dll", _indicatorMetas);
                }
                return _indicatorMetas;
            }
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
        /// Calculated indicator data.
        /// </summary>
        /// <param name="myData"> Data used to calculate indicator data.</param>
        /// <param name="meta">Indicator meta data</param>
        /// <param name="periods">List of indicator parametters</param>
        /// <returns></returns>
        public static DataSeries GetIndicatorData(application.Data myData, Indicators.IndicatorMeta meta, int[] periods)
        {
            string cacheName = myData.DataStockCode + "-" + meta.Name;
            object[] para = new object[1];
            
            if (meta.InputDataType == typeof(DataBars))  para[0] = myData.Bars;


            else para[0] = myData.Close;
            for (int idx = 0; idx < periods.Length; idx++)
            {
                Array.Resize(ref para, para.Length + 1);
                para[para.Length - 1] = periods[idx];
                cacheName += "-" + periods[idx].ToString();
            }
            Array.Resize(ref para, para.Length + 1);
            para[para.Length - 1] = meta.Name;

            DataSeries indicatorSeries = (DataSeries)dataCache.Find(cacheName);
            if (indicatorSeries == null)
            {
                indicatorSeries = (DataSeries)Activator.CreateInstance(meta.Type, para);
                dataCache.Add(cacheName, indicatorSeries);
            }
            return indicatorSeries;
        }

        public static DataSeries[] GetIndicatorDataExtra(application.Data myData, Indicators.IndicatorMeta meta, int[] periods)
        {

            propertyInfo = indicatorForm.indicatorType.GetProperty("ExtraSeries");
            if (propertyInfo != null)
            {
                extraIndicatorInfo = indicatorForm.ExtraInfo;
                extraSeries = (DataSeries[])propertyInfo.GetValue(indicatorSeries, null);
            }
        }

        /// <summary>
        /// Get indictor form that allow user to input parameters.
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static forms.baseIndicatorForm GetIndicatorForm(IndicatorMeta meta)
        {
            return (forms.baseIndicatorForm)Activator.CreateInstance(meta.FormType, meta.Type);
        }
        /// <summary>
        /// Find/Get indicator by name. Return null if not found
        /// </summary>
        /// <param name="indicatorMetaList">List keeps meta data</param>
        /// <param name="name">Indicator name to find</param>
        /// <returns></returns>
        private static IndicatorMeta FindMetaByName(common.DictionaryList indicatorMetaList, string name)
        {
            object obj = indicatorMetaList.Find(name);
            if (obj == null) return null;
            return (IndicatorMeta)obj;
        }

        /// <summary>
        /// Find/Get indicator by name. Return null if not found
        /// </summary>
        /// <param name="name">Indicator name to find</param>/// 
        /// <returns></returns>
        public static IndicatorMeta FindMetaByName(string name)
        {
            return Libs.FindMetaByName(Data.IndicatorMetas, name);
        }

        /// <summary>
        ///  Find/Get all indicator of the same category
        /// </summary>
        /// <param name="metasList">List keeps meta data </param>
        /// <param name="category">What category to find/get </param>
        /// <returns></returns>
        private static IndicatorMeta[] FindMetaByCat(common.DictionaryList metasList, string category)
        {
            IndicatorMeta[] retMetas = new IndicatorMeta[0];
            category = category.Trim().ToLower();
            for (int idx = 0; idx < metasList.Items.Length; idx++)
            {
                IndicatorMeta meta = (IndicatorMeta)metasList.Items[idx];
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
        public static IndicatorMeta[] FindMetaByCat(string name)
        {
            return Libs.FindMetaByCat(Data.IndicatorMetas, name);
        }

        /// <summary>
        ///Get IndicatorMeta from a DDL file name 
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="indicatorMetaList"></param>
        public static void GetIndicatorMeta(string assemblyFile, common.DictionaryList indicatorMetaList)
        {
            GetIndicatorMeta(Assembly.LoadFile(assemblyFile), indicatorMetaList);
        }
        private static void GetIndicatorMeta(Assembly indicatorAss, common.DictionaryList indicatorMetaList)
        {
            Type[] mTypes = indicatorAss.GetTypes();
            IndicatorMeta indicatorMeta;
            string IndicatorHelperTypeName = typeof(IndicatorHelper).Name;
            foreach (Type type in mTypes)
            {
                if (type.BaseType.Name != IndicatorHelperTypeName) continue;
                // get info about property
                Type indicatorType = indicatorAss.GetType(type.FullName);
                object indicatorInstance = Activator.CreateInstance(indicatorType);
                indicatorMeta = (IndicatorMeta)indicatorType.InvokeMember("GetInfo",
                                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, indicatorInstance, null);
                indicatorMetaList.Add(indicatorMeta.Type.Name, indicatorMeta);
            }
            return;
        }

        /// <summary>
        /// Get IndicatorMeta from all indicator DDL in a drectory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="files"></param>
        /// <param name="indicatorMetaList"></param>
        public static void GetIndicatorMeta(string path, string files, common.DictionaryList indicatorMetaList)
        {
            string[] dllFileList = Directory.GetFiles(path, files);
            for (int idx1 = 0; idx1 < dllFileList.Length; idx1++)
            {
                GetIndicatorMeta(dllFileList[idx1], indicatorMetaList);
            }
        }


        /// <summary>
        ///  Create menu listing all indictors with click events. 
        /// - Indicators having category existed in indicatorCat table are grouped to that category
        /// - Indicators having category NOT existed in indicatorCat are placed under the category menus
        /// </summary>
        /// <param name="indicatorMetas">Meta infomation of plug-in indicators</param>
        /// <param name="toMenu">Menu where indicator menus are added</param>
        /// <param name="ShowIndicatorHandler">Function fired on Click Event</param>
        private static void CreateIndicatorMenu(common.DictionaryList indicatorMetas, ToolStripMenuItem toMenu, System.EventHandler ShowIndicatorHandler)
        {
            data.baseDS.indicatorCatDataTable indicatorCatTbl = new data.baseDS.indicatorCatDataTable();
            application.dataLibs.LoadData(indicatorCatTbl);
            for (int idx1 = 0; idx1 < indicatorCatTbl.Count; idx1++)
            {
                Indicators.IndicatorMeta[] tmpMetas = Libs.FindMetaByCat(indicatorMetas, indicatorCatTbl[idx1].code);
                if (tmpMetas == null || tmpMetas.Length == 0) continue;

                ToolStripMenuItem catMenuItem = new ToolStripMenuItem();
                catMenuItem.Name = toMenu.Name + "-group-" + indicatorCatTbl[idx1].code;
                catMenuItem.Text = indicatorCatTbl[idx1].description;
                toMenu.DropDownItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = toMenu.Name + "-" + tmpMetas[idx2].Type.Name;
                    menuItem.Tag = tmpMetas[idx2].Type.Name;
                    menuItem.Text = tmpMetas[idx2].Name;
                    menuItem.Click += new System.EventHandler(ShowIndicatorHandler);
                    catMenuItem.DropDownItems.Add(menuItem);
                }
            }
            Indicators.IndicatorMeta meta;
            for (int idx2 = 0; idx2 < indicatorMetas.Items.Length; idx2++)
            {
                meta = (Indicators.IndicatorMeta)indicatorMetas.Items[idx2];
                if (indicatorCatTbl.FindBycode(meta.Category.Trim()) != null) continue;
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = toMenu.Name + "-group-" + meta.Type.Name;
                menuItem.Tag = meta.Type.Name;
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
            CreateIndicatorMenu(Data.IndicatorMetas, toMenu, ShowIndicatorHandler);
        }
    }
}
