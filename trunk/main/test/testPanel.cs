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
    public partial class testPanel : Form
    {
        public testPanel()
        {
            InitializeComponent();
            locationLbl.Text = 
                "TL(" + tlBtn.Location.X.ToString() + "," + tlBtn.Location.Y.ToString() + ") " +
                "TR(" + trBtn.Location.X.ToString() + "," + trBtn.Location.Y.ToString() + ") " +
                "BL(" + blBtn.Location.X.ToString() + "," + blBtn.Location.Y.ToString() + ") " +
                "BR(" + brBtn.Location.X.ToString() + "," + brBtn.Location.Y.ToString() + ")"; 

        }

        private void baseComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch(baseComboBox1.SelectedIndex)
            {
                case 0 : basePanel1.myIconLocations = common.control.basePanel.IconLocations.TopLeft; break;
                case 1: basePanel1.myIconLocations = common.control.basePanel.IconLocations.TopRight; break;
                case 2: basePanel1.myIconLocations = common.control.basePanel.IconLocations.BottomLeft; break;
                case 3: basePanel1.myIconLocations = common.control.basePanel.IconLocations.BottomRight; break;
                default: basePanel1.myIconLocations = common.control.basePanel.IconLocations.None; break;  
            }
            basePanel1.isExpanded = false;
        }
    }
}
