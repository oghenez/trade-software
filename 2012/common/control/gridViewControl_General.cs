using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace common.controls
{
    public class baseDataGridView : DataGridView
    {
        public bool IsOnProcessing = false;
        public baseDataGridView()
        {
            //this.RowTemplate.Height = 24;
        }

        //Columns that size is fixed / not adjusted dynamically
        public string myAutoFixColumn = null;
        public StringCollection myFixedSizedColumns = new StringCollection();
        public StringCollection myDisableColumns = new StringCollection();

        //Quick find
        string qfKeyPressBuff = "";
        DateTime qfKeyPressBuffTime = DateTime.Now;
        private short qfKeyCaptureInMiliSec = 500;
        public bool myUseQuickFind = false;
        public short myQuickFindColumnId = 0;
        private void QuickFind()
        {
            if (this.myQuickFindColumnId < 0 || this.myQuickFindColumnId >= this.ColumnCount) return;
            for (int idx = 0; idx < this.RowCount; idx++)
            {
                if (this.Rows[idx].Cells[this.myQuickFindColumnId].Value.ToString().ToUpper().StartsWith(qfKeyPressBuff))
                {
                    this.CurrentCell = this.Rows[idx].Cells[this.myQuickFindColumnId];
                    return;
                }
            }
        }
        
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.myUseQuickFind)
            {
                TimeSpan ts = DateTime.Now.Subtract(this.qfKeyPressBuffTime);
                if (ts.Milliseconds < this.qfKeyCaptureInMiliSec)
                {
                    this.qfKeyPressBuff += e.KeyChar.ToString().ToUpper();
                }
                else
                {
                    this.qfKeyPressBuff = e.KeyChar.ToString().ToUpper();
                    this.qfKeyPressBuffTime = DateTime.Now;
                }
                QuickFind();
            }
        }
        protected override void OnDataError(bool displayErrorDialogIfNoHandler, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            e.ThrowException = false;
            ErrorHandler(this, e.Exception);
        }

        public event myEventHandler myOnError = null;
        public virtual event myEventHandler myOnErrorHanler
        {
            add
            {
                myOnError += value;
            }
            remove
            {
                myOnError -= value;
            }
        }
        protected void ErrorHandler(object sender, Exception er)
        {
            if (er == null || myOnError == null) return;
            myExceptionEventArgs exEventArgs = new myExceptionEventArgs();
            exEventArgs.myException = er;
            myOnError(sender, exEventArgs);
        }

        public delegate void OnCellEvent(object sender, int rowIndex, int columnIndex);
        public event OnCellEvent myOnFind = null;
        public event OnCellEvent myOnCellValueChanged = null;
        public event OnCellEvent myOnCellValidated = null;
        private void DoFind(int RowIndex, int ColumnIndex)
        {
            if (myOnFind == null) return;
            myOnFind(this, RowIndex, ColumnIndex);
        }
        public override string ToString() { return typeof(DataGridView).Name; }

        public void AutoFitColumn()
        {
            if (this.myAutoFixColumn == null) return;
            if (String.IsNullOrEmpty(this.myAutoFixColumn) == false && this.Columns[this.myAutoFixColumn] != null)
            {
                int w = common.sysLibs.VisibleGridColumnWidth(this);
                w -= this.Columns[this.myAutoFixColumn].Width - (this.RowHeadersVisible ? this.RowHeadersWidth : 2) - SystemInformation.VerticalScrollBarThumbHeight - 2;
                this.Columns[this.myAutoFixColumn].Width = this.Width - w;
                return;
            }
            AutoFitColumnEVEN();
        }
        private void AutoFitColumnEVEN()
        {
            distribution widthDist = new distribution();
            int totalWidth = 0, totalFixWidth = 0;

            for (int idx = 0; idx < this.Columns.Count; idx++)
            {
                if (!this.Columns[idx].Visible) continue;
                if (this.myFixedSizedColumns.Contains(this.Columns[idx].Name))
                {
                    totalFixWidth += this.Columns[idx].Width;
                    continue;
                }
                totalWidth += this.Columns[idx].Width;
                widthDist.Add(this.Columns[idx].Name, this.Columns[idx].Width);
            }
            totalWidth = this.Width - totalFixWidth - (this.RowHeadersVisible ? this.RowHeadersWidth : 2) - SystemInformation.VerticalScrollBarThumbHeight - 2 - totalWidth;
            if (!widthDist.Distribute(totalWidth, 0)) return;
            System.Collections.SortedList disResult = widthDist.GetDistribution();
            int value = 0;
            string tmp;
            for (int idx = 0; idx < disResult.Count; idx++)
            {
                tmp = disResult.GetKey(idx).ToString();
                int.TryParse(disResult[tmp].ToString(), out value);
                this.Columns[tmp].Width += value;
            }
        }

        // some strange error when on new row ??? 
        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell == null || myOnFind == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= this.RowCount || e.ColumnIndex < 0 || e.ColumnIndex >= this.ColumnCount) return;
            try
            {
                base.OnCellDoubleClick(e);
                IsOnProcessing = true;
                if (this.CurrentCell.ValueType ==  typeof(System.String))
                    DoFind(this.CurrentCell.RowIndex, this.CurrentCell.ColumnIndex);
                IsOnProcessing = false;
            }
            catch (Exception er)
            {
                IsOnProcessing = false;
                ErrorHandler(this,er);
            }
        }
        protected override void OnCellValidated(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell == null) return;
            if (e.RowIndex <0 || e.RowIndex >= this.RowCount ||   e.ColumnIndex <0 || e.ColumnIndex >= this.ColumnCount) return;

            if (IsOnProcessing) return;
            try
            {
                IsOnProcessing = true;
                if (myOnCellValidated != null)
                    myOnCellValidated(this, e.RowIndex, e.ColumnIndex);
                base.OnCellValidated(e);
                IsOnProcessing = false;
            }
            catch (Exception er)
            {
                IsOnProcessing = false;
                ErrorHandler(this, er);
            }
        }
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= this.RowCount || e.ColumnIndex < 0 || e.ColumnIndex >= this.ColumnCount) return;
            if (IsOnProcessing) return;
            try
            {
                IsOnProcessing = true;
                base.OnCellValueChanged(e);
                if (myOnCellValueChanged != null) myOnCellValueChanged(this, e.RowIndex, e.ColumnIndex);
                if (this.CurrentCell.ValueType == typeof(System.String) && common.sysLibs.HaveFindMarker(this.CurrentCell.EditedFormattedValue.ToString()))
                {
                    DoFind(e.RowIndex, e.ColumnIndex);
                }
                IsOnProcessing = false;
            }
            catch (Exception er)
            {
                IsOnProcessing = false;
                ErrorHandler(this,er);
            }
        }
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= this.RowCount || e.ColumnIndex < 0 || e.ColumnIndex >= this.ColumnCount) return;
            if (IsOnProcessing) return;
            try
            {
                IsOnProcessing = true;
                base.OnCellEnter(e);
                if (this.myDisableColumns.Contains(this.Columns[e.ColumnIndex].Name)) SendKeys.Send("{Tab}");
                IsOnProcessing = false;
            }
            catch (Exception er)
            {
                IsOnProcessing = false;
                ErrorHandler(this,er);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                base.OnSizeChanged(e);
                AutoFitColumn();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        public bool isLockEdit
        {
            get { return this.ReadOnly;}
        }
        public void LockEdit(bool lockStat)
        {
            //this.Enabled  = !lockStat;
            this.ReadOnly = lockStat;
            this.AllowUserToAddRows = !lockStat;
            this.AllowUserToDeleteRows = !lockStat;
        }
        public void ReOrderColumn(string[] colName)
        {
            for (int idx = 0; idx < colName.Length; idx++)
                this.Columns[colName[idx]].DisplayIndex = idx;
        }
        public void SetColumnVisible(string[] colName, bool visibleMode)
        {
            //Hide all column first
            for (int idx = 0; idx < this.ColumnCount; idx++) this.Columns[idx].Visible = false;
            for (int idx = 0; idx < colName.Length; idx++)
                SetColumnVisible(colName[idx], visibleMode);
        }
        public void SetColumnVisible(string colName, bool visibleMode)
        {
            colName = colName.ToUpper();
            for (int idx = 0; idx < this.ColumnCount; idx++)
            {
                if (this.Columns[idx].Name.ToUpper() == colName)
                {
                    this.Columns[idx].Visible = visibleMode;
                    break;
                }
            }
        }
        public void SetColumnReadOnly(string colName, bool roMode)
        {
            colName = colName.ToUpper();
            for (int idx = 0; idx < this.ColumnCount; idx++)
            {
                if (this.Columns[idx].Name.ToUpper() == colName)
                {
                    this.Columns[idx].ReadOnly = roMode;
                    break;
                }
            }
        }
        public void DisbaleReadOnlyColumns()
        {
            this.myDisableColumns.Clear();
            for (int idx = 0; idx < this.ColumnCount; idx++)
            {
                if (!this.Columns[idx].ReadOnly) continue;
                this.myDisableColumns.Add(this.Columns[idx].Name);
            }
        }
    }
    #region grid image cell
    // Adapted form "Defining Custom Column and Cell Types" in
    // "Presenting Data with the DataGridView Control in .NET 2.0" By Brian Noyes
    public class baseGridViewImageCell : DataGridViewImageCell
    {
        public baseGridViewImageCell()
        {
            this.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        protected virtual System.Drawing.Image GetCellImage(string status) { return null; }
        protected override object GetFormattedValue(object value,
           int rowIndex, ref DataGridViewCellStyle cellStyle,
           System.ComponentModel.TypeConverter valueTypeConverter,
           System.ComponentModel.TypeConverter formattedValueTypeConverter,
           DataGridViewDataErrorContexts context)
        {
            string status = "";
            // Try to get the default value from the containing column
            baseGridViewImageColumn owningCol = OwningColumn as baseGridViewImageColumn;
            if (owningCol != null) status = owningCol.myValue;
            if (value is string) status = (string)value;
            cellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            return GetCellImage(status);
        }
    }
    public class baseGridViewImageColumn : DataGridViewColumn
    {
        public baseGridViewImageColumn(DataGridViewImageCell obj) : base(obj) { }
        public baseGridViewImageColumn() : base(new baseGridViewImageCell()) { }
        private string _myValue = "";
        public string myValue
        {
            get { return _myValue; }
            set { _myValue = value; }
        }

        public override object Clone()
        {
            baseGridViewImageColumn col = base.Clone() as baseGridViewImageColumn;
            col.myValue = _myValue;
            return col;
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid cell type, myColumns can only contain myDataGridViewImageCells");
                }
            }
        }
    }
    #endregion

    #region grid textBox

    public class DataGridViewTextBoxColumnExt : DataGridViewTextBoxColumn
    {
        public DataGridViewTextBoxColumnExt() : base()
        {
            CellTemplate = new DataGridViewTextBoxCellExt();
        }
        private bool _uppercase = false;
        public bool Uppercase
        {
            get { return _uppercase; }
            set { _uppercase = value; }
        }
    }

    public class DataGridViewTextBoxCellExt : DataGridViewTextBoxCell
    {
        public DataGridViewTextBoxCellExt()
            : base()
        {
        }
        public override Type EditType
        {
            get
            {
                if (((DataGridViewTextBoxColumnExt)this.OwningColumn).Uppercase)
                    return typeof(DataGridViewUpperCaseTextBoxEditingControl);
                return typeof(DataGridViewTextBoxEditingControl);
            }

        }
    }
    public class DataGridViewUpperCaseTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        public DataGridViewUpperCaseTextBoxEditingControl() : base()
        {
            this.CharacterCasing = CharacterCasing.Upper;
        }
    }

    #endregion grid textBox

    public enum imageType { Print, Detail, Scan, Edit, Cancel,Refresh,Select,Search,Next,Previous,Remove }
    public class gridViewImageCell : controls.baseGridViewImageCell
    {
        public gridViewImageCell()
        {
            this.ImageLayout = DataGridViewImageCellLayout.Normal;
        }
        protected override System.Drawing.Image GetCellImage(string status)
        {
            status = status.Trim();
            if (status == imageType.Scan.ToString()) return Properties.Resources.scanner;
            if (status == imageType.Detail.ToString()) return Properties.Resources.report;
            if (status == imageType.Print.ToString()) return Properties.Resources.print;
            if (status == imageType.Edit.ToString()) return Properties.Resources.edit;
            if (status == imageType.Cancel.ToString()) return Properties.Resources.remove;
            if (status == imageType.Remove.ToString()) return Properties.Resources.delete;
            if (status == imageType.Refresh.ToString()) return Properties.Resources.refresh;

            if (status == imageType.Search.ToString()) return Properties.Resources.find;
            
            if (status == imageType.Next.ToString()) return Properties.Resources.next;
            if (status == imageType.Previous.ToString()) return Properties.Resources.previous;
            return null;
        }
    }
    public class gridViewImageColumn : controls.baseGridViewImageColumn
    {
        public gridViewImageColumn() : base(new gridViewImageCell()) { this.Width = 25; }
        public imageType myImageType
        {
            //get 
            //{
            //    this.ValueType
            //    baseGridViewImageColumn aa = (baseGridViewImageColumn)this.myValue;
            //    return (imageType)this.myValue; 
            //}
            set
            {
                this.myValue = value.ToString();
            }
        }
    }
}
