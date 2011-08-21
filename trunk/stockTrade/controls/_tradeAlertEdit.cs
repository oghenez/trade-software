using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace stockTrade.controls
{
    public partial class _tradeAlertEdit : common.control.baseUserControl
    {
        private BindingSource _myDataSource = null;
        public BindingSource myDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                DataBinding(value);
            }
        }
        public _tradeAlertEdit()
        {
            try
            {
                InitializeComponent();
                strategyCb.LoadData();
                statusCb.LoadData();
                actionCb.LoadData();
                portpolioCb.LoadData();

                onTimeEd.BackColor = common.settings.sysColorNormalBG;  onTimeEd.ForeColor = common.settings.sysColorNormalFG;
                codeEd.BackColor = common.settings.sysColorNormalBG;    codeEd.ForeColor = common.settings.sysColorNormalFG;
                subjectEd.BackColor = common.settings.sysColorNormalBG; subjectEd.ForeColor = common.settings.sysColorNormalFG;
                messageEd.BackColor = common.settings.sysColorNormalBG; messageEd.ForeColor = common.settings.sysColorNormalFG;

                statusCb.BackColor = common.settings.sysColorNormalBG;    statusCb.ForeColor = common.settings.sysColorNormalFG;
                portpolioCb.BackColor = common.settings.sysColorNormalBG; portpolioCb.ForeColor = common.settings.sysColorNormalFG;
                strategyCb.BackColor = common.settings.sysColorNormalBG;  strategyCb.ForeColor = common.settings.sysColorNormalFG;
            }
            catch (Exception er)
            {
                this.ErrorHandler(this, er);
            }
        }
        
        private  void DataBinding(BindingSource dataSource)
        {
            data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();

            this.onTimeEd.DataBindings.Clear();
            this.onTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.onTimeColumn.ColumnName, true));

            this.codeEd.DataBindings.Clear();
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.idColumn.ColumnName, true));

            this.subjectEd.DataBindings.Clear();
            this.subjectEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.subjectColumn.ColumnName, true));

            this.messageEd.DataBindings.Clear();
            this.messageEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.msgColumn.ColumnName, true));

            this.strategyCb.DataBindings.Clear();
            this.strategyCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", dataSource, tbl.strategyColumn.ColumnName, true));

            this.portpolioCb.DataBindings.Clear();
            this.portpolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", dataSource, tbl.portpolioColumn.ColumnName, true));

            this.statusCb.DataBindings.Clear();
            this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", dataSource, tbl.statusColumn.ColumnName, true));

            this.actionCb.DataBindings.Clear();
            this.actionCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", dataSource, tbl.tradeActionColumn.ColumnName, true));
        }
        public virtual void SetFocus()
        {
            this.Focus();
            onTimeEd.Focus();
        }
    }
}
