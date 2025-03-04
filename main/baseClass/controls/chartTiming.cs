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
    public partial class chartTiming : common.controls.baseUserControl
    {
        private bool fLoaded = false;
        public chartTiming()
        {
            try
            {
                this.fLoaded = false;
                InitializeComponent();
                LoadData();
                this.fLoaded = true;
                timing_SelectionChangeCommitted(this,null);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            timeRangeCb.SetLanguage();
            timeScaleCb.SetLanguage();
        }
        public delegate void onDateAccept(object sender);
        public event onDateAccept myDateAccept = null;
        public void LoadData()
        {
            timeScaleCb.LoadData();
            timeRangeCb.LoadData();
        }
        public commonClass.AppTypes.TimeRanges  myTimeRange
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
        public commonClass.AppTypes.TimeScale myTimeScale
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
        public DateTime StartDate
        {
            get 
            {
                return timeRangeCb.StartDate;
            }
        }
        public DateTime EndDate
        {
            get
            {
                timeRangeCb.GetDate();
                return timeRangeCb.EndDate;
            }
        }
        public bool GetDate()
        {
            return timeRangeCb.GetDate();
        }
      

      
        private void timing_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.fLoaded) return;
            if (timeRangeCb.GetDate())
            {
                if (myDateAccept != null) myDateAccept(this);
            }
        }
    }
}