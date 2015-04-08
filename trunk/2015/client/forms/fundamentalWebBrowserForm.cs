using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    public partial class fundamentalWebBrowserForm : baseClass.forms.baseForm
    {
        string URL = "";
        string companyName = "";
        public fundamentalWebBrowserForm()
        {
            InitializeComponent();
        }
        public fundamentalWebBrowserForm(string _companyName,string _URL)
        {
            InitializeComponent();
            companyName = _companyName;
            URL = _URL;
            webBrowser.ScriptErrorsSuppressed = true;
        }

        private void fundamentalWebBrowserForm_Load(object sender, EventArgs e)
        {            
            webBrowser.Navigate(URL);
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = "Navigating to "+companyName+" company data";
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text=companyName+" Fundamental Data";
        }

        public override void SetLanguage()
        {
            base.SetLanguage();            
        }
    }
}
