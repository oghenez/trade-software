﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace test
{
    public partial class test : common.forms.baseForm
    {
        public test()
        {
            InitializeComponent();
        }
        string xmlFile = "D:\\work\\stockProject\\code\\dlls\\user.xml";
        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                // Load the document and set the root element.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFile);
                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes(codeEd.Text);

                string tmp = common.xmlLibs.GetXML(xmlDoc, codeEd.Text, "sysChartShowDescription");
            }
            catch(Exception er)
            { 
                this.ShowError(er);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
