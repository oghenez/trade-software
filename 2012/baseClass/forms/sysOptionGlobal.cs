using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;
using commonClass;

namespace baseClass.forms
{
    public partial class sysOptionGlobal : baseClass.forms.baseForm
    {
        public sysOptionGlobal()
        {
            try
            {
                InitializeComponent();

                mainTab.SendToBack();
                systemTab.SendToBack();

                sysDataKeyPrefixEd.maxlen = 2;
                sysDataKeyPrefixEd.isToUpperCase = true;
                smtpPortEd.BackColor = common.Settings.sysColorDisableBG;

                defaLanguageCb.LoadData();
                accessLogMediaCb.LoadData();
                defaTimeRangeCb.LoadData();
                defaTimeScaleCb.LoadData();
                screenTimeRangeCb.LoadData();
                screenTimeScaleCb.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void LoadSettings()
        {
            //General
            accessLogMediaCb.myValue = Settings.sysGlobal.WriteLogAccess;
            passwordMinLenEd.Value = Settings.sysGlobal.PasswordMinLen;
            useStrongPassChk.Checked = Settings.sysGlobal.UseStrongPassword;

            //Auto number
            sysDataKeyPrefixEd.Text = Settings.sysGlobal.DataKeyPrefix;
            sysAutoDataKeySizeEd.myValue = Settings.sysGlobal.DataKeySize;
            sysAutoEditKeySizeEd.myValue = Settings.sysGlobal.AutoEditKeySize;
            timeOutAutoKeyEd.Value = Settings.sysGlobal.TimeOut_AutoKey;

            //email
            smtpServerEd.Text = Settings.sysGlobal.smtpAddress;
            smtpPortEd.Text = Settings.sysGlobal.smtpPort.ToString();
            smtpAuthAccountEd.Text = (Settings.sysGlobal.smtpAuthAccount == null ? "" : Settings.sysGlobal.smtpAuthAccount);
            smtpAuthPasswordEd.Text = (Settings.sysGlobal.smtpAuthPassword == null ? "" : Settings.sysGlobal.smtpAuthPassword);
            smtpSSLChk.Checked = Settings.sysGlobal.smtpSSL;

            //Default
            defaLanguageCb.myValue = Settings.sysGlobal.DefautLanguage;
            defaTimeRangeCb.myValue = Settings.sysGlobal.DefaultTimeRange;
            defaTimeScaleCb.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);

            screenDataCounEd.Value = Settings.sysGlobal.ScreeningDataCount;
            screenTimeScaleCb.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode);

            //sysSettins
            timerUnitEd.myValue = Settings.sysGlobal.TimerUnitInSecs;
            timerUnitToAutoCheckEd.myValue = Settings.sysGlobal.TimerUnitToAutoCheck;
            dayScanForLastPriceEd.myValue = Settings.sysGlobal.DayScanForLastPrice;

            chartMaxLoadFirstEd.myValue = Settings.sysGlobal.ChartMaxLoadCount_FIRST ;
            chartMaxLoadNextEd.myValue = Settings.sysGlobal.ChartMaxLoadCount_MORE ;
        }
        private void SaveSettings()
        {
            //General
            Settings.sysGlobal.WriteLogAccess = accessLogMediaCb.myValue;
            Settings.sysGlobal.PasswordMinLen = (byte)passwordMinLenEd.Value;
            Settings.sysGlobal.UseStrongPassword = useStrongPassChk.Checked;

            //Auto number
            Settings.sysGlobal.DataKeyPrefix = sysDataKeyPrefixEd.Text;
            Settings.sysGlobal.DataKeySize = (byte)sysAutoDataKeySizeEd.Value;
            Settings.sysGlobal.AutoEditKeySize = (byte)sysAutoEditKeySizeEd.Value;
            Settings.sysGlobal.TimeOut_AutoKey = (int)timeOutAutoKeyEd.Value;

            //Email
            Settings.sysGlobal.smtpAddress = smtpServerEd.Text.Trim();
            int port = 25; int.TryParse(smtpPortEd.Text,out port);
            Settings.sysGlobal.smtpPort = port;
            Settings.sysGlobal.smtpAuthAccount = (smtpAuthAccountEd.Text.Trim() == "" ? "" : smtpAuthAccountEd.Text.Trim());
            Settings.sysGlobal.smtpAuthPassword = (smtpAuthPasswordEd.Text.Trim() == "" ? "" : smtpAuthPasswordEd.Text.Trim());
            Settings.sysGlobal.smtpSSL = smtpSSLChk.Checked;

            //Default
            Settings.sysGlobal.DefautLanguage = defaLanguageCb.myValue;
            Settings.sysGlobal.DefaultTimeRange = defaTimeRangeCb.myValue;
            Settings.sysGlobal.DefaultTimeScaleCode = defaTimeScaleCb.myValue.Code;

            Settings.sysGlobal.ScreeningDataCount = (int)screenDataCounEd.Value;
            Settings.sysGlobal.ScreeningTimeScaleCode = screenTimeScaleCb.myValue.Code;

            //Timing
            Settings.sysGlobal.TimerUnitInSecs = (short)timerUnitEd.myValue;
            Settings.sysGlobal.TimerUnitToAutoCheck = (short)timerUnitToAutoCheckEd.myValue;
            Settings.sysGlobal.DayScanForLastPrice = (short)dayScanForLastPriceEd.myValue;

            Settings.sysGlobal.ChartMaxLoadCount_FIRST = (short)chartMaxLoadFirstEd.myValue;
            Settings.sysGlobal.ChartMaxLoadCount_MORE = (short)chartMaxLoadNextEd.myValue;

            DataAccess.Libs.Save_Global_Settings();
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("sysOptions");

            systemPg.Text = Languages.Libs.GetString("system");
            generalPg.Text = Languages.Libs.GetString("generalInfo");

            accessLogMediaLbl.Text = Languages.Libs.GetString("logAccessTo");
            pwdMinLenLbl.Text = Languages.Libs.GetString("pwdMinLen");
            pwdCharLbl.Text = Languages.Libs.GetString("character");
            useStrongPassChk.Text = Languages.Libs.GetString("useStrongPass");

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

            defaultPg.Text = Languages.Libs.GetString("defaultStr");
            defaultGb.Text = Languages.Libs.GetString("defaultStr");
            defaLanguageLbl.Text = Languages.Libs.GetString("language");
            defaTimeRangeLbl.Text = Languages.Libs.GetString("timeRange");
            defaTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");

            screeningGb.Text = Languages.Libs.GetString("screening");
            screenDataCounLbl.Text = Languages.Libs.GetString("dataCount");
            screenTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");

            sysSettingPg.Text = Languages.Libs.GetString("sysSetting");
            timerUnitLbl.Text = Languages.Libs.GetString("timerUnit");
            secondLbl2.Text = Languages.Libs.GetString("seconds");
            timerUnitToAutoCheckLbl.Text = Languages.Libs.GetString("autoCheckAfter");
            noTimerUnitLbl.Text = Languages.Libs.GetString("noTimerUnit");

            dayScanForLastPriceLbl.Text = Languages.Libs.GetString("dayScanForLastPrice");
            dayLbl.Text = Languages.Libs.GetString("days");

            chartMaxLoadFirstLbl.Text = Languages.Libs.GetString("chartMaxLoadFIRST");
            chartMaxLoadNextLbl.Text = Languages.Libs.GetString("chartMaxLoadNEXT");
            barLbl1.Text = Languages.Libs.GetString("bars");
            barLbl2.Text = Languages.Libs.GetString("bars");
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
        private void Form_Load(object sender, EventArgs e)
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
