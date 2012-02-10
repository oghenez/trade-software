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
            //General
            passwordMinLenEd.Value = Settings.sysGlobal.PasswordMinLen;
            useStrongPassChk.Checked = Settings.sysGlobal.UseStrongPassword;
            debugModeChk.Checked = Settings.sysGlobal.DebugMode;

            //Auto number
            sysDataKeyPrefixEd.Text = Settings.sysGlobal.DataKeyPrefix;
            sysAutoDataKeySizeEd.myValue = Settings.sysGlobal.DataKeySize;
            sysAutoEditKeySizeEd.myValue = Settings.sysGlobal.AutoEditKeySize;
            timeOutAutoKeyEd.Value = Settings.sysGlobal.TimeOut_AutoKey;

            //email
            smtpServerEd.Text = common.sendMail.mySettings.smtpAddress;
            smtpPortEd.Text = common.sendMail.mySettings.smtpPort.ToString();
            smtpAuthAccountEd.Text = (common.sendMail.mySettings.authAccount == null ? "" : common.sendMail.mySettings.authAccount);
            smtpAuthPasswordEd.Text = (common.sendMail.mySettings.authPassword == null ? "" : common.sendMail.mySettings.authPassword);
            smtpSSLChk.Checked = common.sendMail.mySettings.smtpSSL;

            //Params
            defaultTimeRangeCb.myValue = Settings.sysGlobal.DefaultTimeRange;
            defaultTimeScaleCb.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);

            screenDataCounEd.Value = Settings.sysGlobal.ScreeningDataCount;
            screenTimeScaleCb.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode);

        }
        private void SaveSettings()
        {
            //General
            Settings.sysGlobal.PasswordMinLen = (byte)passwordMinLenEd.Value;
            Settings.sysGlobal.UseStrongPassword = useStrongPassChk.Checked;
            Settings.sysGlobal.DebugMode = debugModeChk.Checked;

            //Auto number
            Settings.sysGlobal.DataKeyPrefix = sysDataKeyPrefixEd.Text;
            Settings.sysGlobal.DataKeySize = (byte)sysAutoDataKeySizeEd.Value;
            Settings.sysGlobal.AutoEditKeySize = (byte)sysAutoEditKeySizeEd.Value;
            Settings.sysGlobal.TimeOut_AutoKey = (int)timeOutAutoKeyEd.Value;

            //Email
            common.sendMail.mySettings.smtpAddress = smtpServerEd.Text.Trim();
            int port = 25; int.TryParse(smtpPortEd.Text,out port);
            common.sendMail.mySettings.smtpPort = port;
            common.sendMail.mySettings.authAccount = (smtpAuthAccountEd.Text.Trim() == "" ? "" : smtpAuthAccountEd.Text.Trim());
            common.sendMail.mySettings.authPassword = (smtpAuthPasswordEd.Text.Trim() == "" ? "" : smtpAuthPasswordEd.Text.Trim());
            common.sendMail.mySettings.smtpSSL = smtpSSLChk.Checked;

            //Params
            Settings.sysGlobal.DefaultTimeRange = defaultTimeRangeCb.myValue;
            Settings.sysGlobal.DefaultTimeScaleCode = defaultTimeScaleCb.myValue.Code;

            Settings.sysGlobal.ScreeningDataCount = (int)screenDataCounEd.Value;
            Settings.sysGlobal.ScreeningTimeScaleCode = screenTimeScaleCb.myValue.Code;


            DataAccess.Libs.Save_Global_Settings();
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("sysOptions");

            systemPg.Text = Languages.Libs.GetString("system");

            generalPg.Text = Languages.Libs.GetString("generalInfo");
            pwdMinLenLbl.Text = Languages.Libs.GetString("pwdMinLen");
            pwdCharLbl.Text = Languages.Libs.GetString("character");
            useStrongPassChk.Text = Languages.Libs.GetString("useStrongPass");
            debugModeChk.Text = Languages.Libs.GetString("debugMode");

            autoKeyPg.Text = Languages.Libs.GetString("autoKey");
            dataKeyPrefixLbl.Text = Languages.Libs.GetString("dataKeyPrefix");
            sysAutoDataKeySizeLbl.Text = Languages.Libs.GetString("sysAutoDataKeySize");
            timeOutAutoKeyLbl.Text = Languages.Libs.GetString("timeOutAutoKey");
            secondLbl.Text = Languages.Libs.GetString("second");

            emailPg.Text = Languages.Libs.GetString("email");
            smtpServerLbl.Text = Languages.Libs.GetString("smtpServer");
            smtpAuthAccountLbl.Text = Languages.Libs.GetString("account");
            smtpAuthPasswordLbl.Text = Languages.Libs.GetString("password");
            smtpPortLbl.Text = Languages.Libs.GetString("smtpPort");
            smtpSSLChk.Text = Languages.Libs.GetString("smtpSSL");

            paramsPg.Text = Languages.Libs.GetString("parameter");
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
