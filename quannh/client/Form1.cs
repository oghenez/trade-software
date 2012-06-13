 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking; 

namespace client
{
    public partial class Form1 : Form
    {
        FormA formA = new FormA();
        FormB formB = new FormB();
        FormA formC = new FormA();
        FormB formD = new FormB();
        ///test
        ///
        public Form1()
        {
            InitializeComponent();
            dockPanel.Visible = true;
            dockPanel.BringToFront();
            formA.Show(dockPanel, DockState.DockLeft);
            formB.Show(dockPanel, DockState.DockLeft);

            formC.Show(dockPanel);
            formD.Show(dockPanel);
            dockPanel.ResumeLayout(true, true);
        }
    }
}
