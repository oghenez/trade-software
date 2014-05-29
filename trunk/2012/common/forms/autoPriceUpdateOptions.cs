using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace common.forms
{
    public partial class autoPriceUpdateOptions : common.forms.baseForm
    {
        private const string numberMask = "###,###,###";
        private bool fProccessing = false;

        public bool okBtnSelected=false;
        public enum increaseType : byte
        {
            None=0,ByPercentage=1,ByValue = 2
        }
        public autoPriceUpdateOptions()
        {
            InitializeComponent();
            myStatusStrip.Visible = false;
            //4 possible precision options: 1 10 100 1.000 100.000 1.000.000
            roundUpCb.Items.Clear();
            int roundUpAt = 1;
            for (int idx = 0; idx < 6; idx++)
            {
                roundUpCb.Items.Add(roundUpAt.ToString(numberMask));
                roundUpAt *= 10;
            }
            roundUpCb.SelectedIndex = 0;
            updateTypeCb.SelectedIndex = 0;
        }
        public bool ShowControl()
        {
            this.BringToFront();
            this.ShowDialog();
            return okBtnSelected;
        }
        public bool isIncreaseUpdate
        {
            get 
            { 
                if (updateTypeCb.SelectedIndex == 0) return true;
                return false; 
            }
            set { updateTypeCb.SelectedIndex = (value?0:1); }
        }
        public byte roundUpPrecision
        {
            get { return (byte)(roundUpCb.SelectedIndex); }
            set 
            {
                if (value <0 || value >= roundUpCb.Items.Count) return; 
                roundUpCb.SelectedIndex = value; 
            }
        }

        public increaseType increaseBy
        {
            get 
            {
                if (byPercentRb.Checked) return increaseType.ByPercentage;
                if (byValueRb.Checked) return increaseType.ByValue;
                return increaseType.None;
            }
            set 
            {
                if (fProccessing) return;
                fProccessing = true;
                switch(value)
                {
                    case increaseType.ByPercentage :
                         byPercentRb.Checked = true; byValueRb.Checked = false;
                         byPercentEd.Enabled = true; byValueEd.Enabled = false;  
                         break;
                    case increaseType.ByValue:
                         byPercentRb.Checked = false; byValueRb.Checked = true;
                         byPercentEd.Enabled = false; byValueEd.Enabled = true;  
                         break;
                    default: 
                        byValueRb.Checked = false; byPercentRb.Checked = false;
                        byPercentEd.Enabled = false; byValueEd.Enabled = false;  
                        break;
                }
                fProccessing = false;
            }
        }

        public int increaseValue
        {
            get
            {
                if (byPercentRb.Checked) return (int)byPercentEd.Value;
                if (byValueRb.Checked)
                {
                    return (int)byValueEd.Value;
                }
                return 0;
            }
            set
            {
                if (byPercentRb.Checked)
                {
                    byPercentEd.Value = value; return;
                }
                if (byValueRb.Checked)
                {
                    byValueEd.Value = (decimal)value;
                    return;
                }
            }
        }

        private void byPercentRb_CheckedChanged(object sender, EventArgs e)
        {
            increaseBy = increaseType.ByPercentage;
        }

        private void byValueRb_CheckedChanged(object sender, EventArgs e)
        {
            increaseBy = increaseType.ByValue;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            okBtnSelected = true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            okBtnSelected = false;
            this.Hide();
        }

    }
}

