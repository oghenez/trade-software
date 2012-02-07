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
    public partial class BizSectorTypesSelection : common.controls.baseUserControl
    {
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

        public override void SetLanguage()
        {
            base.SetLanguage();
            bizSectorTypesCb.SetLanguage();
            bizSectorCb.SetLanguage();
        }

        public commonClass.AppTypes.BizSectorTypes myBizSectorType
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
                data.baseDS.bizSubSectorDataTable bizSubSector = null;
                switch (bizSectorTypesCb.myValue)
                {
                    case commonClass.AppTypes.BizSectorTypes.Industry:
                         bizSubSector = DataAccess.Libs.GetBizSubSector_ByIndustry(this.myBizSectorCode);
                         break;
                    case commonClass.AppTypes.BizSectorTypes.SuperSector:
                         bizSubSector = DataAccess.Libs.GetBizSubSector_BySuperSector(this.myBizSectorCode);
                         break;
                    case commonClass.AppTypes.BizSectorTypes.Sector:
                         bizSubSector = DataAccess.Libs.GetBizSubSector_BySector(this.myBizSectorCode);
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
            this.bizSectorTypesCb.LoadList(new commonClass.AppTypes.BizSectorTypes[] 
                        { commonClass.AppTypes.BizSectorTypes.None, 
                          commonClass.AppTypes.BizSectorTypes.Industry, 
                          commonClass.AppTypes.BizSectorTypes.SuperSector, 
                          commonClass.AppTypes.BizSectorTypes.Sector}
                        );
        }
        public virtual void LockEdit(bool state)
        {
            bizSectorTypesCb.Enabled = !state;
            bizSectorCb.Enabled = (bizSectorTypesCb.myValue != commonClass.AppTypes.BizSectorTypes.None) && !state;
        }
        private void LoadDataIndustry(ComboBox obj)
        {
            data.baseDS.bizIndustryDataTable industryTbl = DataAccess.Libs.myBizIndustryTbl;
            obj.DataSource = null;
            obj.Items.Clear();
            obj.DisplayMember = industryTbl.description1Column.ColumnName;
            obj.ValueMember = industryTbl.codeColumn.ColumnName;
            obj.DataSource = industryTbl;
            if (industryTbl.Count > 0)
            {
                obj.MaxDropDownItems = industryTbl.Count;
                obj.SelectedIndex = 0;
            }
        }
        private void LoadDataSuperSector(ComboBox obj)
        {
            data.baseDS.bizSuperSectorDataTable superSectorTbl = DataAccess.Libs.myBizSuperSectorTbl;
            obj.DataSource = null;
            obj.Items.Clear();
            obj.DisplayMember = superSectorTbl.description1Column.ColumnName;
            obj.ValueMember = superSectorTbl.codeColumn.ColumnName;
            obj.DataSource = superSectorTbl;
            if (superSectorTbl.Count > 0)
            {
                obj.MaxDropDownItems = superSectorTbl.Count;
                obj.SelectedIndex = 0;
            }
        }
        private void LoadDataSector(ComboBox obj)
        {
            data.baseDS.bizSectorDataTable sectorTbl = DataAccess.Libs.myBizSectorTbl;
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
                    case commonClass.AppTypes.BizSectorTypes.Industry: LoadDataIndustry(bizSectorCb); break;
                    case commonClass.AppTypes.BizSectorTypes.SuperSector: LoadDataSuperSector(bizSectorCb); break;
                    case commonClass.AppTypes.BizSectorTypes.Sector: LoadDataSector(bizSectorCb); break;
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
