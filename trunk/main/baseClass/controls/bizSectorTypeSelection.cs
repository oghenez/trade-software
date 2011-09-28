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
    public partial class BizSectorTypesSelection : common.control.baseUserControl
    {
        private data.baseDS.bizIndustryDataTable industryTbl = null;
        private data.baseDS.bizSuperSectorDataTable superSectorTbl = null;
        private data.baseDS.bizSectorDataTable sectorTbl = null;

        public delegate void SectorSelectionChange(object sender, EventArgs e);
        public event SectorSelectionChange mySectorSelectionChange = null;
        
        public BizSectorTypesSelection()
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
        public application.AppTypes.BizSectorTypes myBizSectorType
        {
            get { return bizSectorTypesCb.myValue; }
            set { bizSectorTypesCb.myValue=value; }
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
                switch (bizSectorTypesCb.myValue)
                {
                    case application.AppTypes.BizSectorTypes.Industry:
                        application.dataLibs.LoadDataByIndustryCode(bizSubSector, this.myBizSectorCode);
                        break;
                    case application.AppTypes.BizSectorTypes.SuperSector:
                        application.dataLibs.LoadDataBySuperSectorCode(bizSubSector, this.myBizSectorCode);
                        break;
                    case application.AppTypes.BizSectorTypes.Sector:
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
            this.bizSectorTypesCb.LoadList(new application.AppTypes.BizSectorTypes[] 
                        { application.AppTypes.BizSectorTypes.None, 
                          application.AppTypes.BizSectorTypes.Industry, 
                          application.AppTypes.BizSectorTypes.SuperSector, 
                          application.AppTypes.BizSectorTypes.Sector}
                        );
        }
        public virtual void LockEdit(bool state)
        {
            bizSectorTypesCb.Enabled = !state;
            bizSectorCb.Enabled = (bizSectorTypesCb.myValue != application.AppTypes.BizSectorTypes.None) && !state;
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
                bizSectorCb.Size = new Size(this.Width - bizSectorTypesCb.Width, this.Height);
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
        private void bizSectorTypesCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LockEdit(!bizSectorTypesCb.Enabled);
                switch (bizSectorTypesCb.myValue)
                {
                    case application.AppTypes.BizSectorTypes.Industry: LoadDataIndustry(bizSectorCb); break;
                    case application.AppTypes.BizSectorTypes.SuperSector: LoadDataSuperSector(bizSectorCb); break;
                    case application.AppTypes.BizSectorTypes.Sector: LoadDataSector(bizSectorCb); break;
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
