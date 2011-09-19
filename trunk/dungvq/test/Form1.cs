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
            application.test.LoadTestConfig();
            InitializeComponent();
            
            //dockPanel1.BringToFront();
            //dockPanel1.Parent = this;

            //contextMenu.Items.Clear();
            //ToolStripItem item =  contextMenu.Items.Add(AddMenuItem.Text);
            //item.Click += new System.EventHandler(AddMenuItem_Click);
        }

        private void TestMenuItem_Click(object sender, EventArgs e)
        {
            common.MultiValueString mvString = new common.MultiValueString();
            mvString.Add("aaa");
            mvString.Add("bbb");
            mvString.Add("ccc");
            mvString.Add("aaa");
            string tmp = mvString.myList[0];
            //mvString.Add("bbb");
            this.Text = mvString.myFormatString;

            //myDataSet.Clear();
            //dataLibs.LoadData(myDataSet.stockCode);
            //Tools.Forms.screening form = Tools.Forms.screening.GetForm();
            //form.ShowDialog();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            common.system.ShowMessage("Open");
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            common.system.ShowMessage("Add");
        }
    }
}
