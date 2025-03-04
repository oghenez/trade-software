using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using application;
using commonTypes;
using commonClass;

namespace baseClass.controls
{
    public class formContainer : common.controls.baseContainer
    {
        public override void ArrangeChildren()
        {
            switch(this.myArrangeOptions)
            {
                case common.controls.childArrangeOptions.Casscade: Arrange_Casscade(); break;
                case common.controls.childArrangeOptions.Tiled: Arrange_Tiled(); break;
            }
        }

        private void Arrange_Tiled()
        {
            if (this.ChildCount <= 0) return;
            Form myForm;
            int noFormInCol = (int)Math.Round(Math.Sqrt(this.ChildCount),0);
            int noFormInRow = noFormInCol;
            if (noFormInRow * noFormInCol < this.ChildCount) noFormInRow++;
            int width = this.Size.Width + 4;
            int height = this.Size.Height + SystemInformation.BorderSize.Height;
            Size formSize = new Size((int)width/noFormInCol, (int)height / noFormInRow);
            Point startLocation = this.Location;

            int colCount = 0,rowCount = 0;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                if (colCount == noFormInCol)
                {
                    colCount = 0; rowCount++;
                }
                width = formSize.Width + 4;
                height = formSize.Height + SystemInformation.BorderSize.Height;
                startLocation = new Point(Location.X + colCount * width,Location.Y + rowCount*height);
                myForm = (Form)this.GetChild(idx);
                myForm.Location = startLocation;
                myForm.Size = formSize;
                colCount++;
            }
        }
        private void Arrange_Casscade()
        {
            if (this.ChildCount <= 0) return;
            Form myForm;
            Size formSize = ((Form)this.GetChild(0)).Size;
            Point startLocation = this.Location;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myForm = (Form)this.GetChild(idx);
                myForm.Location = startLocation;
                myForm.Size = formSize;
                startLocation = new Point(startLocation.X + SystemInformation.CaptionHeight, startLocation.Y + SystemInformation.CaptionHeight);
            }
        }

    }
    public class graphPaneContainer : common.controls.baseContainer
    {
        public override void ArrangeChildren()
        {
            if (this.ChildCount <= 0) return;
            graphPanel myPane;
            int totalWeight = 0, totalHeight = this.ClientRectangle.Height-1;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myPane = (graphPanel)this.GetChild(idx);
                if (!myPane.Visible) continue;
                if (myPane.myWeight <= 0)
                {
                    totalHeight -= myPane.Height;
                    continue;
                }
                totalWeight += myPane.myWeight;
            }
            int startY = 0;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myPane = (graphPanel)this.GetChild(idx);
                if (!myPane.Visible) continue;
                //Dont size panes having myWeight<=0
                if (myPane.myWeight > 0)
                {
                    myPane.Size = new Size(this.Width, totalHeight * (myPane.myWeight / totalWeight) - 1);
                }
                else myPane.Size = new Size(this.Width, myPane.Height);

                myPane.Location = new Point(0, startY);
                startY += myPane.Height + 1;
            }
        }
    }
    public class graphPanel : Charts.Controls.baseGraphPanel
    {
        private bool fResizing = false;
        public graphPaneContainer myContainer = null;
        protected override void OnResize(EventArgs eventargs)
        {
            try
            {
                if (fResizing) return;
                fResizing = true;
                base.OnResize(eventargs);
                if (myContainer != null) myContainer.ArrangeChildren();
                fResizing = false;
            }
            catch (Exception er)
            {
                fResizing = false;
                common.system.ThrowException(er);
            }
        }
    }

    #region multi-value object
    public class baseCheckedLB : common.controls.baseCheckedListBox
    {
        public baseCheckedLB() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    public class baseListBox : common.controls.baseListBox
    {
        public baseListBox() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    #endregion 

    #region toolstrip
    public class ToolStripCbTimeRange : ToolStripComboBox
    {
        public ToolStripCbTimeRange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void SetLanguage()
        {
            int saveIdx = this.SelectedIndex;
            language.SetLanguage(this.Items, typeof(AppTypes.TimeRanges));
            if (saveIdx >= 0) this.SelectedIndex = saveIdx;
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for (int idx = 0; idx < ranges.Length; idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            this.myValue = Settings.sysGlobal.DefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }
        public void LoadDataWithout(AppTypes.TimeRanges[] excludeList)
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                bool fAccept = true;
                for (int idx = 0; idx < excludeList.Length; idx++)
                {
                    if (excludeList[idx] == item)
                    {
                        fAccept = false;
                        break;
                    }
                }
                if (fAccept) this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.myValue = Settings.sysGlobal.DefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }

        public void LoadData()
        {
            LoadDataWithout(new AppTypes.TimeRanges[] { AppTypes.TimeRanges.None });
        }

        public AppTypes.TimeRanges myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TimeRanges.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TimeRanges.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.TimeRanges.None;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class ToolStripCbStrategy : ToolStripComboBox
    {
        public ToolStripCbStrategy()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private AppTypes.StrategyTypes myDataType = AppTypes.StrategyTypes.Strategy; 
        public void SetLanguage()
        {
            LoadData(myDataType);
        }
        public void LoadData()
        {
            LoadData(AppTypes.StrategyTypes.Strategy);
        }
        public void LoadData(AppTypes.StrategyTypes type)
        {
            application.Strategy.StrategyLibs.LoadStrategy(type, this);  
            if (this.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.MaxDropDownItems = this.Items.Count;
            }
            this.myDataType = type;
        }

        public string myValue
        {
            get
            {
                if (this.SelectedItem == null) return "";
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                return selectedItem.Value;
            }
            set
            {
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value == value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public string SelectedValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
            }
        }
    }

    #endregion

    #region comboBox
    public class cbUserTypes : common.controls.baseComboBox
    {
        public cbUserTypes()
        {
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.UserTypes item in Enum.GetValues(typeof(AppTypes.UserTypes)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.SelectedIndex = 0;
        }
        public new AppTypes.UserTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.UserTypes.Investor;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.UserTypes item in Enum.GetValues(typeof(AppTypes.UserTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.UserTypes.Investor;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get { return (byte)myValue; }
            set 
            {
                this.myValue = AppTypes.UserTypes.Investor;
                foreach (AppTypes.UserTypes item in Enum.GetValues(typeof(AppTypes.UserTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
        public override void SetLanguage()
        {
            LoadData();
        }
    }
    public class cbFeedbackCat : common.controls.baseComboBox
    {
        public cbFeedbackCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.feedbackCatDataTable tbl = DataAccess.Libs.GetFeedbackCat(common.language.myCulture.Name);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public databases.baseDS.sysCodeCatRow GetRow(string code)
        {
            return ((databases.baseDS.sysCodeCatDataTable)this.DataSource).FindBycategory(code);
        }
    }

    public class cbPriceDataTypes : common.controls.baseComboBox
    {
        public cbPriceDataTypes()
        {
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.PriceDataType item in Enum.GetValues(typeof(AppTypes.PriceDataType)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.SelectedIndex = 0;
        }
        public new AppTypes.PriceDataType myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.PriceDataType.Close;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.PriceDataType item in Enum.GetValues(typeof(AppTypes.PriceDataType)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.PriceDataType.Close;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new AppTypes.PriceDataType SelectedValue
        {
            get { return myValue; }
            set { myValue = value; }
        }
    }
    public class cbSyslogTypes : common.controls.baseComboBox
    {
        public cbSyslogTypes()
        {
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.SyslogTypes item in Enum.GetValues(typeof(AppTypes.SyslogTypes)))
            {
                this.Items.Add(new common.myComboItemBYTE(AppTypes.Type2Text(item), (byte)item));
            }
            this.SelectedIndex = 0;
        }
        public new AppTypes.SyslogTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.SyslogTypes.Others;
                common.myComboItemBYTE selectedItem = (common.myComboItemBYTE)this.SelectedItem;
                foreach (AppTypes.SyslogTypes item in Enum.GetValues(typeof(AppTypes.SyslogTypes)))
                {
                    if ((byte)item == selectedItem.Value) return item;
                }
                return AppTypes.SyslogTypes.Others;
            }
            set
            {
                common.myComboItemBYTE item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboItemBYTE)this.Items[idx];
                    if (item.Value == (byte)value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get { return (byte)myValue; }
            set { myValue = (AppTypes.SyslogTypes)value; }
        }
        
    }
    public class cbSyslogMedia : common.controls.baseComboBox
    {
        public cbSyslogMedia()
        {
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.SyslogMedia item in Enum.GetValues(typeof(AppTypes.SyslogMedia)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.SelectedIndex = 0;
        }
        public new AppTypes.SyslogMedia myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.SyslogMedia.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.SyslogMedia item in Enum.GetValues(typeof(AppTypes.SyslogMedia)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.SyslogMedia.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new AppTypes.SyslogMedia SelectedValue
        {
            get { return myValue; }
            set { myValue = value; }
        }
    }

    public class cbStockSelection : common.controls.baseComboBox
    {
        public cbStockSelection()
        {
        }
        public enum Options : byte { None, All, StockExchange, WatchList, SysWatchList,  Sectors , UserPorfolio };
        private object lastOptions = null;
        public override void SetLanguage()
        {
            int saveSelectedIdx = this.SelectedIndex;
            if (lastOptions == null) return;
            LoadData((Options[])lastOptions);
            if (saveSelectedIdx >= 0) this.SelectedIndex = saveSelectedIdx;
        }

        public override void LoadData() 
        {
            LoadData(new Options[] { Options.All, Options.StockExchange, Options.WatchList, Options.SysWatchList ,Options.UserPorfolio}); 
        }
        public void LoadData(Options[] options)
        {
            common.myKeyValueExt item;
            this.Items.Clear();
            if (InList(options, Options.All))
            {
                item = new common.myKeyValueExt(Settings.sysString_All_Description, Settings.sysString_All_Code);
                item.Attribute1 = ((byte)Options.All).ToString();
                this.Items.Add(item);
            }

            //stockExchange
            if (InList(options, Options.StockExchange))
            {
                databases.baseDS.stockExchangeDataTable stockExchangeTbl = DataAccess.Libs.myStockExchangeTbl;
                for (int idx = 0; idx < stockExchangeTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(stockExchangeTbl[idx].code, stockExchangeTbl[idx].code);
                    item.Attribute1 = ((byte)Options.StockExchange).ToString();
                    this.Items.Add(item);
                }
            }
            //System Watch List
            databases.baseDS.portfolioDataTable portfolioTbl;
            if (InList(options, Options.SysWatchList))
            {
                portfolioTbl = DataAccess.Libs.GetSystemWatchList();
                if (portfolioTbl.Count > 0)
                {
                    item = new common.myKeyValueExt("--" + Languages.Libs.GetString("system") + "--", "");
                    item.Attribute1 = ((byte)Options.SysWatchList).ToString();
                    this.Items.Add(item);
                }
                for (int idx = 0; idx < portfolioTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                    item.Attribute1 = ((byte)Options.SysWatchList).ToString();
                    this.Items.Add(item);
                }
            }
            //User watch list
            if (InList(options, Options.WatchList))
            {
                portfolioTbl = DataAccess.Libs.GetPortfolio_ByInvestorAndType(commonClass.SysLibs.sysLoginCode, AppTypes.PortfolioTypes.WatchList);
                if (portfolioTbl.Count > 0)
                {
                    item = new common.myKeyValueExt("--" + Languages.Libs.GetString("watchList") + "--","");
                    item.Attribute1 = ((byte)Options.WatchList).ToString();
                    this.Items.Add(item);
                }
                for (int idx = 0; idx < portfolioTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                    item.Attribute1 = ((byte)Options.WatchList).ToString();
                    this.Items.Add(item);
                }
            }
            //User Portfolio
            if (InList(options, Options.UserPorfolio))
            {
                portfolioTbl = DataAccess.Libs.GetPortfolio_ByInvestorAndType(commonClass.SysLibs.sysLoginCode, AppTypes.PortfolioTypes.Portfolio);
                if (portfolioTbl.Count > 0)
                {
                    item = new common.myKeyValueExt("--" + Languages.Libs.GetString("portfolio") + "--", "");
                    item.Attribute1 = ((byte)Options.UserPorfolio).ToString();
                    this.Items.Add(item);
                }
                for (int idx = 0; idx < portfolioTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                    item.Attribute1 = ((byte)Options.UserPorfolio).ToString();
                    this.Items.Add(item);
                }
            }

            if (InList(options, Options.Sectors))
            {
                item = new common.myKeyValueExt("--" + Languages.Libs.GetString("bySectors") + "--", "");
                item.Attribute1 = ((byte)Options.Sectors).ToString();
                this.Items.Add(item);
            }

            if (this.Items.Count > 0)
            {
                this.MaxDropDownItems = this.Items.Count;
                this.SelectedIndex = 0;
            }
            lastOptions = options;
        }
        public new virtual Options myValue
        {
            get
            {
                if (this.SelectedItem == null) return Options.None;
                common.myKeyValueExt item = (common.myKeyValueExt)this.SelectedItem;
                return (Options)byte.Parse(item.Attribute1);
            }
            set
            {
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    common.myKeyValueExt item = (common.myKeyValueExt)this.SelectedItem;
                    if ((Options)byte.Parse(item.Attribute1) == value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        private bool InList(Options[] list, Options item)
        {
            for (int idx = 0; idx < list.Length; idx++)
            {
                if (list[idx] == item) return true;
            }
            return false;
        }
    }

    public class cbLanguages: common.controls.baseComboBox
    {
        public cbLanguages()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.LanguageCodes));
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.LanguageCodes item in Enum.GetValues(typeof(AppTypes.LanguageCodes)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.myValue = AppTypes.LanguageCodes.EN;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }

        public new virtual AppTypes.LanguageCodes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.LanguageCodes.EN;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.LanguageCodes item in Enum.GetValues(typeof(AppTypes.LanguageCodes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.LanguageCodes.EN;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public CultureInfo myCulture
        {
            get
            {
                return AppTypes.Code2Culture(this.myValue);
            }
            set
            {
                this.myValue = AppTypes.Culture2Code(value);
            }
        }
    }

    public class cbStrategyType : common.controls.baseComboBox
    {
        public cbStrategyType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.StrategyTypes));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.StrategyTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.StrategyTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.StrategyTypes.Strategy;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.StrategyTypes.Strategy;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.StrategyTypes.Strategy;
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTimeRange : common.controls.baseComboBox
    {
        public cbTimeRange()
        {
            //this.myValue = AppTypes.TimeRanges.YTD;
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeRanges));
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for(int idx=0;idx<ranges.Length;idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            this.myValue = Settings.sysGlobal.DefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }
        public void LoadDataWithout(AppTypes.TimeRanges[] excludeList)
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                bool fAccept = true;
                for (int idx = 0; idx < excludeList.Length; idx++)
                {
                    if (excludeList[idx] == item)
                    {
                        fAccept = false;
                        break;
                    }
                }
                if (fAccept)
                    this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.myValue = Settings.sysGlobal.DefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }

        public override void LoadData()
        {
            LoadDataWithout(new AppTypes.TimeRanges[] { AppTypes.TimeRanges.None });
        }

        public new virtual AppTypes.TimeRanges myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TimeRanges.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TimeRanges.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.TimeRanges.None;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }

        public DateTime StartDate = common.Consts.constNullDate;
        public DateTime EndDate = common.Consts.constNullDate;
        public bool GetDate()
        {
            return AppTypes.GetDate(this.myValue, out this.StartDate, out this.EndDate);
        }
    }
    public class cbTimeScale : common.controls.baseComboBox
    {
        public cbTimeScale()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeScale));
        }

        public override void LoadData()
        {
            LoadList(AppTypes.myTimeScales);
        }
        public void LoadList(AppTypes.TimeScale[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(list[idx].Description, list[idx].Code));
            if (this.Items.Count > 0)
            {
                this.MaxDropDownItems = this.Items.Count;
                this.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);
            }
        }
        public new virtual AppTypes.TimeScale myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.MainDataTimeScale;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                return AppTypes.TimeScaleFromCode(selectedItem.Value);
            }
            set
            {
                //if (value == null) return;
                string statStr = value.Code;
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new string SelectedValue
        {
            get
            {
                return this.myValue.Code;
            }
            set
            {
                this.myValue = AppTypes.TimeScaleFromCode(value);
            }
        }
    }
    public class cbTradeAction : common.controls.baseComboBox
    {
        public cbTradeAction()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TradeActions));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                if (!allItem && item == AppTypes.TradeActions.None) continue;
                this.Items.Add(new common.myComboBoxItem(item.ToString(), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.TradeActions[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(list[idx].ToString(), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.TradeActions myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TradeActions.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TradeActions.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = (AppTypes.TradeActions)value;
            }
        }
    }
    public class cbBizSectorType : common.controls.baseComboBox
    {
        public cbBizSectorType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.BizSectorTypes));
        }

        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
            {
                if (!allItem && item == AppTypes.BizSectorTypes.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.BizSectorTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.BizSectorTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.BizSectorTypes.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.BizSectorTypes.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.BizSectorTypes.None;
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbChartType : common.controls.baseComboBox
    {
        public cbChartType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.ChartTypes));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem )
        {
            this.Items.Clear();
            foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
            {
                if (!allItem && item== AppTypes.ChartTypes.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.ChartTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.ChartTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.ChartTypes.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.ChartTypes.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.ChartTypes.None;
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbCommonStatus : common.controls.baseComboBox
    {
        public cbCommonStatus()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.CommonStatus));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
            {
                if (!allItem && item == AppTypes.CommonStatus.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.CommonStatus[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.CommonStatus myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.CommonStatus.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.CommonStatus.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.CommonStatus.None;
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTradeAlertStatus : cbCommonStatus
    {
        public cbTradeAlertStatus()
        {
        }
        public override void LoadData() 
        {
            LoadList(new AppTypes.CommonStatus[] { AppTypes.CommonStatus.New,AppTypes.CommonStatus.Close});
        }
    }
    public class cbStockStatus : cbCommonStatus
    {
        public cbStockStatus()
        {
        }
        public override void LoadData()
        {
            LoadList(new AppTypes.CommonStatus[] { AppTypes.CommonStatus.Enable, AppTypes.CommonStatus.Disable, AppTypes.CommonStatus.New});
        }
    }

    public class cbSysCodeCat : common.controls.baseComboBox
    {
        public cbSysCodeCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.sysCodeCatDataTable tbl = DataAccess.Libs.mySysCodeCatTbl;
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.categoryColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public databases.baseDS.sysCodeCatRow GetRow(string code)
        {
            return ((databases.baseDS.sysCodeCatDataTable)this.DataSource).FindBycategory(code);
        }
    }
    public class cbCurrency : common.controls.baseComboBox
    {
        public cbCurrency()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.currencyDataTable tbl = DataAccess.Libs.myCurrencyTbl;
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public databases.baseDS.currencyRow GetRow(string code)
        {
            return ((databases.baseDS.currencyDataTable)this.DataSource).FindBycode(code);
        }
    }
    public class cbCountry : common.controls.baseComboBox
    {
        public cbCountry()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.countryDataTable tbl = DataAccess.Libs.myCountryTbl;
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public databases.baseDS.countryRow GetRow(string code)
        {
            return ((databases.baseDS.countryDataTable)this.DataSource).FindBycode(code);
        }
    }
    
    public class cbInvestorCat : common.controls.baseComboBox
    {
        public cbInvestorCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void SetLanguage()
        {
            LoadData();
        }
        public override void LoadData()
        {
            databases.baseDS.investorCatDataTable tbl = DataAccess.Libs.myInvestorCatTbl;
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
    }
    public class cbStrategyCat : common.controls.baseComboBox
    {
        public override void SetLanguage()
        {
            common.myComboBoxItem[] newItems = new common.myComboBoxItem[this.Items.Count];
            for (int idx = 0; idx < this.Items.Count; idx++)
            {
                common.myComboBoxItem item = (this.Items[idx] as common.myComboBoxItem);
                if (item.Value == Settings.sysString_All_Code)
                {
                    newItems[idx] = new common.myComboBoxItem(Settings.sysString_All_Description, Settings.sysString_All_Code);
                    continue;
                }
                commonClass.DataCategory cat = application.StrategyData.myCatList.Find((item.Value));
                if (cat == null) continue;
                newItems[idx] =  new common.myComboBoxItem(cat.Description,cat.Code);
            }
            this.Items.Clear();
            this.Items.AddRange(newItems);
        }
        public override void LoadData()
        {
            LoadData(false);
        }
        public override string myValue
        {
            get
            {
                if (this.SelectedItem == null) return "";
                return (this.SelectedItem as common.myComboBoxItem).Value;
            }
            set
            {
                base.myValue = value;
            }
        }
        public virtual void LoadData(bool AddAllItem)
        {
            this.Items.Clear();
            if (AddAllItem)
            {
                this.Items.Add(new common.myComboBoxItem(Settings.sysString_All_Description, Settings.sysString_All_Code));
            }
            for (int idx = 0; idx < application.StrategyData.myCatList.Count; idx++)
            {
                this.Items.Add(new common.myComboBoxItem(application.StrategyData.myCatList[idx].Description, application.StrategyData.myCatList[idx].Code));
            }
        }
        public virtual bool IsAllValueSelected()
        {
            return (this.myValue == Settings.sysString_All_Code);
        }
        public virtual string[] GetAllValues()
        {
            string[] list = new string[0];
            databases.baseDS.portfolioDataTable tbl = (databases.baseDS.portfolioDataTable)this.DataSource;

            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code == Settings.sysString_All_Code) continue;
                Array.Resize(ref list, list.Length + 1);
                list[list.Length - 1] = tbl[idx].code;
            }
            return list;
        }
        public virtual string[] GetValues()
        {
            if (IsAllValueSelected()) return GetAllValues();
            return new string[] { this.myValue };
        }
    }
    public class cbEmployeeRange : common.controls.baseComboBox
    {
        public cbEmployeeRange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.employeeRangeDataTable tbl = DataAccess.Libs.myEmployeeRangeTbl; 
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public new int myValue
        {
            get 
            { 
                int no = 0;
                if (!int.TryParse(base.myValue, out no)) return 0;
                return no;
            }
            set 
            {
                if (this.DataSource == null) return;
                databases.baseDS.employeeRangeDataTable tbl = (databases.baseDS.employeeRangeDataTable)this.DataSource;
                int no = 0;
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    if (!int.TryParse(tbl[idx].code, out no)) continue;
                    if (no == value)
                    {
                        base.myValue = tbl[idx].code;
                        break;
                    }
                }
            }
        }
    }
    public class cbStockExchange : common.controls.baseComboBox
    {
        public cbStockExchange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            databases.baseDS.stockExchangeDataTable tbl = DataAccess.Libs.myStockExchangeTbl;
            this.DisplayMember = tbl.codeColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public void LoadDataDB()
        {
            databases.baseDS.stockExchangeDataTable tbl = new databases.baseDS.stockExchangeDataTable();
            databases.DbAccess.LoadData(tbl);
            this.DisplayMember = tbl.codeColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public databases.baseDS.stockExchangeRow GetInfo(string code)
        {
            return (this.DataSource as databases.baseDS.stockExchangeDataTable).FindBycode(code);
        }
    }

    public class cbWatchList : common.controls.baseComboBox
    {
        public cbWatchList()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadData(string investorCode, AppTypes.PortfolioTypes type)
        {
            LoadData(type, investorCode, false);
        }
        public void LoadData(AppTypes.PortfolioTypes type, string investorCode, bool AddAllItem)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            if (AddAllItem)
            {
                databases.baseDS.portfolioRow row = tbl.NewportfolioRow();
                databases.AppLibs.InitData(row);
                row.investorCode = investorCode;
                row.name = Settings.sysString_All_Description;
                row.code = Settings.sysString_All_Code;
                tbl.AddportfolioRow(row);
            }
            databases.baseDS.portfolioDataTable tmpTbl = DataAccess.Libs.GetPortfolio_ByInvestorAndType(investorCode, type);
            for (int idx = 0; idx < tmpTbl.Count; idx++)  tbl.ImportRow(tmpTbl[idx]);

            
            this.DisplayMember = tbl.nameColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }

        public void LoadData(string investorCode, bool AddAllItem)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            if (AddAllItem)
            {
                databases.baseDS.portfolioRow row = tbl.NewportfolioRow();
                databases.AppLibs.InitData(row);
                row.investorCode = investorCode;
                row.name = Settings.sysString_All_Description;
                row.code = Settings.sysString_All_Code;
                tbl.AddportfolioRow(row);
            }
            databases.baseDS.portfolioDataTable tmpTbl = DataAccess.Libs.GetPortfolio_ByInvestor(investorCode);
            for (int idx = 0; idx < tmpTbl.Count; idx++) tbl.ImportRow(tmpTbl[idx]);


            this.DisplayMember = tbl.nameColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }

        public virtual bool IsAllValueSelected()
        {
            return (this.myValue == Settings.sysString_All_Code);
        }
        public virtual StringCollection GetAllValues()
        {
            StringCollection list = new StringCollection();
            databases.baseDS.portfolioDataTable tbl = (databases.baseDS.portfolioDataTable)this.DataSource;
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code == Settings.sysString_All_Code) continue;
                list.Add(tbl[idx].code);
            }
            return list;
        }
        public virtual string[] GetValues()
        {
            if (IsAllValueSelected())
            {
                return common.system.Collection2List(GetAllValues());
            }
            return new string[] { this.myValue };
        }
    }

    public class cbSex : common.controls.baseComboBox
    {
        public cbSex()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.Sex));
        }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
            {
                if (!allItem && item == AppTypes.Sex.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public override void LoadData() { LoadData(false);}
        public void LoadList(AppTypes.Sex[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.Sex myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.Sex.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.Sex.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.Sex.None;
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }

    public class cbStrategy : common.controls.baseComboBox
    {
        public cbStrategy()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            LoadData(AppTypes.StrategyTypes.Strategy);
        }
        public virtual void LoadData(AppTypes.StrategyTypes type)
        {
            string[] keys = application.StrategyData.MetaList.Keys;
            object[] values = application.StrategyData.MetaList.Values;
            this.Items.Clear();
            for (int idx = 0; idx < keys.Length; idx++)
            {
                application.Strategy.StrategyMeta meta = (application.Strategy.StrategyMeta)values[idx];
                if (meta.Type != type) continue;
                this.Items.Add(new common.myComboBoxItem(meta.Code.Trim()+" - " +meta.Name, meta.Code));
            }
            if (this.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.MaxDropDownItems = this.Items.Count;
            }
        }
        public override string myValue
        {
            get
            {
                if (this.SelectedItem == null) return "";
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                return selectedItem.Value;
            }
            set
            {
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value == value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new string SelectedValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value; 
            }
        }
    }

    #endregion

    #region Checked Listbox
    public class clbWatchList : baseCheckedLB
    {
        private AppTypes.PortfolioTypes _watchType = AppTypes.PortfolioTypes.Portfolio;
        public AppTypes.PortfolioTypes WatchType
        {
            get { return this._watchType; }
            set { this._watchType = value; }
        }

        public clbWatchList()
        {
        }
        public override void LoadData()
        {
            LoadData(commonClass.SysLibs.sysLoginCode, false);
        }
        private databases.baseDS.portfolioDataTable dataTbl = new databases.baseDS.portfolioDataTable();
        public virtual void LoadData(string investorCode, bool checkedAll)
        {
            dataTbl = DataAccess.Libs.GetPortfolio_ByInvestorAndType(investorCode, this.WatchType);
            this.Items.Clear();
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].name.Trim(), dataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }

        protected override object MakeItem(string value)
        {
            databases.baseDS.portfolioRow row = dataTbl.FindBycode(value);
            if (row == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(row.name, value);
        }
    }

    public class clbTimeScale : baseCheckedLB
    {
        public clbTimeScale() { }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeScale));
        }
        public override void LoadData()
        {
            AppTypes.TimeScale defauTimeScale = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);
            foreach (AppTypes.TimeScale item in AppTypes.myTimeScales)
            {
                this.Items.Add(new common.myComboBoxItem(item.Text, item.Code), item.Code == defauTimeScale.Code);
            }
            SaveItems();
        }
    }
    public class clbTimeRange : baseCheckedLB
    {
        public clbTimeRange() { }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeRanges));
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            SaveItems();
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for (int idx = 0; idx < ranges.Length; idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            SaveItems();
        }
    }

    public class clbStrategy : baseCheckedLB
    {
        private AppTypes.StrategyTypes strategyType = AppTypes.StrategyTypes.Strategy; 
        public clbStrategy() { }
        public override void SetLanguage()
        {
            LoadData(strategyType);
        }
        public override void LoadData()
        {
            LoadData(AppTypes.StrategyTypes.Strategy);
        }
        public void LoadData(AppTypes.StrategyTypes type)
        {
            LoadData(type,null);
            SaveItems();
        }

        protected void LoadData(AppTypes.StrategyTypes type,string catCode)
        {
            this.strategyType = type;
            string[] keys = application.StrategyData.MetaList.Keys;
            object[] values = application.StrategyData.MetaList.Values;
            this.Items.Clear();
            for (int idx = 0; idx < keys.Length; idx++)
            {
                application.Strategy.StrategyMeta meta = (application.Strategy.StrategyMeta)values[idx];
                if (meta.Type != type) continue;
                if (catCode==null || meta.Category == catCode) 
                    this.Items.Add(new common.myComboBoxItem(meta.Name,meta.Code));
            }
        }
        public void SetFilter(string catCode)
        {
            LoadData(this.strategyType,catCode);
            SaveItems();
        }
    }
    public class clbStockCode : baseCheckedLB
    {
        private databases.tmpDS.stockCodeRow stockCodeRow;
        public clbStockCode() { }
        private databases.tmpDS.stockCodeDataTable _myDataTbl = null;
        public databases.tmpDS.stockCodeDataTable myDataTbl
        {
            get { return _myDataTbl; }
            set
            {
                this.Items.Clear();
                this._myDataTbl = value;
                if (_myDataTbl == null) return;
                string tmp;
                for (int idx = 0; idx < value.Count; idx++)
                {
                    tmp = value[idx].tickerCode.Trim() + " - " + (value[idx].IsnameEnNull() ? "" : value[idx].nameEn);
                    this.Items.Add(new common.myComboBoxItem(tmp, value[idx].code.Trim()), false);
                }
                this.SaveItems();
            }
        }

        public override void LoadData()
        {
            this.myDataTbl = DataAccess.Libs.myStockCodeTbl;
        }
        protected override object MakeItem(string value)
        {
            stockCodeRow = this.myDataTbl.FindBycode(value);
            if (stockCodeRow == null) return new common.myComboBoxItem(value, value);
            if (commonClass.SysLibs.IsUseVietnamese()) 
                return new common.myComboBoxItem(value + " - " + stockCodeRow.name, value);
            return new common.myComboBoxItem(value + " - " + (stockCodeRow.IsnameEnNull() ? "" : stockCodeRow.nameEn), value);
        }
    }
    public class clbBizSector : baseCheckedLB
    {
        public clbBizSector() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        databases.baseDS.bizSubSectorDataTable _myDataTbl = null;
        databases.baseDS.bizSubSectorDataTable myDataTbl
        {
            get
            { 
                if (_myDataTbl==null)_myDataTbl = DataAccess.Libs.myBizSubSectorTbl;
                return _myDataTbl;
            }
        }

        public void LoadData(bool checkedAll)
        {
            for (int idx = 0; idx < myDataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(myDataTbl[idx].description1.Trim(), myDataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        protected override object MakeItem(string value)
        {
            databases.baseDS.bizSubSectorRow bizSubSectorRow;
            bizSubSectorRow = myDataTbl.FindBycode(value);
            if (bizSubSectorRow==null) return null;
            string tmp = value + (bizSubSectorRow == null ? "" : " - " + bizSubSectorRow.description1);
            return new common.myComboBoxItem(tmp, value.Trim());
        }
    }
    public class clbBizSubSector : baseCheckedLB
    {
        private databases.baseDS.bizSubSectorRow subSectorRow;
        public clbBizSubSector() { }
        protected override object MakeItem(string value)
        {
            databases.baseDS.bizSubSectorDataTable tbl = DataAccess.Libs.myBizSubSectorTbl;
            subSectorRow = tbl.FindBycode(value);
            if (subSectorRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + subSectorRow.description1, value);
        }
    }
    public class clbBizSupperSector : baseCheckedLB
    {
        databases.baseDS.bizSuperSectorDataTable _myDataTbl = null;
        databases.baseDS.bizSuperSectorDataTable myDataTbl
        {
            get
            {
                if (_myDataTbl == null) _myDataTbl = DataAccess.Libs.myBizSuperSectorTbl;
                return _myDataTbl;
            }
        }
        public clbBizSupperSector() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool checkedAll)
        {
            for (int idx = 0; idx < myDataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(myDataTbl[idx].description1.Trim(), myDataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        public databases.baseDS.bizSuperSectorRow GetRow(string code)
        {
            return myDataTbl.FindBycode(code);
        }
    }
    public class clbBizIndustry : baseCheckedLB
    {
        databases.baseDS.bizIndustryDataTable _myDataTbl = null;
        databases.baseDS.bizIndustryDataTable myDataTbl
        {
            get
            {
                if (_myDataTbl == null) _myDataTbl = DataAccess.Libs.myBizIndustryTbl;
                return _myDataTbl;
            }
        }
        public clbBizIndustry() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool checkedAll)
        {
            for (int idx = 0; idx < myDataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(myDataTbl[idx].description1.Trim(), myDataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        public databases.baseDS.bizIndustryRow GetRow(string code)
        {
            return myDataTbl.FindBycode(code);
        }
    }
    #endregion Checked Listbox

    #region Listbox
    public class lbStockCode : baseListBox 
    {
        databases.tmpDS.stockCodeDataTable myDataTbl
        {
            get
            {
                return DataAccess.Libs.myStockCodeTbl;
            }
        }
        private databases.tmpDS.stockCodeRow stockCodeRow;
        public lbStockCode() { }
        public override void LoadData() { }
        protected override object MakeItem(string value)
        {
            stockCodeRow = myDataTbl.FindBycode(value);
            if (stockCodeRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + (stockCodeRow.IsnameEnNull()?"":stockCodeRow.nameEn), value);
        }
    }
    public class lbSubSectorCode : baseListBox
    {
        databases.baseDS.bizSubSectorDataTable _myDataTbl = null;
        databases.baseDS.bizSubSectorDataTable myDataTbl
        {
            get
            {
                if (_myDataTbl == null) _myDataTbl = DataAccess.Libs.myBizSubSectorTbl;
                return _myDataTbl;
            }
        }

        private databases.baseDS.bizSubSectorRow subSectorRow;
        public lbSubSectorCode() { }
        public override void LoadData() { }
        protected override object MakeItem(string value)
        {
            subSectorRow = myDataTbl.FindBycode(value);
            if (subSectorRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + subSectorRow.description1, value);
        }
    }
    #endregion Listbox

    #region textBox
    public class txtDate : common.controls.baseDate 
    {
        public txtDate()
        {
            this.BackColor = common.Settings.sysColorNormalBG;
            this.ForeColor = common.Settings.sysColorNormalFG;
        }
    }
    
    public class txtStockCode : common.controls.baseTextBox
    {
        public txtStockCode()
        {
            this.BackColor = common.Settings.sysColorNormalBG;
            this.ForeColor = common.Settings.sysColorNormalFG;
            this.isToUpperCase = true;
            this.myOnFind += new onFind(DoFind);
        }
        private void DoFind(object sender)
        {
            forms.companyFind form = forms.companyFind.GetForm("");
            form.Find(this.Text);
            databases.tmpDS.stockCodeRow row = form.selectedDataRow;
            if (row == null) return;
            this.Text = row.tickerCode;
            return;
        }
    }

    public class txtInvestor : common.controls.baseTextBox
    {
        databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
        public txtInvestor()
        {
            this.isToUpperCase = true;
            this.MaxLength = tbl.accountColumn.MaxLength;
            tbl.Dispose();
            this.myOnFind += new onFind(DoFind);
        }
        private void DoFind(object sender)
        {
            string code = this.Text.Trim();
            forms.investorFind findForm = forms.investorFind.GetForm("");
            findForm.Find(code);
            databases.baseDS.investorRow row = findForm.selectedDataRow;
            if (row == null)
            {
                this.Text = "";
                return;
            }
            this.Text = row.account;
        }
    }
    #endregion

    #region other
    public class baseLabel : common.controls.baseLabel
    {
        public baseLabel()
        {
            //this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    public class baseButton : common.controls.baseButton
    {
        public baseButton()
        {
            //this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    public class baseCheckBox : common.controls.baseCheckBox
    {
        public baseCheckBox()
        {
            //this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    #endregion other
}
