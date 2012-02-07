using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace setup.forms
{
    public partial class sysOptionsSetup : baseClass.baseForm
    {
        public sysOptionsSetup()
        {
            try
            {
                InitializeComponent();
                currencyCb.LoadData();
                cbCompany.LoadData();
                cbProdCostMethod.LoadData();
                cbProdCostDistMethod.LoadData();
                cbAutoVoucheNoFormat.LoadData();
                autoItemCodeCreationCb.LoadData();
                sysDataKeyPrefixEd.maxlen = 2;
                sysDataKeyPrefixEd.isToUpperCase = true;
                smtpPortEd.BackColor = application.Settings.sysColorDisableBG;
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

            //Product cost
            cbProdCostMethod.myValue = application.Settings.sysProductCostMethod;
            cbProdCostDistMethod.myValue = application.Settings.sysProductCostDistMethod;

            //Format
            localAmtMaskEd.Text = application.Settings.sysLocalAmtMask;
            foreignAmtMaskEd.Text = application.Settings.sysForeignAmtMask;
            qtyMaskEd.Text = application.Settings.sysQtyMask;
            percentMaskEd.Text = application.Settings.sysPercentMask;

            foreignAmtPrecisionEd.Value = application.Settings.sysPrecisionForeign;
            localAmtPrecisionEd.Value = application.Settings.sysPrecisionLocal;
            qtyPrecisionEd.Value = application.Settings.sysPrecisionQty;
            percentPrecisionEd.Value = application.Settings.sysPrecisionPercentage;
            cbAutoVoucheNoFormat.myValue = application.Settings.sysAutoVoucherNoFormat;

            //email
            smtpServerEd.Text = common.sendMail.sysSendMailInfo.smtpAddress;
            smtpPortEd.Text  = common.sendMail.sysSendMailInfo.smtpPort.ToString();
            smtpAuthAccountEd.Text = (common.sendMail.sysSendMailInfo.authAccount==null?"":common.sendMail.sysSendMailInfo.authAccount);
            smtpAuthPasswordEd.Text = (common.sendMail.sysSendMailInfo.authPassword == null ? "" : common.sendMail.sysSendMailInfo.authPassword);
            smtpSSLChk.Checked = common.sendMail.sysSendMailInfo.smtpSSL;

            //Others
            dataStartDateEd.myDateTime = application.sysLibs.sysDataStartDate;
            currencyCb.myValue = application.Settings.sysMainCurrency;
            cbCompany.myValue = application.Settings.sysCompanyCodeMain;
            defauCompanyCodeEd.Text = application.Settings.sysCompanyCodeDefault;
            autoItemCodeCreationCb.myValue = application.Settings.sysDefaultProdLotItemOption;

            //Finnance report
            application.Settings.sysFinReport_ABS_AccNoList = ABS_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_ABS_AccNoDebtList = ABS_AccNoDebtListEd.Text.Trim();

            application.Settings.sysFinReport_BIR_AccNoList = BIR_AccNoListEd.Text.Trim();

            application.Settings.sysFinReport_CFD_AccNoList = CFD_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_CFI_AccNoList = CFI_AccNoListEd.Text.Trim();

            application.Settings.sysFinReport_FRE_AccNoList = FRE_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_FRE_AccNoDebtList = FRE_AccNoDebtListEd.Text.Trim();

            //Report
            this.repoSignerTitle_DirectorEd.Text = application.sysLibs.sysReportSignerTitle_Director;
            this.repoSignerTitle_ChiefAcctEd.Text= application.sysLibs.sysReportSignerTitle_ChiefAcct;
            this.repoSignerTitle_CashierEd.Text = application.sysLibs.sysReportSignerTitle_Cashier;
            this.repoSignerTitle_whManagerEd.Text = application.sysLibs.sysReportSignerTitle_WhManager;
            this.repoSignerTitle_CreatorEd.Text = application.sysLibs.sysReportSignerTitle_Creator;
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

            //Product cost
            application.Settings.sysProductCostMethod = cbProdCostMethod.myValue;
            application.Settings.sysProductCostDistMethod = cbProdCostDistMethod.myValue;

            //Format
            application.Settings.sysLocalAmtMask= localAmtMaskEd.Text;
            application.Settings.sysForeignAmtMask = foreignAmtMaskEd.Text;
            application.Settings.sysQtyMask = qtyMaskEd.Text;
            application.Settings.sysPercentMask = percentMaskEd.Text;

            application.Settings.sysPrecisionForeign = (byte)foreignAmtPrecisionEd.Value;
            application.Settings.sysPrecisionLocal = (byte)localAmtPrecisionEd.Value;
            application.Settings.sysPrecisionQty = (byte)qtyPrecisionEd.Value;
            application.Settings.sysPrecisionPercentage = (byte)percentPrecisionEd.Value;
            application.Settings.sysAutoVoucherNoFormat = cbAutoVoucheNoFormat.myValue;

            //Email
            common.sendMail.sysSendMailInfo.smtpAddress = smtpServerEd.Text.Trim();
            int port = 25; int.TryParse(smtpPortEd.Text,out port);
            common.sendMail.sysSendMailInfo.smtpPort = port;
            common.sendMail.sysSendMailInfo.authAccount = (smtpAuthAccountEd.Text.Trim() == "" ? "" : smtpAuthAccountEd.Text.Trim());
            common.sendMail.sysSendMailInfo.authPassword = (smtpAuthPasswordEd.Text.Trim() == "" ? "" : smtpAuthPasswordEd.Text.Trim());
            common.sendMail.sysSendMailInfo.smtpSSL = smtpSSLChk.Checked;

            //Others
            application.sysLibs.sysDataStartDate = dataStartDateEd.myDateTime;
            application.Settings.sysMainCurrency = currencyCb.myValue;
            application.Settings.sysCompanyCodeMain = cbCompany.myValue;
            application.Settings.sysCompanyCodeDefault = defauCompanyCodeEd.Text;
            application.Settings.sysDefaultProdLotItemOption = autoItemCodeCreationCb.myValue;

            //Finnance report
            application.Settings.sysFinReport_ABS_AccNoList = ABS_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_ABS_AccNoDebtList = ABS_AccNoDebtListEd.Text.Trim();

            application.Settings.sysFinReport_BIR_AccNoList = BIR_AccNoListEd.Text.Trim();

            application.Settings.sysFinReport_CFD_AccNoList = CFD_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_CFI_AccNoList = CFI_AccNoListEd.Text.Trim();

            application.Settings.sysFinReport_FRE_AccNoList = FRE_AccNoListEd.Text.Trim();
            application.Settings.sysFinReport_FRE_AccNoDebtList = FRE_AccNoDebtListEd.Text.Trim();


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
    }
}
