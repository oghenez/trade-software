using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class expertSearch : common.forms.baseForm
    {
        baseClass.forms.employeeEdit myExpertEdit = null;
        public expertSearch()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            data.system.expertTA.Fill(mybaseDS.expert);
            ShowReccount("["+mybaseDS.expert.Count.ToString()+"]");
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void expertSearch_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void expertGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }

        private void expertGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (expertGrid.Columns[e.ColumnIndex].Name.ToUpper() != "gridEditBtn".ToUpper()) return;
            data.baseDS.expertRow row = (data.baseDS.expertRow)((DataRowView)expertGrid.CurrentRow.DataBoundItem).Row;
            if (row == null) return;
            if (myExpertEdit == null) myExpertEdit = new employeeEdit();
            myExpertEdit.Name = "expertList";
            myExpertEdit.ShowExpert(row.code);
        }
    }
}
