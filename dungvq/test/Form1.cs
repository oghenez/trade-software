using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using application;
using Indicators;


namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;

            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            DateTime toDate = DateTime.Today;
            DateTime frDate = toDate.AddYears(-3);
            dataLibs.LoadData(priceTbl, myTypes.timeScales.Daily, frDate, toDate, "SSI");

            Data myData = new Data(priceTbl);
            SMA sma = new SMA(myData.Close, 5, "SMA");
            EMA ema = new EMA(myData.Close, 5, "EMA");
            MACD macd = new MACD(myData.Close, 12, 26, 9, "MACD");
            //DataSeries[] macdAddSeries = macd.ExtraSeries;
            test();
        }

        private void test()
        {
            //IndicatorMeta indicatorMeta = new IndicatorMeta();
            //IndicatorHelper.GetIndicatorMeta("indicators.xml", "SMA", indicatorMeta);
            //Indicators.libs.GetIndicatorMeta();
        }
        private void runSMA(DataSeries hiSeries)
        {
            // dynamically load assembly from file .dll
            Assembly indicatorAssembly = Assembly.LoadFile(@"D:\work\stockProject\code\dlls\test.Indicators.dll");
            IndicatorMeta[] indicatorMetas = Indicators.libs.GetIndicatorMeta(indicatorAssembly);
            //Indicators.SMA sma = new SMA();
            //sma.ExtraSeries;

            for (int idx = 0; idx < indicatorMetas.Length; idx++)
            {
                Type mType = indicatorAssembly.GetType(indicatorMetas[idx].Type.FullName);
                object[] paras = null;
                if (mType.Name.Contains("SMA"))
                    paras = new object[] { hiSeries, (byte)1, 5, mType.Name };
                if (mType.Name.Contains("MACD"))
                    paras = new object[] { hiSeries, 12, 26, mType.Name };
                object obj2 = Activator.CreateInstance(mType, paras);
            }
        }
        
    }
}
