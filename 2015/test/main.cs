using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class main : common.forms.baseApplication
    {
        public main()
        {
            InitializeComponent();
            //databases.SysLibs.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
        }

        static chartTest chartTestForm = null;
        private void chartTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (chartTestForm == null || chartTestForm.IsDisposed) chartTestForm = new chartTest();
                chartTestForm.Show();
                chartTestForm.Activate();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        static genData genDataForm = null;
        private void genDataBtn_Click(object sender, EventArgs e)
        {
            if (genDataForm == null || genDataForm.IsDisposed) genDataForm = new genData();
            genDataForm.Show();
            genDataForm.Activate();
        }

        static paneTest paneTestForm = null;
        private void pannelTestBtn_Click(object sender, EventArgs e)
        {
            if (paneTestForm == null || paneTestForm.IsDisposed) paneTestForm = new paneTest();
            paneTestForm.Show();
            paneTestForm.Activate();
        }

        static misc testForm = null;
        private void miscBtn_Click(object sender, EventArgs e)
        {
            if (testForm == null || testForm.IsDisposed) testForm = new misc();
            testForm.Show();
            testForm.Activate();
        }

        static mthread mthreadForm = null;
        private void threadingBtn_Click(object sender, EventArgs e)
        {
            if (mthreadForm == null || mthreadForm.IsDisposed) mthreadForm = new mthread();
            mthreadForm.Show();
            mthreadForm.Activate();
        }

        static stressTest stressTestForm = null;
        private void stressTestBtn_Click(object sender, EventArgs e)
        {
             if (stressTestForm == null || stressTestForm.IsDisposed) stressTestForm = new stressTest();
            stressTestForm.Show();
            stressTestForm.Activate();
        }
    }
}
