using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    public class Consts
    {
        public const string constIndicatorMetaFile = "indicators.xml";
    }

    public class IndicatorMeta
    {
        public string Category = "";
        public Type FormType = null;
        public Type Type = null;
        public Type InputDataType = typeof(DataSeries);

        /// <summary>
        /// Suggested default values
        /// </summary>
        public IList<object> ParameterDefaultValues = null;

        /// <summary>
        /// Parameter descriptions
        /// </summary>
        public IList<string> ParameterDescriptions = null;

        /// <summary>
        /// Name of the indicator
        /// </summary>
        public string Name = "";
        /// <summary>
        /// Description of the indicator
        /// </summary>
        public string Description = "";

        /// <summary>
        /// URL for more info
        /// </summary>
        public string URL = "";

        /// <summary>
        /// Author
        /// </summary>
        public string Authors = "";
        /// <summary>
        /// Version
        /// </summary>
        public string Version = "";
    }

    public class IndicatorHelper
    {
        private IndicatorMeta MetaData = new IndicatorMeta();
        public IndicatorMeta GetInfo() { return MetaData; }

        protected void Init(Type indicatorType, Type indicatorFormType, string xmlFileName)
        {
            Init(indicatorType, indicatorFormType, xmlFileName, indicatorType.Name, typeof(DataSeries));
        }
        protected void Init(Type indicatorType, Type indicatorFormType, string xmlFileName, Type inputDataType)
        {
            Init(indicatorType, indicatorFormType, xmlFileName, indicatorType.Name, inputDataType);
        }
        protected void Init(Type indicatorType, Type indicatorFormType, string xmlFileName, string typeName, Type inputDataType)
        {
            MetaData.Type = indicatorType;
            MetaData.InputDataType = inputDataType;
            MetaData.FormType = indicatorFormType;
            GetIndicatorMeta(xmlFileName, typeName, MetaData);
        }

        public static bool GetIndicatorMeta(string xmlFileName, string subName, IndicatorMeta indicatorMeta)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add("Category");
            aFields.Add("ParameterDefaultValues");
            aFields.Add("ParameterDescriptions");
            aFields.Add("Name");
            aFields.Add("Description");
            aFields.Add("URL");
            aFields.Add("Authors");
            aFields.Add("Version");
            common.configuration.GetConfiguration(xmlFileName, "INDICATORS", subName, aFields, false);
            indicatorMeta.Category = aFields[0];
            indicatorMeta.ParameterDefaultValues = common.system.String2List(aFields[1]);
            indicatorMeta.ParameterDescriptions = common.system.String2List(aFields[2]);
            indicatorMeta.Name = aFields[3];
            indicatorMeta.Description = aFields[4];
            indicatorMeta.URL = aFields[5];
            indicatorMeta.Authors = aFields[6];
            indicatorMeta.Version = aFields[7];
            return true;
        }
    }

    #region Indicator helper

    /// <summary>
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class SMAHelper : IndicatorHelper
    {
        public SMAHelper()
        {
            Init(typeof(SMA), typeof(forms.SMA), Consts.constIndicatorMetaFile);
        }
    }
    public class EMAHelper : IndicatorHelper
    {
        public EMAHelper()
        {
            Init(typeof(EMA), typeof(forms.SMA), Consts.constIndicatorMetaFile);
        }
    }
    public class WMAHelper : IndicatorHelper
    {
        public WMAHelper()
        {
            Init(typeof(WMA), typeof(forms.SMA), Consts.constIndicatorMetaFile);
        }
    }
    public class RSIHelper : IndicatorHelper
    {
        public RSIHelper()
        {
            Init(typeof(RSI), typeof(forms.RSI), Consts.constIndicatorMetaFile);
        }
    }
    public class MACDHelper : IndicatorHelper
    {
        public MACDHelper()
        {
            Init(typeof(MACD), typeof(forms.MACD), Consts.constIndicatorMetaFile);
        }
    }

    public class ADXHelper : IndicatorHelper
    {
        public ADXHelper()
        {
            Init(typeof(ADX), typeof(forms.DMI), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }
    public class PlusDIHelper : IndicatorHelper
    {
        public PlusDIHelper()
        {
            Init(typeof(PlusDI), typeof(forms.DMI), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }
    public class MinusDIHelper : IndicatorHelper
    {
        public MinusDIHelper()
        {
            Init(typeof(MinusDI), typeof(forms.DMI), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }
    public class PlusDMHelper : IndicatorHelper
    {
        public PlusDMHelper()
        {
            Init(typeof(PlusDM), typeof(forms.DMI), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }
    public class MinusDMHelper : IndicatorHelper
    {
        public MinusDMHelper()
        {
            Init(typeof(MinusDM), typeof(forms.DMI), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }

    public class BBANDSIHelper : IndicatorHelper
    {
        public BBANDSIHelper()
        {
            Init(typeof(BBANDS), typeof(forms.BBANDS), Consts.constIndicatorMetaFile);
        }
    }

    public class StochHelper : IndicatorHelper
    {
        public StochHelper()
        {
            Init(typeof(Stoch), typeof(forms.Stoch), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }

    public class StochFHelper : IndicatorHelper
    {
        public StochFHelper()
        {
            Init(typeof(StochF), typeof(forms.StochFast), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }

    public class StochRSIHelper : IndicatorHelper
    {
        public StochRSIHelper()
        {
            Init(typeof(StochRSI), typeof(forms.StochRSI), Consts.constIndicatorMetaFile);
        }
    }
   
    #endregion
}
