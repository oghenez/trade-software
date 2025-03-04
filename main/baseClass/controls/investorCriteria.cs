using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace baseClass.controls
{
    public partial class investorCriteria : common.controls.baseUserControl
    {
        private data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
        public investorCriteria()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            firstNameChk.Text = Languages.Libs.GetString("firstName");
            address1Chk.Text = Languages.Libs.GetString("address");
            phoneChk.Text = Languages.Libs.GetString("phone");
            countryChk.Text = Languages.Libs.GetString("nationality");
            catCodeChk.Text = Languages.Libs.GetString("category");
            countryCb.SetLanguage();
            catCodeCb.SetLanguage();
        }

        public void LoadData()
        {
            countryCb.LoadData();
            catCodeCb.LoadData();

        }

        public string GetCriteria()
        {
            return GetCriteria(investorTbl.TableName, false);
        }
        public string GetCriteria(string investorAlias, bool withUnicode)
        {
            string filter = "";
            if (this.firstNameChk.Checked && this.firstNameEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.firstNameColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.firstNameEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.address1Chk.Checked && this.address1Ed.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.address1Column.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.address1Ed.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.phoneChk.Checked && this.phoneEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.phoneColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.phoneEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.emailChk.Checked && this.emailEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.emailColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.emailEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.countryChk.Checked && this.countryCb.myValue != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.countryColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.countryCb.myValue.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.catCodeChk.Checked && this.catCodeCb.myValue != "")
                filter += (filter == "" ? "" : " AND ") + (investorAlias == "" ? "" : investorAlias + ".") + investorTbl.catCodeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.catCodeCb.myValue.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            return filter;
        }

        public string GetSQL()
        {
            string cond = GetCriteria("a", true);
            string sqlCmd = "SELECT a.* FROM investor a ";
            if (cond.Trim() != "") sqlCmd += " WHERE " + cond;
            return sqlCmd;
        }

        private void address1Chk_CheckedChanged(object sender, EventArgs e)
        {
            address1Ed.Enabled = address1Chk.Checked;
        }

        private void firstNameChk_CheckedChanged(object sender, EventArgs e)
        {
            firstNameEd.Enabled = firstNameChk.Checked;
        }

        private void countryChk_CheckedChanged(object sender, EventArgs e)
        {
            countryCb.Enabled = countryChk.Checked;
        }

        private void phoneChk_CheckedChanged(object sender, EventArgs e)
        {
            phoneEd.Enabled = phoneChk.Checked;
        }

        private void emailChk_CheckedChanged(object sender, EventArgs e)
        {
            emailEd.Enabled = emailChk.Checked;
        }

        private void catCodeChk_CheckedChanged(object sender, EventArgs e)
        {
            catCodeCb.Enabled = catCodeChk.Checked;
        }
    }
}