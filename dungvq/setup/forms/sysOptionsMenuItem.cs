using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace setup.forms
{
    public partial class sysOptionsMenuItem : baseClass.forms.baseForm
    {
        public sysOptionsMenuItem()
        {
            try
            {
                InitializeComponent();
                currencyCb.LoadData();
                uploadModeCb.LoadData(); 
                sysDataKeyPrefixEd.maxlen = 2;
                sysDataKeyPrefixEd.isToUpperCase = true;
                smtpPortEd.BackColor = common.settings.sysColorDisableBG;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void LoadSettings()
        {
            application.configuration.Load_Sys_Settings();

            cultureCodeEd.myValue = application.Settings.sysCultureCode;
            passwordMinLenEd.Value = application.Settings.sysPasswordMinLen;
            useStrongPassChk.Checked = application.Settings.sysUseStrongPassword;
            debugModeChk.Checked = application.Settings.sysDebugMode;
            sysDataKeyPrefixEd.Text = application.Settings.sysDataKeyPrefix;

            sysAutoDataKeySizeEd.Value = application.Settings.sysDataKeySize;
            sysAutoEditKeySizeEd.Value = application.Settings.sysAutoEditKeySize;
            timeOutAutoKeyEd.Value = application.Settings.sysTimeOut_AutoKey;

            //Format
            localAmtMaskEd.Text = application.Settings.sysLocalAmtMask;
            foreignAmtMaskEd.Text = application.Settings.sysForeignAmtMask;
            qtyMaskEd.Text = application.Settings.sysQtyMask;
            percentMaskEd.Text = application.Settings.sysPercentMask;

            foreignAmtPrecisionEd.Value = application.Settings.sysPrecisionForeign;
            localAmtPrecisionEd.Value = application.Settings.sysPrecisionLocal;
            qtyPrecisionEd.Value = application.Settings.sysPrecisionQty;
            percentPrecisionEd.Value = application.Settings.sysPrecisionPercentage;

            //email
            smtpServerEd.Text = common.sendMail.mySettings.smtpAddress;
            smtpPortEd.Text = common.sendMail.mySettings.smtpPort.ToString();
            smtpAuthAccountEd.Text = (common.sendMail.mySettings.authAccount == null ? "" : common.sendMail.mySettings.authAccount);
            smtpAuthPasswordEd.Text = (common.sendMail.mySettings.authPassword == null ? "" : common.sendMail.mySettings.authPassword);
            smtpSSLChk.Checked = common.sendMail.mySettings.smtpSSL;

            //Others
            dataStartDateEd.myDateTime = application.sysLibs.sysDataStartDate;
            currencyCb.myValue = application.Settings.sysMainCurrency;

            //Report
            this.repoSignerTitle_DirectorEd.Text = application.sysLibs.sysReportSignerTitle_Director;
            this.repoSignerTitle_ChiefAcctEd.Text= application.sysLibs.sysReportSignerTitle_ChiefAcct;
            this.repoSignerTitle_CashierEd.Text = application.sysLibs.sysReportSignerTitle_Cashier;
            this.repoSignerTitle_whManagerEd.Text = application.sysLibs.sysReportSignerTitle_WhManager;
            this.repoSignerTitle_CreatorEd.Text = application.sysLibs.sysReportSignerTitle_Creator;


            //Upload
            uploadModeCb.myValue = application.sysLibs.sysUploadMethod;
            switch (application.sysLibs.sysUploadMethod)
            {
                case common.uploadMethod.HTTP:
                    uploadUrlEd.Text = application.sysLibs.sysUploadAddress;
                    uploadScriptFileEd.Text = application.sysLibs.sysUploadScriptFile;
                    uploadAccountEd.Text = application.sysLibs.sysUploadUser;
                    uploadPwdEd.Text = application.sysLibs.sysUploadPassword;
                    break;
                case common.uploadMethod.SharedFolder:
                    uploadScriptFileEd.Text = "";
                    uploadDataDirEd.Text = application.sysLibs.sysUploadAddress;
                    uploadAccountEd.Text = "";
                    uploadPwdEd.Text = "";
                    break;
                default:
                    uploadScriptFileEd.Text = "";
                    uploadDataDirEd.Text = "";
                    uploadAccountEd.Text = "";
                    uploadPwdEd.Text = "";
                    break;
            }
        }
        private void SaveSettings()
        {
            application.Settings.sysCultureCode = cultureCodeEd.myValue;
            application.Settings.sysPasswordMinLen = (byte)passwordMinLenEd.Value;
            application.Settings.sysUseStrongPassword = useStrongPassChk.Checked;
            application.Settings.sysDebugMode = debugModeChk.Checked;
            application.Settings.sysDataKeyPrefix = sysDataKeyPrefixEd.Text;

            application.Settings.sysDataKeySize = (byte)sysAutoDataKeySizeEd.Value;
            application.Settings.sysAutoEditKeySize = (byte)sysAutoEditKeySizeEd.Value;
            application.Settings.sysTimeOut_AutoKey = (int)timeOutAutoKeyEd.Value;

            //Format
            application.Settings.sysLocalAmtMask= localAmtMaskEd.Text;
            application.Settings.sysForeignAmtMask = foreignAmtMaskEd.Text;
            application.Settings.sysQtyMask = qtyMaskEd.Text;
            application.Settings.sysPercentMask = percentMaskEd.Text;

            application.Settings.sysPrecisionForeign = (byte)foreignAmtPrecisionEd.Value;
            application.Settings.sysPrecisionLocal = (byte)localAmtPrecisionEd.Value;
            application.Settings.sysPrecisionQty = (byte)qtyPrecisionEd.Value;
            application.Settings.sysPrecisionPercentage = (byte)percentPrecisionEd.Value;

            //Email
            common.sendMail.mySettings.smtpAddress = smtpServerEd.Text.Trim();
            int port = 25; int.TryParse(smtpPortEd.Text,out port);
            common.sendMail.mySettings.smtpPort = port;
            common.sendMail.mySettings.authAccount = (smtpAuthAccountEd.Text.Trim() == "" ? "" : smtpAuthAccountEd.Text.Trim());
            common.sendMail.mySettings.authPassword = (smtpAuthPasswordEd.Text.Trim() == "" ? "" : smtpAuthPasswordEd.Text.Trim());
            common.sendMail.mySettings.smtpSSL = smtpSSLChk.Checked;

            //Upload
            application.sysLibs.sysUploadMethod = uploadModeCb.myValue;
            switch(application.sysLibs.sysUploadMethod)
            {
                case common.uploadMethod.HTTP :
                     application.sysLibs.sysUploadAddress = uploadUrlEd.Text.Trim();
                     application.sysLibs.sysUploadScriptFile = uploadScriptFileEd.Text.Trim();
                     application.sysLibs.sysUploadUser = uploadAccountEd.Text.Trim();
                     application.sysLibs.sysUploadPassword = uploadPwdEd.Text.Trim();
                     break;
                case common.uploadMethod.SharedFolder: 
                     application.sysLibs.sysUploadAddress = uploadDataDirEd.Text.Trim();
                     application.sysLibs.sysUploadScriptFile = "";
                     application.sysLibs.sysUploadUser = "";
                     application.sysLibs.sysUploadPassword = "";
                     break;
                default:
                     application.sysLibs.sysUploadAddress = "";
                     application.sysLibs.sysUploadScriptFile = "";
                     application.sysLibs.sysUploadUser = "";
                     application.sysLibs.sysUploadPassword = "";
                     break;
            }


            //Others
            application.sysLibs.sysDataStartDate = dataStartDateEd.myDateTime;
            application.Settings.sysMainCurrency = currencyCb.myValue;

            //Report
            application.sysLibs.sysReportSignerTitle_Director = this.repoSignerTitle_DirectorEd.Text.Trim();
            application.sysLibs.sysReportSignerTitle_ChiefAcct = this.repoSignerTitle_ChiefAcctEd.Text.Trim();
            application.sysLibs.sysReportSignerTitle_Cashier = this.repoSignerTitle_CashierEd.Text.Trim();
            application.sysLibs.sysReportSignerTitle_WhManager = this.repoSignerTitle_whManagerEd.Text.Trim();
            application.sysLibs.sysReportSignerTitle_Creator = this.repoSignerTitle_CreatorEd.Text.Trim();

            application.configuration.Save_Sys_Settings();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                this.ShowMessage("Đã lưu các thông số.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void otherPg_Click(object sender, EventArgs e)
        {

        }
        private void paraSetup_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                LoadSettings();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void copyModeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            httpProtoGb.Enabled = uploadModeCb.myValue == common.uploadMethod.HTTP;
            fsCopyModeGb.Enabled = uploadModeCb.myValue == common.uploadMethod.SharedFolder;
            if (uploadScriptFileEd.Enabled && uploadScriptFileEd.Text.Trim() == "")  uploadScriptFileEd.Text = "upload.aspx";
        }

        private void showPassChk_CheckedChanged(object sender, EventArgs e)
        {
            uploadPwdEd.PasswordChar = (showPassChk.Checked ? (char)0 : '*');
        }
    }
}
