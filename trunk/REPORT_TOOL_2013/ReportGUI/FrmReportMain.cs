using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProcessing;

namespace ReportGUI
{
    public partial class FrmReportMain : Form
    {
        public FrmReportMain()
        {
            InitializeComponent();                     
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            WordReportProcessing w = new WordReportProcessing();
            w.executeDocument("Templates\\test.docx");
            MessageBox.Show("Sucessful!!!");
        }
    }
}
