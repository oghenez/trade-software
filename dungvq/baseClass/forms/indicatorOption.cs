using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using application;

namespace baseClass.forms
{
    public partial class indicatorOption : common.forms.baseDialogForm  
    {
        public indicatorOption()
        {
            try
            {
                InitializeComponent();
                Init();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        public void Init()
        {
            //Make relation b/w page and indicatorType so that SetIndicatorType/GetIndicatorType can work properly 
            SMA_Pg.Tag = new StringCollection(){myTypes.indicatorType.SMA.ToString()};
            EMA_Pg.Tag = new StringCollection(){myTypes.indicatorType.EMA.ToString()};
            WMA_Pg.Tag = new StringCollection(){myTypes.indicatorType.WMA.ToString()};
            RSI_Pg.Tag = new StringCollection(){myTypes.indicatorType.RSI.ToString()};
            MACD_Pg.Tag = new StringCollection(){myTypes.indicatorType.MACD.ToString()};
            
            stochasticF_Pg.Tag = new StringCollection() { myTypes.indicatorType.StochF.ToString() };
            stochasticS_Pg.Tag = new StringCollection() { myTypes.indicatorType.StochS.ToString() };
            stockRSI_Pg.Tag = new StringCollection() { myTypes.indicatorType.StockRSI.ToString() };
            BBANDS_Pg.Tag = new StringCollection() { myTypes.indicatorType.BBANDS.ToString() };

            DI_Pg.Tag = new StringCollection() { myTypes.indicatorType.DI.ToString(), myTypes.indicatorType.DIMinus.ToString(), myTypes.indicatorType.DIPlus.ToString() };
            DM_Pg.Tag = new StringCollection() { myTypes.indicatorType.DMMinus.ToString(), myTypes.indicatorType.DMPlus.ToString() };


            //Load and assig colors
            smaColorEd1.LoadColors(); smaColorEd2.LoadColors();
            emaColorEd1.LoadColors(); emaColorEd2.LoadColors();
            wmaColorEd1.LoadColors(); wmaColorEd2.LoadColors();
            rsiColorEd1.LoadColors(); rsiColorEd2.LoadColors();

            diColorEd.LoadColors(); plusDiColorEd.LoadColors(); minusDiColorEd.LoadColors();
            plusDmColorEd.LoadColors(); minusDmColorEd.LoadColors();

            macdColorEd.LoadColors(); macdSignalColorEd.LoadColors();

            stochfKColorEd.LoadColors(); stochfDColorEd.LoadColors();
            stochsKColorEd.LoadColors(); stochsDColorEd.LoadColors();

            stockRsiKColorEd.LoadColors(); stockRsiDColorEd.LoadColors();

            bbandMiddleColorEd.LoadColors(); bbandLowerColorEd.LoadColors(); bbandUpperColorEd.LoadColors();
        }

        public enum formActions : byte { None=0, Draw = 1, Remove = 2, Close=3};

        public virtual formActions GetFormActions(object sender)
        {
            Button senderBtn = (Button)sender;
            if (senderBtn == removeBtn) return formActions.Remove;
            if (senderBtn ==okBtn) return formActions.Draw;
            if (senderBtn == closeBtn) return formActions.Close;
            return formActions.None;
        }

        public void SetIndicatorType(myTypes.indicatorType type)
        {
            string typeName = type.ToString();
            for (int idx = 0; idx < indicatorTab.TabCount; idx++)
            {
                if (indicatorTab.TabPages[idx].Tag == null) continue;
                if (((StringCollection)indicatorTab.TabPages[idx].Tag).Contains(typeName))
                {
                    indicatorTab.SelectedIndex = idx; break;
                }
            }
        }
        public myTypes.indicatorType[] GetIndicatorType()
        {
            if (indicatorTab.TabIndex < 0) return new myTypes.indicatorType[]{myTypes.indicatorType.None};
            myTypes.indicatorType[] typeList = new myTypes.indicatorType[0];
            foreach (string item in (StringCollection)indicatorTab.TabPages[indicatorTab.SelectedIndex].Tag)
            {
                Array.Resize(ref typeList,typeList.Length + 1);
                typeList[typeList.Length - 1] = myTypes.GetIndictorType(item);
            }
            return typeList;
        }

        public byte smaVal1
        {
            get { return (byte)smaValEd1.Value; }
            set { smaValEd1.Value = value; }
        }
        public byte smaVal2
        {
            get { return (byte)smaValEd2.Value; }
            set { smaValEd2.Value = value; }
        }
        public Color smaColor1
        {
            get { return smaColorEd1.Color; }
            set { smaColorEd1.Color = value; }
        }
        public Color smaColor2
        {
            get { return smaColorEd2.Color; }
            set { smaColorEd2.Color = value; }
        }

        public byte emaVal1
        {
            get { return (byte)emaValEd1.Value; }
            set { emaValEd1.Value = value; }
        }
        public byte emaVal2
        {
            get { return (byte)emaValEd2.Value; }
            set { emaValEd2.Value = value; }
        }
        public Color emaColor1
        {
            get { return emaColorEd1.Color; }
            set { emaColorEd1.Color = value; }
        }
        public Color emaColor2
        {
            get { return emaColorEd2.Color; }
            set { emaColorEd2.Color = value; }
        }

        public byte wmaVal1
        {
            get { return (byte)wmaValEd1.Value; }
            set { wmaValEd1.Value = value; }
        }
        public byte wmaVal2
        {
            get { return (byte)wmaValEd2.Value; }
            set { wmaValEd2.Value = value; }
        }
        public Color wmaColor1
        {
            get { return wmaColorEd1.Color; }
            set { wmaColorEd1.Color = value; }
        }
        public Color wmaColor2
        {
            get { return wmaColorEd2.Color; }
            set { wmaColorEd2.Color = value; }
        }

        public byte rsiVal1
        {
            get { return (byte)rsiValEd1.Value; }
            set { rsiValEd1.Value = value; }
        }
        public byte rsiVal2
        {
            get { return (byte)rsiValEd2.Value; }
            set { rsiValEd2.Value = value; }
        }
        public Color rsiColor1
        {
            get { return rsiColorEd1.Color; }
            set { rsiColorEd1.Color = value; }
        }
        public Color rsiColor2
        {
            get { return rsiColorEd2.Color; }
            set { rsiColorEd2.Color = value; }
        }

        public byte macdValSlow
        {
            get { return (byte)macdValSlowEd.Value; }
            set { macdValSlowEd.Value = value; }
        }
        public byte macdValFast
        {
            get { return (byte)macdValFastEd.Value; }
            set { macdValFastEd.Value = value; }
        }
        public byte macdValSignal
        {
            get { return (byte)macdValSignalEd.Value; }
            set { macdValSignalEd.Value = value; }
        }
        public Color macdColor1
        {
            get { return macdColorEd.Color; }
            set { macdColorEd.Color = value; }
        }
        public Color macdColor2
        {
            get { return macdSignalColorEd.Color; }
            set { macdSignalColorEd.Color = value; }
        }

        public byte diVal
        {
            get { return (byte)diValEd.Value; }
            set { diValEd.Value = value; }
        }
        public byte diPlusVal
        {
            get { return (byte)plusDiValEd.Value; }
            set { plusDiValEd.Value = value; }
        }
        public byte diMinusVal
        {
            get { return (byte)minusDiValEd.Value; }
            set { minusDiValEd.Value = value; }
        }
        public Color diColor
        {
            get { return diColorEd.Color; }
            set { diColorEd.Color = value; }
        }
        public Color diPlusColor
        {
            get { return plusDiColorEd.Color; }
            set { plusDiColorEd.Color = value; }
        }
        public Color diMinusColor
        {
            get { return minusDiColorEd.Color; }
            set { minusDiColorEd.Color = value; }
        }

        public byte dmPlusVal
        {
            get { return (byte)plusDmValEd.Value; }
            set { plusDmValEd.Value = value; }
        }
        public byte dmMinusVal
        {
            get { return (byte)minusDmValEd.Value; }
            set { minusDmValEd.Value = value; }
        }
        public Color dmPlusColor
        {
            get { return plusDmColorEd.Color; }
            set { plusDmColorEd.Color = value; }
        }
        public Color dmMinusColor
        {
            get { return minusDmColorEd.Color; }
            set { minusDmColorEd.Color = value; }
        }

        public byte stochfKVal
        {
            get { return (byte)stochfKValEd.Value; }
            set { stochfKValEd.Value = value; }
        }
        public byte stochfDVal
        {
            get { return (byte)stochfDValEd.Value; }
            set { stochfDValEd.Value = value; }
        }
        public Color stochfKColor
        {
            get { return stochfKColorEd.Color; }
            set { stochfKColorEd.Color = value; }
        }
        public Color stochfDColor
        {
            get { return stochfDColorEd.Color; }
            set { stochfDColorEd.Color = value; }
        }

        public byte stochsKVal1
        {
            get { return (byte)stochsKValEd1.Value; }
            set { stochsKValEd1.Value = value; }
        }
        public byte stochsKVal2
        {
            get { return (byte)stochsKValEd2.Value; }
            set { stochsKValEd2.Value = value; }
        }
        public byte stochsDVal
        {
            get { return (byte)stochsDValEd.Value; }
            set { stochsDValEd.Value = value; }
        }
        public Color stochsKColor
        {
            get { return stochsKColorEd.Color; }
            set { stochsKColorEd.Color = value; }
        }
        public Color stochsDColor
        {
            get { return stochsDColorEd.Color; }
            set { stochsDColorEd.Color = value; }
        }

        public byte stockRsiPeriod
        {
            get { return (byte)stockRsiPeriodEd.Value; }
            set { stockRsiPeriodEd.Value = value; }
        }
        public byte stockRsiKVal1
        {
            get { return (byte)stockRsiKValEd1.Value; }
            set { stockRsiKValEd1.Value = value; }
        }
        public byte stockRsiKVal2
        {
            get { return (byte)stockRsiKValEd2.Value; }
            set { stockRsiKValEd2.Value = value; }
        }
        public byte stockRsiDVal
        {
            get { return (byte)stockRsiDValEd.Value; }
            set { stockRsiDValEd.Value = value; }
        }
        public Color stockRsiKColor
        {
            get { return stockRsiKColorEd.Color; }
            set { stockRsiKColorEd.Color = value; }
        }
        public Color stockRsiDColor
        {
            get { return stockRsiDColorEd.Color; }
            set { stockRsiDColorEd.Color = value; }
        }

        public byte bbandsPeriod
        {
            get { return (byte)bbandPeriodEd.Value; }
            set { bbandPeriodEd.Value = value; }
        }
        public byte bbandsUpVal
        {
            get { return (byte)bbandUpValEd.Value; }
            set { bbandUpValEd.Value = value; }
        }
        public byte bbandsDownVal
        {
            get { return (byte)bbandDownValEd.Value; }
            set { bbandDownValEd.Value = value; }
        }
        public Color bbandsUpperColor
        {
            get { return bbandUpperColorEd.Color; }
            set { bbandUpperColorEd.Color = value; }
        }
        public Color bbandsLowerColor
        {
            get { return bbandLowerColorEd.Color; }
            set { bbandLowerColorEd.Color = value; }
        }
        public Color bbandsMiddleColor
        {
            get { return bbandMiddleColorEd.Color; }
            set { bbandMiddleColorEd.Color = value; }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //this.okBtnSelected = true;
                //DoProcess(sender);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }    
}