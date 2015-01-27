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
    public partial class paneTest : Form
    {
        public paneTest()
        {
            InitializeComponent();
            panneLocationEd.Text = 
                "TL(" + tlBtn.Location.X.ToString() + "," + tlBtn.Location.Y.ToString() + ") " +
                "TR(" + trBtn.Location.X.ToString() + "," + trBtn.Location.Y.ToString() + ") " +
                "BL(" + blBtn.Location.X.ToString() + "," + blBtn.Location.Y.ToString() + ") " +
                "BR(" + brBtn.Location.X.ToString() + "," + brBtn.Location.Y.ToString() + ")"; 

        }

        private void baseComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch(baseComboBox1.SelectedIndex)
            {
                case 0 : basePanel1.myIconLocations = common.controls.basePanel.IconLocations.TopLeft; break;
                case 1: basePanel1.myIconLocations = common.controls.basePanel.IconLocations.TopRight; break;
                case 2: basePanel1.myIconLocations = common.controls.basePanel.IconLocations.BottomLeft; break;
                case 3: basePanel1.myIconLocations = common.controls.basePanel.IconLocations.BottomRight; break;
                default: basePanel1.myIconLocations = common.controls.basePanel.IconLocations.None; break;  
            }
            basePanel1.isExpanded = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            container.Reset();
            pane1.mySizingOptions = common.controls.basePanel.SizingOptions.Left | common.controls.basePanel.SizingOptions.Right |
                                    common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom;

            pane2.mySizingOptions = common.controls.basePanel.SizingOptions.Left | common.controls.basePanel.SizingOptions.Right |
                                    common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom;

            pane3.mySizingOptions = common.controls.basePanel.SizingOptions.Left | common.controls.basePanel.SizingOptions.Right |
                                    common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom;


            pane4.mySizingOptions = common.controls.basePanel.SizingOptions.Left | common.controls.basePanel.SizingOptions.Right |
                                    common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom;

            pane5.mySizingOptions = common.controls.basePanel.SizingOptions.Left | common.controls.basePanel.SizingOptions.Right |
                                    common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom;

            pane6.mySizingOptions = common.controls.basePanel.SizingOptions.BottomLeft | common.controls.basePanel.SizingOptions.BottomRight |
                        common.controls.basePanel.SizingOptions.Top | common.controls.basePanel.SizingOptions.Bottom; 

            container.AddChild(pane1, "pane1");
            container.AddChild(pane2, "pane2");
            container.AddChild(pane3, "pane3");
            pane1.Visible = false;
            pane3.Visible = false;
            container.AddChild(pane4, "pane4");
            container.AddChild(pane5, "pane5");
            container.AddChild(pane6, "pane6");
            container.myPaneDimensionSpecs = new[,] { { 1, 10, 10, 10 }, { 2, 20, 30, 40 } };
            container.ArrangeChildren();
        }

        private void largerBtn_Click(object sender, EventArgs e)
        {
            pane1.Visible = true;
            container.Refresh();
            container.Width +=  common.system.Random(1,10);
            container.Height += common.system.Random(1, 8);
        }

        private void smallerBtn_Click(object sender, EventArgs e)
        {
            container.Width -=  common.system.Random(1,10);
            container.Height -= common.system.Random(1, 8);
        }

        private void pane3_Resize(object sender, EventArgs e)
        {
        }
    }
}
