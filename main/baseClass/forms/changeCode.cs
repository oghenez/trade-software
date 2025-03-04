using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections; 

namespace application
{
    public partial class changeCode : common.forms.baseForm
    {
        public changeCode()
        {
            InitializeComponent();
        }

        private bool SelectOldCodeList()
        {
            string SQLCmd = "",condStr="";
            string code = oldCodeEd.Text.Trim();
            string desc = oldDescEd.Text.Trim();
            
            code = code.Trim();
            if (code != "") condStr += (condStr == "" ? "" : " AND ") + "(a.customerCode LIKE '" + code + Consts.SQL_CMD_ALL_MARKER + "')";
            desc = desc.Trim();
            if (desc != "") condStr += (condStr == "" ? "" : " AND ") + "(a.name LIKE N'" + desc + Consts.SQL_CMD_ALL_MARKER + desc + Consts.SQL_CMD_ALL_MARKER + "')";
            SQLCmd += " SELECT * FROM customer";
            if (condStr != "") SQLCmd += " WHERE " + condStr;
            try
            {
                DataSet reportDataSet = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLCmd, data.dataLibs.GetMasterConnectionString());
                dataAdapter.Fill(reportDataSet);
                common.myComboBoxItem item;
                for (int idx = 0; idx < reportDataSet.Tables[0].Rows.Count; idx++)
                {
                    item = new common.myComboBoxItem(reportDataSet.Tables[0].Rows[idx].ItemArray[0].ToString(),
                                                     reportDataSet.Tables[0].Rows[idx].ItemArray[1].ToString());
                    oldCodeLb.Items.Add(item);   
                }
                reportDataSet.Dispose(); dataAdapter.Dispose();
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
                return false;
            }
            return true;
        }
        private bool ChangeCodeCode()
        {
            try
            {
                common.myComboBoxItem item;
                ArrayList oldCodeList = new ArrayList();
                for (int idx=0;idx<oldCodeLb.SelectedItems.Count;idx++)
                {
                    item = (common.myComboBoxItem)oldCodeLb.SelectedItems[idx]; 
                    oldCodeList.Add(item.Value);
                }
                string condStr, SQLCmd;
                condStr = common.sysLibs.MakeConditionStr(oldCodeList, "custCode='", "'", " OR ");
                SQLCmd  = "UPDATE voucherDetails SET custCode='" + newCodeEd + "'" + " WHERE  " + condStr;

                condStr = common.sysLibs.MakeConditionStr(oldCodeList, "custCode='", "'", " OR ");
                SQLCmd += "\r\n" + "UPDATE voucherDetails SET dCustCode='" + newCodeEd + "'" + " WHERE  " + condStr;

                condStr = common.sysLibs.MakeConditionStr(oldCodeList, "custCode1='", "'", " OR ");
                SQLCmd += "\r\n" + "UPDATE voucher SET custCode1='" + newCodeEd + "'" + " WHERE  " + condStr;

                condStr = common.sysLibs.MakeConditionStr(oldCodeList, "custCode2='", "'", " OR ");
                SQLCmd += "\r\n" +"UPDATE voucher SET custCode2='" + newCodeEd + "'" + " WHERE  " + condStr;

                condStr = common.sysLibs.MakeConditionStr(oldCodeList, "custCode3='", "'", " OR ");
                SQLCmd += "\r\n" +"UPDATE voucher SET custCode3='" + newCodeEd + "'" + " WHERE  " + condStr;
                if (common.sysLibs.ExecuteSQLCmd(SQLCmd, data.dataLibs.GetApplicationConnectionString())) return false;
                return true;
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.Message.ToString());
            }
            return false;
        }

        private void addLineBtn_Click(object sender, EventArgs e)
        {
            SelectOldCodeList();
        }

        private void newCodeEd_Validating(object sender, CancelEventArgs e)
        {
            okBtn.Enabled = false;
            this.newDescEd.Text = "";
            string code = this.newCodeEd.Text.Trim();
            if (code == "") return;
            application.globalObj.myCustomerFind.SetQuerryCustCode(code);
            if (application.globalObj.myCustomerFind.Find(code))
            {
                this.newCodeEd.Text = application.globalObj.myCustomerFind.selectedDataRow["customerCode"].ToString();
                this.newDescEd.Text = application.globalObj.myCustomerFind.selectedDataRow["name"].ToString();
                okBtn.Enabled = true;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (oldCodeLb.SelectedIndices.Count>0 && newCodeEd.Text.Trim()!="")  ChangeCodeCode();
        }

        private void deleteLineBtn_Click(object sender, EventArgs e)
        {
            for (int idx = oldCodeLb.SelectedIndices.Count - 1; idx >= 0; idx--)
            {
                oldCodeLb.Items.RemoveAt(oldCodeLb.SelectedIndices[idx]);
            }
        }
    }
}

