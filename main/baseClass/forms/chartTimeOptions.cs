using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class chartTimeOptions : common.forms.baseDialogForm  
    {
        public chartTimeOptions()
        {
            try
            {
                InitializeComponent();
                timeRangeCb.SelectedIndex = 0; 
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public void InitData()
        {
            int count = 0;
            this.timeRangeCb.Items.Clear();
            foreach (application.myTypes.timeRanges item in Enum.GetValues(typeof(application.myTypes.timeRanges)))
            {
                if (item == application.myTypes.timeRanges.None) continue;
                this.timeRangeCb.Items.Add(new common.myComboBoxItem(application.myTypes.Type2Text(item), item.ToString()));
                count++;
            }
            if (this.timeRangeCb.Items.Count > 0) this.timeRangeCb.SelectedIndex = 0;
            this.timeRangeCb.MaxDropDownItems = count;

            timeRangeCb.myValue = application.myTypes.timeRanges.YTD; 
            frDateEd.myDateTime = DateTime.Today;
            toDateEd.myDateTime = frDateEd.myDateTime;
        }

        public DateTime frDate = common.Consts.constNullDate, toDate = common.Consts.constNullDate;
        public bool GetDate()
        {
            ClearNotifyError();
            bool retVal = true;
            switch (this.myTimeRange)
            {
                case application.myTypes.timeRanges.Range:
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

                case application.myTypes.timeRanges.D1:
                    frDate = DateTime.Today;
                    toDate = frDate; break;
                case application.myTypes.timeRanges.D3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddDays(-3); break;

                case application.myTypes.timeRanges.W:
                    toDate = DateTime.Today;
                    frDate = toDate.AddDays(-7); break;

                case application.myTypes.timeRanges.M1:
                    toDate = DateTime.Today;
                    frDate = toDate.AddMonths(-1); break;
                case application.myTypes.timeRanges.M3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddMonths(-3); break;
                case application.myTypes.timeRanges.YTD:
                    toDate = DateTime.Today;
                    common.dateTimeLibs.MakeDate(1, 1, toDate.Year, out frDate); break;

                case application.myTypes.timeRanges.Y1:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-1); break;

                case application.myTypes.timeRanges.Y2:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-2); break;

                case application.myTypes.timeRanges.Y3:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-3); break;

                case application.myTypes.timeRanges.Y4:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-4); break;

                case application.myTypes.timeRanges.Y5:
                    toDate = DateTime.Today;
                    frDate = toDate.AddYears(-5); break;
                default:
                    NotifyError(timeRangeCb);
                    return false;
            }
            toDate = toDate.Date.AddDays(1).AddSeconds(-1);
            return retVal;
        }
        public virtual application.myTypes.timeRanges myTimeRange
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

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = GetDate();
            return retVal;
        }
        private void timeRangeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            frDateEd.Enabled = this.myTimeRange == application.myTypes.timeRanges.Range;
            toDateEd.Enabled = frDateEd.Enabled;
        }
    }    
}