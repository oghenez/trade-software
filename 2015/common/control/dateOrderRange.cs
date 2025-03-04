using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace common.controls
{
    public partial class dateOrderRange : UserControl
    {
        public DateTime frDate, toDate;
        public string DateRangeDesc;

        //Make Enter key works as Tabkey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Make ENTER key work as TAB key for all controls except BUTTON
            if ((common.settings.sysEnterSameAsTabKey && (msg.WParam.ToInt32() == (int)Keys.Enter) &&
                (this.ActiveControl != null) && (this.ActiveControl.GetType().Name.ToUpper().Trim() != "BUTTON")))
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public dateOrderRange()
        {
            InitializeComponent();
            this.dateRangeCb.SelectedIndex = 3; 
        }

        public bool GetDateRange()
        {
            return GetDateRange(out frDate, out toDate);
        }
        public bool GetDateRange(out DateTime frDate, out DateTime toDate)
        {
            frDate = DateTime.Today;
            toDate = DateTime.Today;
            CultureInfo MyCultureInfo = globalSettings.GetCurrentCulture();
            switch (this.dateRangeCb.SelectedIndex)
            {
                case 0: //Last month
                    frDate = frDate.AddDays(-frDate.Day + 1); frDate = frDate.AddMonths(-1);
                    toDate = frDate.AddMonths(1); toDate = toDate.AddDays(-1);
                    break;
                case 1: //Last week
                    switch (frDate.DayOfWeek)
                    {
                        case DayOfWeek.Sunday: frDate = frDate.AddDays(-7); break;
                        case DayOfWeek.Monday: frDate = frDate.AddDays(-8); break;
                        case DayOfWeek.Tuesday: frDate = frDate.AddDays(-9); break;
                        case DayOfWeek.Wednesday: frDate = frDate.AddDays(-10); break;
                        case DayOfWeek.Thursday: frDate = frDate.AddDays(-11); break;
                        case DayOfWeek.Friday: frDate = frDate.AddDays(-12); break;
                        case DayOfWeek.Saturday: frDate = frDate.AddDays(-13); break;
                    }
                    toDate = frDate.AddDays(6);
                    break;
                case 2: //Last day
                    frDate = frDate.AddDays(-1); toDate = frDate;
                    break;
                case 3: //Current day
                    break;
                case 4: //Current week
                    switch (frDate.DayOfWeek)
                    {
                        case DayOfWeek.Sunday: break;
                        case DayOfWeek.Monday: frDate = frDate.AddDays(-1); break;
                        case DayOfWeek.Tuesday: frDate = frDate.AddDays(-2); break;
                        case DayOfWeek.Wednesday: frDate = frDate.AddDays(-3); break;
                        case DayOfWeek.Thursday: frDate = frDate.AddDays(-4); break;
                        case DayOfWeek.Friday: frDate = frDate.AddDays(-5); break;
                        case DayOfWeek.Saturday: frDate = frDate.AddDays(-6); break;
                    }
                    toDate = frDate.AddDays(6);
                    break;
                case 5: //Current month
                    frDate = frDate.AddDays(-frDate.Day + 1);
                    toDate = frDate.AddMonths(1); toDate.AddDays(-1);
                    break;
                case 6: //Specified day
                    if (!DateTime.TryParse(this.frDateEd.Text, MyCultureInfo, DateTimeStyles.NoCurrentDateDefault, out frDate))
                    {
                        MessageBox.Show("[Ngày] không hợp lệ!", globalSettings.GetCurrentCulture().DisplayName); return false;
                    }
                    //toDate = frDate.AddDays(1).AddSeconds(-1);
                    toDate = frDate;
                    break;
                default: //from - to
                    if (this.frDateEd.Text.Equals("") || this.toDateEd.Text.Equals(""))
                    {
                        MessageBox.Show("Chưa nhập [Từ ngày] hoặc [Đến ngày]!", globalSettings.GetCurrentCulture().DisplayName);
                        return false;
                    }
                    if (!DateTime.TryParse(this.frDateEd.Text, MyCultureInfo, DateTimeStyles.NoCurrentDateDefault, out frDate))
                    {
                        MessageBox.Show("[Từ ngày] không hợp lệ!", globalSettings.GetCurrentCulture().DisplayName); return false;
                    }
                    if (!DateTime.TryParse(this.toDateEd.Text, MyCultureInfo, DateTimeStyles.NoCurrentDateDefault, out toDate))
                    {
                        MessageBox.Show("[Đến ngày] không hợp lệ!", globalSettings.GetCurrentCulture().DisplayName); return false;
                    }
                    break;
            }
            toDate = toDate.AddDays(1).AddSeconds(-1);
            return true;
        }

        private void dateRangeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dateRangeCb.SelectedIndex == this.dateRangeCb.Items.Count - 2)
            {
                this.frDateLbl.Text = "Ngày"; 
                this.frDateLbl.Enabled = true; this.toDateLbl.Enabled = true; 
                this.frDateEd.Enabled = true; this.toDateEd.Enabled = false;
                return;
            }
            if (this.dateRangeCb.SelectedIndex == this.dateRangeCb.Items.Count - 1)
            {
                this.frDateLbl.Text = "Từ ngày";
                this.frDateEd.Enabled = true; this.toDateEd.Enabled = true;
                this.frDateLbl.Enabled= true; this.toDateLbl.Enabled= true; 
                return;
            }
            this.frDateEd.Enabled = false; this.toDateEd.Enabled = false;
            this.frDateLbl.Enabled= false; this.toDateLbl.Enabled= false; 
        }

        private void frDateEd_Enter(object sender, EventArgs e)
        {
            this.frDateEd.SelectAll();
        }

        private void toDateEd_Enter(object sender, EventArgs e)
        {
            this.toDateEd.SelectAll();
        }
    }
}