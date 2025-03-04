using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO; 
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace setup.forms
{
    public partial class configFile : common.forms.baseForm
    {
        public configFile()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.openFileDialog.ShowDialog() != DialogResult.OK) return;
                fileConfEd.Text = this.openFileDialog.FileName;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
                common.system.ShowMessage("Lưu dữ liệu gặp lỗi");
            }
        }

        private void checkConnBtn_Click(object sender, EventArgs e)
        {
            string saveConfFile  = common.settings.sysConfigFile;
            common.settings.sysConfigFile = fileConfEd.Text;
            try
            {
                common.configuration.dbConnectionInfo dbConInfo = common.configuration.GetDbConectionInfo();
                string tmp = common.database.BuidConnectionString(dbConInfo);
                string errorMsg = "";
                if (common.database.CheckDbConnection(tmp, out errorMsg))
                {
                    common.system.ShowMessage("Kết nối thành công đến máy chủ");
                }
                else
                {
                    common.system.ShowErrorMessage("Không thể kết nối đến máy chủ");
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally 
            {
                common.settings.sysConfigFile = saveConfFile;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            common.settings.sysConfigFile = fileConfEd.Text;
            application.dataLibs.ClearDbConnection();
            this.Close();
        }      
    }
}