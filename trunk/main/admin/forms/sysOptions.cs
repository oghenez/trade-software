using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonClass;

namespace admin.forms
{
    public partial class sysOptions : baseClass.forms.baseForm
    {
        public sysOptions()
        {
            try
            {
                InitializeComponent();
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
            DataAccess.Libs.Load_Global_Settings();
            cultureCodeEd.myValue = Settings.sysCultureCode;
            passwordMinLenEd.Value = Settings.sysPasswordMinLen;
            useStrongPassChk.Checked = Settings.sysUseStrongPassword;
            debugModeChk.Checked = Settings.sysDebugMode;
            sysDataKeyPrefixEd.Text = Settings.sysDataKeyPrefix;

            sysAutoDataKeySizeEd.myValue = Settings.sysDataKeySize;
            sysAutoEditKeySizeEd.myValue = Settings.sysAutoEditKeySize;
            timeOutAutoKeyEd.Value = Settings.sysTimeOut_AutoKey;

            //Format
            localAmtMaskEd.Text = Settings.sysMaskLocalAmt;
            foreignAmtMaskEd.Text = Settings.sysMaskForeignAmt;
            qtyMaskEd.Text = Settings.sysMaskQty;
            percentMaskEd.Text = Settings.sysMaskPercent;

            foreignAmtPrecisionEd.Value = Settings.sysPrecisionForeign;
            localAmtPrecisionEd.Value = Settings.sysPrecisionLocal;
            qtyPrecisionEd.Value = Settings.sysPrecisionQty;
            percentPrecisionEd.Value = Settings.sysPrecisionPercentage;

            //email
            smtpServerEd.Text = common.sendMail.mySettings.smtpAddress;
            smtpPortEd.Text = common.sendMail.mySettings.smtpPort.ToString();
            smtpAuthAccountEd.Text = (common.sendMail.mySettings.authAccount == null ? "" : common.sendMail.mySettings.authAccount);
            smtpAuthPasswordEd.Text = (common.sendMail.mySettings.authPassword == null ? "" : common.sendMail.mySettings.authPassword);
            smtpSSLChk.Checked = common.sendMail.mySettings.smtpSSL;

            //Others
            dataStartDateEd.myDateTime = commonClass.SysLibs.sysDataStartDate;
        }
        private void SaveSettings()
        {
            Settings.sysCultureCode = cultureCodeEd.myValue;
            Settings.sysPasswordMinLen = (byte)passwordMinLenEd.Value;
            Settings.sysUseStrongPassword = useStrongPassChk.Checked;
            Settings.sysDebugMode = debugModeChk.Checked;
            Settings.sysDataKeyPrefix = sysDataKeyPrefixEd.Text;

            Settings.sysDataKeySize = (byte)sysAutoDataKeySizeEd.Value;
            Settings.sysAutoEditKeySize = (byte)sysAutoEditKeySizeEd.Value;
            Settings.sysTimeOut_AutoKey = (int)timeOutAutoKeyEd.Value;

            //Format
            Settings.sysMaskLocalAmt = localAmtMaskEd.Text;
            Settings.sysMaskForeignAmt = foreignAmtMaskEd.Text;
            Settings.sysMaskQty = qtyMaskEd.Text;
            Settings.sysMaskPercent = percentMaskEd.Text;

            Settings.sysPrecisionForeign = (byte)foreignAmtPrecisionEd.Value;
            Settings.sysPrecisionLocal = (byte)localAmtPrecisionEd.Value;
            Settings.sysPrecisionQty = (byte)qtyPrecisionEd.Value;
            Settings.sysPrecisionPercentage = (byte)percentPrecisionEd.Value;

            //Email
            common.sendMail.mySettings.smtpAddress = smtpServerEd.Text.Trim();
            int port = 25; int.TryParse(smtpPortEd.Text,out port);
            common.sendMail.mySettings.smtpPort = port;
            common.sendMail.mySettings.authAccount = (smtpAuthAccountEd.Text.Trim() == "" ? "" : smtpAuthAccountEd.Text.Trim());
            common.sendMail.mySettings.authPassword = (smtpAuthPasswordEd.Text.Trim() == "" ? "" : smtpAuthPasswordEd.Text.Trim());
            common.sendMail.mySettings.smtpSSL = smtpSSLChk.Checked;

            //Others
            commonClass.SysLibs.sysDataStartDate = dataStartDateEd.myDateTime;

            DataAccess.Libs.Save_Global_Settings();
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

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                DataAccess.Libs.ResetService();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
