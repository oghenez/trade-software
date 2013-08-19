using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProcessing;
using ReportGUI.Properties;
using System.Globalization;
using commonTypes;

namespace ReportGUI
{
    public partial class FrmReportMain : Form
    {
        public FrmReportMain()
        {
            InitializeComponent();
            CultureInfo newCulture = AppTypes.Code2Culture(commonTypes.AppTypes.LanguageCodes.VI);

            common.language.myCulture = newCulture;          
            common.language.SetLanguage();
            commonClass.SysLibs.SetLanguage();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            WordReportProcessing w = new WordReportProcessing();
            w.executeDocument("Templates\\test.docx");
            MessageBox.Show("Sucessful!!!");
        }
    }
}
