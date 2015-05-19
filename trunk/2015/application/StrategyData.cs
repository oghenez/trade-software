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

namespace application
{
    [DataContract]
    public static class StrategyData
    {
        [DataMember]
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
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "STR002", "Use local STRATEGY XML");
                }
                return _sysXmlDocument;
            }
            set
            {
                _sysXmlDocument = value;
            }
        }

        private static application.Strategy.CatList _myCatList = null;
        public static application.Strategy.CatList myCatList
        {
            get
            {
                if (_myCatList == null)
                {
                    _myCatList = new application.Strategy.CatList();
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
                    application.Strategy.StrategyLibs.GetMeta(Settings.sysExecuteDirectory, constAssemplyNamePattern, _metaList);
                }
                return _metaList;
            }
        }


    }
}
