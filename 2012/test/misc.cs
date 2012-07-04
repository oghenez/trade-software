using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace test
{
    public partial class misc : common.forms.baseForm
    {
        public misc()
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

                string tmp = common.xmlLibs.GetXML(xmlDoc, codeEd.Text, "sysChartShowDescription",false);
            }
            catch(Exception er)
            { 
                this.ShowError(er);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stockSource.DataSource = DataAccess.Libs.myStockCodeTbl;
            //stockGV.ReadOnly = false;
            //stockGV.myQuickFindColumnId = 0;
            //stockGV.myUseQuickFind = true;
        }

        int i = 0;

        private void UpdateLabel(string text)
        {
            i++;
            text = text + i;
            if (this.codeEd.InvokeRequired)

                this.codeEd.Invoke((MethodInvoker)delegate()
                {
                    UpdateLabel(text + " invoked");
                });

            else this.codeEd.Text = text;
        }

        bool fRunning = false;
        private void FetchData()
        {
            try
            {
                if (fRunning)
                {
                    return;
                }
                fRunning = true;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational,""," - Start fetch Data ");
                server.libs.FetchRealTimeData(DateTime.Now);
                //Thread.Sleep(1000);
                fRunning = false;
            }
            catch
            {
                fRunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", " - Fetch Data error ");
            }

        }

        int timmerCount = 0;
        common.TimerProcess fetchDataTimer = new common.TimerProcess();
        private void button2_Click(object sender, EventArgs e)
        {
            //fetchDataTimer.WaitInSeconds = 5;
            //fetchDataTimer.OnProcess += new common.TimerProcess.OnProcessEvent(FetchData);
            //myTimer.Interval = 5000;
            //myTimer.Start();
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            //timmerCount++;
            //this.Text = timmerCount.ToString();
            //fetchDataTimer.Execute(true);
        }


        private void Test_click(object sender, EventArgs e)
        {
            DateTime dt = MSchwarz.Net.Ntp.NtpClient.GetNetworkTime("time.windows.com");
        }

    }
}
