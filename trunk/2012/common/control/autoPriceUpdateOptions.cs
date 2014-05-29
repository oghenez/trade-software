using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace common.controls
{
    public partial class autoPriceUpdateOptions : UserControl
    {
        private const string numberMask = "###,###,###";
        public bool okBtnSelected=false;
        public enum increaseType : byte
        {
            None=0,ByPercentage=1,ByValue = 2
        }
        public autoPriceUpdateOptions()
        {
            InitializeComponent();
            //4 possible option for precision : 100 1.000 100.000 1.000.000
            int roundUpAt = 10;
            for (int idx = 0; idx < 4; idx++)
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
            this.Show();
            return true;
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
            get { return (byte)(roundUpCb.SelectedIndex+2); }
            set 
            {
                if (value-2 <0 || value-2 >= roundUpCb.Items.Count) return; 
                roundUpCb.SelectedIndex = value-2; 
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
                switch(value)
                {
                    case increaseType.ByPercentage :
                         byPercentRb.Checked = true;
                         byPercentEd.Enabled = true; byValueEd.Enabled = false;  
                         break;
                    case increaseType.ByValue: 
                         byValueRb.Checked = true;
                         byPercentEd.Enabled = false; byValueEd.Enabled = true;  
                         break;
                    default: 
                        byValueRb.Checked = false; byPercentRb.Checked = false;
                        byPercentEd.Enabled = false; byValueEd.Enabled = false;  
                        break;
                }
            }
        }

        public int increaseValue
        {
            get
            {
                if (byPercentRb.Checked) return (int)byPercentEd.Value;
                if (byValueRb.Checked)
                {
                    int tmp = 0; int.TryParse(byValueEd.Text, out tmp);  
                    return tmp;
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
                    byValueEd.Text = value.ToString(numberMask);
                    return;
                }
            }
        }

        private void byPercentRb_CheckedChanged(object sender, EventArgs e)
        {
            increaseBy = increaseType.ByPercentage;
            byPercentEd.Focus();
        }

        private void byValueRb_CheckedChanged(object sender, EventArgs e)
        {
            increaseBy = increaseType.ByValue;
            byValueEd.Focus();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            okBtnSelected = true;
            this.Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            okBtnSelected = true;
            this.Hide();
        }
    }
}
