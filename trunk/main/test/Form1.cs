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
using System.Resources;
using System.Globalization;
using System.IO;
using application;

namespace test
{
    //public partial class Form1 : Form
    public partial class Form1 : common.forms.configureDb 
    {
        public Form1()
        {
            application.test.LoadTestConfig();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            common.language.myCulture = CultureInfo.CreateSpecificCulture("en-US");
            SetLanguage();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            common.language.myCulture = CultureInfo.CreateSpecificCulture("vi-VN");
            SetLanguage();
        }

    }
}
