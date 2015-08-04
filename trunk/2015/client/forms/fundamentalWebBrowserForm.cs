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
        string sURL = "";
        string sCompanyName = "";
        string sText = "";
        public fundamentalWebBrowserForm()
        {
            InitializeComponent();
        }
        public fundamentalWebBrowserForm(string _companyName,string _URL, string _text)
        {
            InitializeComponent();
            sCompanyName = _companyName;
            sURL = _URL;
            sText = _text;
            webBrowser.ScriptErrorsSuppressed = true;
        }

        private void fundamentalWebBrowserForm_Load(object sender, EventArgs e)
        {            
            webBrowser.Navigate(sURL);
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = Languages.Libs.GetString("navigatingTo")+" "+Languages.Libs.GetString(sText)+" "+sCompanyName;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = Languages.Libs.GetString(sText) + "-" + sCompanyName;
        }

        public override void SetLanguage()
        {            
            this.Text = Languages.Libs.GetString(sText) + "-" + sCompanyName;            
        }
    }
}
