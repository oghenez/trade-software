using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class bizSectorTypeSelection : common.control.baseUserControl
    {
        private data.baseDS.bizIndustryDataTable industryTbl = null;
        private data.baseDS.bizSuperSectorDataTable superSectorTbl = null;
        private data.baseDS.bizSectorDataTable sectorTbl = null;

        public delegate void SectorSelectionChange(object sender, EventArgs e);
        public event SectorSelectionChange mySectorSelectionChange = null;
        
        public bizSectorTypeSelection()
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
        public application.myTypes.bizSectorType myBizSectorType
        {
            get { return bizSectorTypeCb.myValue; }
            set { bizSectorTypeCb.myValue=value; }
        }
        public string myBizSectorCode
        {
            get { return bizSectorCb.myValue; }
            set { bizSectorCb.myValue = value; }
        }

        public StringCollection myCurrentSubSectorCodes
        {
            get
            {
                data.baseDS.bizSubSectorDataTable bizSubSector = new data.baseDS.bizSubSectorDataTable();
                switch (bizSectorTypeCb.myValue)
                {
                    case application.myTypes.bizSectorType.Industry:
                        application.dataLibs.LoadDataByIndustryCode(bizSubSector, this.myBizSectorCode);
                        break;
                    case application.myTypes.bizSectorType.SuperSector:
                        application.dataLibs.LoadDataBySuperSectorCode(bizSubSector, this.myBizSectorCode);
                        break;
                    case application.myTypes.bizSectorType.Sector:
                        application.dataLibs.LoadDataBySectorCode(bizSubSector, this.myBizSectorCode);
                        break;
                    default: return null;
                }
                StringCollection list = new StringCollection();
                for (int idx = 0; idx < bizSubSector.Count; idx++) list.Add(bizSubSector[idx].code);
                return list;
            }
        }
        public virtual void LoadData()
        {
            this.bizSectorTypeCb.LoadList(new application.myTypes.bizSectorType[] 
                        { application.myTypes.bizSectorType.None, 
                          application.myTypes.bizSectorType.Industry, 
                          application.myTypes.bizSectorType.SuperSector, 
                          application.myTypes.bizSectorType.Sector}
                        );
        }
        public virtual void LockEdit(bool state)
        {
            bizSectorTypeCb.Enabled = !state;
            bizSectorCb.Enabled = (bizSectorTypeCb.myValue!= application.myTypes.bizSectorType.None) && !state;
        }
        private void LoadDataIndustry(ComboBox obj)
        {
            if (industryTbl == null)
            {
                industryTbl = new data.baseDS.bizIndustryDataTable();
                application.dataLibs.LoadData(industryTbl);
            }
            obj.DataSource = null;
            obj.Items.Clear();
            obj.DisplayMember = industryTbl.description1Column.ColumnName;
            obj.ValueMember = industryTbl.codeColumn.ColumnName;
            obj.DataSource = industryTbl;
            if (industryTbl.Count > 0)
            {
                obj.MaxDropDownItems = sectorTbl.Count;
                obj.SelectedIndex = 0;
            }
        }
        private void LoadDataSuperSector(ComboBox obj)
        {
            if (superSectorTbl == null)
            {
                superSectorTbl = new data.baseDS.bizSuperSectorDataTable();
                application.dataLibs.LoadData(superSectorTbl);
            }
            obj.DataSource = null;
            obj.Items.Clear();
            obj.DisplayMember = superSectorTbl.description1Column.ColumnName;
            obj.ValueMember = superSectorTbl.codeColumn.ColumnName;
            obj.DataSource = superSectorTbl;
            if (superSectorTbl.Count > 0)
            {
                obj.MaxDropDownItems = sectorTbl.Count;
                obj.SelectedIndex = 0;
            }
        }
        private void LoadDataSector(ComboBox obj)
        {
            if (sectorTbl == null)
            {
                sectorTbl = new data.baseDS.bizSectorDataTable();
                application.dataLibs.LoadData(sectorTbl);
            }
            obj.DataSource = null;
            obj.Items.Clear();
            obj.DisplayMember = sectorTbl.description1Column.ColumnName;
            obj.ValueMember = sectorTbl.codeColumn.ColumnName;
            obj.DataSource = sectorTbl;
            if (sectorTbl.Count > 0)
            {
                obj.MaxDropDownItems = sectorTbl.Count;
                obj.SelectedIndex = 0;
            }
        }
        
        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                bizSectorCb.Size = new Size(this.Width - bizSectorTypeCb.Width, this.Height);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        private void bizSectorCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (mySectorSelectionChange != null) mySectorSelectionChange(sender, e);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }       
        }
        private void bizSectorTypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LockEdit(!bizSectorTypeCb.Enabled);
                switch (bizSectorTypeCb.myValue)
                {
                    case application.myTypes.bizSectorType.Industry: LoadDataIndustry(bizSectorCb); break;
                    case application.myTypes.bizSectorType.SuperSector: LoadDataSuperSector(bizSectorCb); break;
                    case application.myTypes.bizSectorType.Sector: LoadDataSector(bizSectorCb); break;
                }
                if (mySectorSelectionChange != null) mySectorSelectionChange(sender, e);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
    }
}
