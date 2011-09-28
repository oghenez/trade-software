using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using test;
using test1.Item;
using application;

namespace test1.Panel
{
    public partial class IndicatorPanel : UserControl
    {
        public MainForm _mFormParent = null;
        public IndicatorPanel()
        {
            InitializeComponent();               
            panelIndi.AutoScroll = true;
            panelIndi.HorizontalScroll.Visible = false;
        }
        public void InitData()
        {
            ////Indicator            
            //data.baseDS.indicatorDataTable indicatorTbl = new data.baseDS.indicatorDataTable();
            //dataLibs.LoadData(indicatorTbl, true);

            //List<string> lstIndicator = new List<string>();
            //foreach (var item in indicatorTbl)
            //{
            //    this.panelIndi.Controls.Add(new IndicatorItem { Caption = item.description,Mytooltip = item.description });
            //}       
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _mFormParent.leftPanel.Controls.Remove(this);
        }
    }
}
