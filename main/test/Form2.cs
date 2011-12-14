using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            string tmp = "0.02",tmp1;
            decimal d = 0;

            common.language.myCulture = new System.Globalization.CultureInfo("vi-VN");
            decimal.TryParse(tmp, out d); 
            tmp1 = d.ToString();

            common.language.myCulture = new System.Globalization.CultureInfo("en-US");
            decimal.TryParse(tmp, out d);
            tmp1 = d.ToString();
        }
    }
}
