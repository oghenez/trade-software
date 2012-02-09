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
                smtpPortEd.BackColor = common.Settings.sysColorDisableBG;
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
            defaultTimeRangeCb.myValue = Settings.sysDefaultTimeRange;
            defaultTimeScaleCb.myValue = Settings.sysDefaultTimeScale;

            //??screenTimeRangeCb.myValue = Settings.sysScreeningDataCount ;
            screenTimeScaleCb.myValue = Settings.sysScreeningTimeScale;

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
            Settings.sysDefaultTimeRange = defaultTimeRangeCb.myValue;
            Settings.sysDefaultTimeScale = defaultTimeScaleCb.myValue;

            //??Settings.sysScreeningTimeRange = screenTimeRangeCb.myValue;
            Settings.sysScreeningTimeScale = screenTimeScaleCb.myValue;


            DataAccess.Libs.Save_Global_Settings();
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("option");

            systemPg.Text = Languages.Libs.GetString("system");
            
            generalPg.Text = Languages.Libs.GetString("general");
            cultureCodeLbl.Text = Languages.Libs.GetString("cultureCode");
            percentMaskLbl.Text = Languages.Libs.GetString("percent");
            pwdMinLenLbl.Text = Languages.Libs.GetString("pwdMinLen");
            pwdCharLbl.Text = Languages.Libs.GetString("pwdChar");
            useStrongPassChk.Text = Languages.Libs.GetString("useStrongPass");
            debugModeChk.Text = Languages.Libs.GetString("debugMode");

            autoKeyPg.Text = Languages.Libs.GetString("autoKey");
            dataKeyPrefixLbl.Text = Languages.Libs.GetString("dataKeyPrefix");
            sysAutoDataKeySizeLbl.Text = Languages.Libs.GetString("sysAutoDataKeySize");
            timeOutAutoKeyLbl.Text = Languages.Libs.GetString("timeOutAutoKey");
            secondLbl.Text = Languages.Libs.GetString("second");

            formatPg.Text = Languages.Libs.GetString("format");
            localAmtMaskLbl.Text = Languages.Libs.GetString("localAmtMask");
            foreignAmtMaskLbl.Text = Languages.Libs.GetString("foreignAmtMask");
            qtyMaskLbl.Text = Languages.Libs.GetString("qtyMask");
            percentMaskLbl.Text = Languages.Libs.GetString("percentMask");

            emailPg.Text = Languages.Libs.GetString("email");
            smtpServerLbl.Text = Languages.Libs.GetString("smtpServer");
            smtpAuthAccountLbl.Text = Languages.Libs.GetString("account");
            smtpAuthPasswordLbl.Text = Languages.Libs.GetString("password");
            smtpPortLbl.Text = Languages.Libs.GetString("smtpPort");
            smtpSSLChk.Text = Languages.Libs.GetString("smtpSSL");

            paramsPg.Text = Languages.Libs.GetString("params");
            defaultGb.Text = Languages.Libs.GetString("default");
            defaTimeRangeLbl.Text = Languages.Libs.GetString("timeRange");
            defaTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");

            screeningGb.Text = Languages.Libs.GetString("screening");
            screenDataCounLbl.Text = Languages.Libs.GetString("dataCount");
            screenTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");
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

    }
}
