using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonClass;

namespace baseClass.forms
{
    public partial class investorLogin : baseForm
    {
        public bool isLoginOk = false;
        public investorLogin()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = false;
               
        }
        /**Author: NGUYEN TUAN
           * add key press. when user press enter, automatically, user log in to system
           */     
        /// <summary>
        /// Key events on form. when user press enter, automatically, user log in to system
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="keyData">Key data </param>    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.passwordEd.Focused&&keyData.Equals(Keys.Enter))
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
                    this.ShowError(er);
                    common.system.ShowErrorMessage(Languages.Libs.GetString("systemError"));
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("login");
            accountLbl.Text = Languages.Libs.GetString("account");
            passwordLbl.Text = Languages.Libs.GetString("password");

            loginBtn.Text = Languages.Libs.GetString("login");
            configBtn.Text = Languages.Libs.GetString("configure");
            exitBtn.Text = Languages.Libs.GetString("exit");
        }

        private void userLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.accountEd.Text = commonClass.SysLibs.sysLoginAccount;
            }
            catch( Exception er)
            {
                this.ShowError(er);
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
                this.ShowError(er);
                common.system.ShowErrorMessage(Languages.Libs.GetString("systemError")); 
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
            databases.baseDS.investorDataTable investorTbl = DataAccess.Libs.GetInvestor_ByAccount(account);
            if (investorTbl==null)
                throw new Exception("investor table cannot be connected");

            if (investorTbl.Count==0)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("invalidLogin"));
                return false;
            }
            if (investorTbl[0].password.Trim() != password.Trim())
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("invalidLogin"));
                return false;
            }
            if (!commonClass.SysLibs.isSupperAdminLogin(investorTbl[0].account) &&
                 investorTbl[0].expireDate < DataAccess.Libs.GetServerDateTime())
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("accountExpired"));
                return false;
            }
            commonClass.SysLibs.sysLoginCode = investorTbl[0].code.Trim();
            commonClass.SysLibs.sysLoginAccount = investorTbl[0].account.Trim();
            commonClass.SysLibs.sysLoginDisplayName = investorTbl[0].displayName.Trim();
            commonClass.SysLibs.sysLoginType = (commonTypes.AppTypes.UserTypes)investorTbl[0].type;
            return true;
        }

        private void userLogin_Activated(object sender, EventArgs e)
        {
            if (this.accountEd.Text.Trim() != "") this.passwordEd.Focus();
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.configure form = new baseClass.forms.configure();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
                common.system.ShowErrorMessage(Languages.Libs.GetString("systemError")); 
            }
        }
    }
}