using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class investorLogin : common.forms.baseForm
    {
        private data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
        public bool isLoginOk = false;
        public investorLogin()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = false;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("login");
            accountLbl.Text = language.GetString("account");
            passwordLbl.Text = language.GetString("password");

            loginBtn.Text = language.GetString("login");
            exitBtn.Text = language.GetString("exit");
        }

        private void userLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.accountEd.Text = application.sysLibs.sysLoginAccount;
            }
            catch( Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString()); 
            }
         }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                isLoginOk = false;
                if (DoLogin())
                {
                    isLoginOk = true;
                    this.Close();
                }
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString());
            }
        }

        public  bool DoLogin()
        {
            ClearNotifyError();
            string account = this.accountEd.Text.Trim();
            string password = this.passwordEd.Text.Trim();
            if (account == "")
            {
                NotifyError(accountLbl);
                return false;
            }
            investorTbl.Clear();
            application.dataLibs.LoadInvestorByAccount(investorTbl, account);
            if (investorTbl.Count==0)
            {
                common.system.ShowErrorMessage(language.GetString("invalidLogin"));
                return false;
            }
            if (investorTbl[0].password.Trim() != password.Trim())
            {
                common.system.ShowErrorMessage(language.GetString("invalidLogin"));
                return false;
            }
            if (!application.sysLibs.isSupperAdminLogin(investorTbl[0].account) && 
                 investorTbl[0].expireDate < application.sysLibs.GetServerDateTime())
            {
                common.system.ShowErrorMessage(language.GetString("accountExpired"));
                return false;
            }
            application.sysLibs.sysLoginCode = investorTbl[0].code.Trim();
            application.sysLibs.sysLoginAccount = investorTbl[0].account.Trim();
            return true;
        }

        private void userLogin_Activated(object sender, EventArgs e)
        {
            if (this.accountEd.Text.Trim() != "") this.passwordEd.Focus();
        }
    }
}