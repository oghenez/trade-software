using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace baseClass.controls
{
    public partial class chartTiming : common.control.baseUserControl
    {
        private bool fLoaded = false;
        public chartTiming()
        {
            try
            {
                this.fLoaded = false;
                InitializeComponent();
                timeScaleCb.LoadData();
                this.fLoaded = true;
                timing_Changed(this,null);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        public delegate void onDateAccept(object sender);
        public event onDateAccept myDateAccept = null;

        public DateTime frDate = common.Consts.constNullDate;
        public DateTime toDate = common.Consts.constNullDate;

        public void Set(chartTiming obj)
        {
            frDateEd.myDateTime = obj.frDate;
            toDateEd.myDateTime = obj.toDate;
            timeScaleCb.myValue = obj.myTimeScale;
            this.timeRangeCb.SelectedIndex = obj.timeRangeCb.SelectedIndex;
        }

        public void LoadData()
        {
            int count = 0;
            this.timeRangeCb.Items.Clear();
            foreach (application.myTypes.TimeRanges item in Enum.GetValues(typeof(application.myTypes.TimeRanges)))
            {
                if (item == application.myTypes.TimeRanges.None) continue;
                this.timeRangeCb.Items.Add(new common.myComboBoxItem(application.myTypes.Type2Text(item), item.ToString()));
                count++;
            }
            if (this.timeRangeCb.Items.Count > 0) this.timeRangeCb.SelectedIndex = 0;
            this.timeRangeCb.MaxDropDownItems = count;
            
            frDateEd.myDateTime = DateTime.Today;
            toDateEd.myDateTime = frDateEd.myDateTime;
        }
        public bool GetDate()
        {
            ClearNotifyError();
            bool retVal = true;
            switch (this.myTimeRange)
            {
                case application.myTypes.TimeRanges.Range:
                    if (frDateEd.myDateTime == common.Consts.constNullDate)
                    {
                        retVal = false;
                        NotifyError(frDateEd);
                    }
                    if (toDateEd.myDateTime == common.Consts.constNullDate)
                    {
                        retVal = false;
                        NotifyError(toDateEd);
                    }
                    frDate = frDateEd.myDateTime;
                    toDate = toDateEd.myDateTime;
                    break;

                case application.myTypes.TimeRanges.D1:
                    frDate = DateTime.Today;
                    toDate = frDate; break;
                case application.myTypes.TimeRanges.D3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddDays(-3); break;

                case application.myTypes.TimeRanges.W:
                    toDate = DateTime.Today;
                    frDate = toDate.AddDays(-7); break;

                case application.myTypes.TimeRanges.M1:
                    toDate = DateTime.Today;
                    frDate = toDate.AddMonths(-1); break;
                case application.myTypes.TimeRanges.M3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddMonths(-3); break;
                case application.myTypes.TimeRanges.YTD:
                    toDate = DateTime.Today;
                    common.dateTimeLibs.MakeDate(1, 1, toDate.Year, out frDate); break;

                case application.myTypes.TimeRanges.Y1:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-1); break;

                case application.myTypes.TimeRanges.Y2:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-2); break;

                case application.myTypes.TimeRanges.Y3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-3); break;
                
                case application.myTypes.TimeRanges.Y4:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-4); break;
                
                case application.myTypes.TimeRanges.Y5:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-5); break;
                default:
                    NotifyError(timeRangeCb);
                    return false;
            }
            toDate = toDate.Date.AddDays(1).AddSeconds(-1);
            return retVal;
        }
        public virtual application.myTypes.TimeRanges  myTimeRange
        {
            get
            {
                return timeRangeCb.myValue;
            }
            set
            {
                timeRangeCb.myValue = value;
            }
        }
        public virtual string myTimeScale
        {
            get
            {
                return timeScaleCb.myValue;
            }
            set
            {
                timeScaleCb.myValue = value;
            }
        }

        private void timing_Changed(object sender, EventArgs e)
        {
            if (!this.fLoaded) return;
            frDateEd.Enabled = this.myTimeRange == application.myTypes.TimeRanges.Range;
            toDateEd.Enabled = frDateEd.Enabled;
            okBtn.Enabled = frDateEd.Enabled;
            if (GetDate() && myDateAccept != null) myDateAccept(this);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (GetDate() && myDateAccept != null) myDateAccept(this);
        }
    }
}