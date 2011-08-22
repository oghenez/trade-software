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

namespace baseClass.controls
{
    public partial class companyStockCode : common.control.baseListEdit
    {
        private data.baseDS.stockCodeDataTable myDataTbl = new data.baseDS.stockCodeDataTable();
        public companyStockCode()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);;
            }            
        }
        public override event EventHandler myOnError
        {
            add
            {
                base.myOnError += value;
                stockCodeDetail.myOnError += value;
            }
            remove
            {
                base.myOnError -= value;
                stockCodeDetail.myOnError -= value;
            }
        }

        public override void Init()
        {
            base.Init();
            stockCodeDetail.Init();
            SetData(myDataTbl);
        }
        public override void LoadData(string companyCode) 
        {
            myDataTbl.Clear();
            if (companyCode != null)
            {
                application.dataLibs.LoadData(myDataTbl, companyCode);
            }
        }
        public override void SaveData(string companyCode)
        {
            gridDataSource.EndEdit();
            for (int idx = 0; idx < myDataTbl.Count; idx++)
            {
                if (myDataTbl[idx].RowState == DataRowState.Deleted) continue;
                myDataTbl[idx].comCode = companyCode;
            }
            application.dataLibs.UpdateData(myDataTbl);
        }
        public override void LockEdit(bool state)
        {
            base.LockEdit(state);
            stockCodeDetail.LockEdit(state);
        }
        public override bool CheckData()
        {
            return stockCodeDetail.CheckData();
        }
        public override void SetFocus()
        {
            stockCodeDetail.SetFocus();
        }
        public override void AddNew()
        {
            data.baseDS.stockCodeRow row;
            gridDataSource.AddNew();
            if (this.gridDataSource.Current != null)
            {
                row = (data.baseDS.stockCodeRow)((DataRowView)this.gridDataSource.Current).Row;
                application.dataLibs.InitData(row);
            }
            gridDataSource.EndEdit();
            //stockCodeDetail.SetDataSource(gridDataSource);
        }

        private void SetData(data.baseDS.stockCodeDataTable tbl)
        {
            
            gridDataSource.DataSource = tbl;
            stockCodeDetail.SetDataSource(gridDataSource);
            DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn marketColumn = new DataGridViewTextBoxColumn();
            this.detailGrid.Columns.Clear();
            this.detailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] 
                                        {
                                            codeColumn, marketColumn
                                        }
                                         );
            // 
            // codeColumn
            // 
            codeColumn.DataPropertyName = tbl.codeColumn.ColumnName;
            codeColumn.HeaderText = "Mã hiệu";
            codeColumn.Name = tbl.codeColumn.ColumnName;
            codeColumn.Width = 100;
            // 
            // marketColumn
            // 
            marketColumn.DataPropertyName = tbl.stockExchangeColumn.ColumnName;
            marketColumn.HeaderText = "Sàn giao dịch";
            marketColumn.Name = tbl.stockExchangeColumn.ColumnName;
            
            common.system.AutoFitGridColumn(detailGrid, marketColumn.Name);
        }
    }
}
