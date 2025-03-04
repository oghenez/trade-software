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

namespace baseClass.forms
{
    public partial class configure : baseForm
    {
        public configure()
        {
            try
            {
                InitializeComponent();
                configureTab.SendToBack();
                fShowError = false;
                toolBarPnl.BorderStyle = BorderStyle.None;
                errorPnl.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            wsConnection.SetLanguage();
            this.Text = Languages.Libs.GetString("configure");

            connectionPg.Text = Languages.Libs.GetString("connection");
            checkConnBtn.Text = Languages.Libs.GetString("test");

            optionPage.Text = Languages.Libs.GetString("option");
            imgFileGb.Text = Languages.Libs.GetString("imageFile");
            bgImgFileLbl.Text = Languages.Libs.GetString("background");
            iconImgFileLbl.Text = Languages.Libs.GetString("icon");
            logoImgFileLbl1.Text = Languages.Libs.GetString("logo") + " 1";
            logoImgFileLbl2.Text = Languages.Libs.GetString("logo") + " 2";

            saveBtn.Text = Languages.Libs.GetString("save");
            exitBtn.Text = Languages.Libs.GetString("close");
        }
        bool fShowError
        {
            get 
            {
                return errorPnl.Visible;
            }
            set 
            {
                errorPnl.Visible = value;
                errorPnl.BringToFront();
                errorPnl.Height = 150;
                if (value) configureTab.Height = errorPnl.Location.Y + errorPnl.Height;
                else configureTab.Height = toolBarPnl.Location.Y + toolBarPnl.Height + SystemInformation.CaptionHeight + 3;
                this.Height = configureTab.Height + configureTab.Location.Y + 2 * SystemInformation.CaptionHeight-5;
            }
        }

        private void ReadConfiguration()
        {
            application.Configuration.Load_Local_Settings();
            //General settings

            this.logoImgFileEd1.Text = common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathCompanyLogo1);
            this.logoImgFileEd2.Text = common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathCompanyLogo2);

            this.iconImgFileEd.Text = common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathIcon);
            this.bgImgFileEd.Text = common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathBackGround);

            //Connection
            wsConnection.myInfo = common.configuration.GetWebServiceInfo();
        }

        private void SaveConfiguration()
        {
            // User settings
            commonClass.SysLibs.sysImgFilePathIcon =  this.iconImgFileEd.Text.Trim();
            commonClass.SysLibs.sysImgFilePathBackGround = this.bgImgFileEd.Text.Trim();
            commonClass.SysLibs.sysImgFilePathCompanyLogo1 = this.logoImgFileEd1.Text.Trim();
            commonClass.SysLibs.sysImgFilePathCompanyLogo2 = this.logoImgFileEd2.Text.Trim();
           
            //Save configuration
            application.Configuration.Save_Local_Settings();
            common.configuration.SaveWebServiceInfo(wsConnection.myInfo);
        }

        private string SelectImgFile(string extFilter)
        {
            openFileDialog.Filter = extFilter;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                SaveConfiguration();
                this.ShowMessage(Languages.Libs.GetString("dataSaved"));
                this.Close();
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        
        private void iconImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("Icon(*.ico)|*.ico;| Tat ca(*.*)|*.*");
        }

        private void bgImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("JPEG (*.JPG,*.JPEG)|*.JPG;*.JPEG|GIF(*.GIF)|*.GIF|Tat ca(*.*)|*.*");
        }

        private void logoImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void logoImgFileEd2_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void configure_Load(object sender, EventArgs e)
        {
            try
            {
                ReadConfiguration();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }            
        }

        private void checkConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (wsConnection.myInfo == null)
                {
                    return;
                }
                toolBarPnl.Enabled = false;
                string errorMsg = "";
                if (DataAccess.Libs.TestConnection(wsConnection.myInfo, out errorMsg))
                {
                    this.ShowMessage(Languages.Libs.GetString("connectionOk"));
                    errorMsgEd.Text = "";
                    fShowError = false;
                }
                else
                {
                    this.ShowMessage(Languages.Libs.GetString("connectionFail"));
                    errorMsgEd.Text = errorMsg;
                    fShowError = true;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                toolBarPnl.Enabled = true;
            }
        }

        private bool errorPnl_myOnClosing(object sender)
        {
            fShowError = false;
            return true;
        }
    }
}