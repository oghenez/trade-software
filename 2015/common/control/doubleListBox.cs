using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace common.controls
{
    public delegate ArrayList WhenNeedAvailableDataFunc(string category);
    public partial class doubleListBox : UserControl
    {
        private delegate void WhenNeedSelectedDataFunc();
        private WhenNeedAvailableDataFunc fWhenNeedAvailableDataFunc = null;
        public  WhenNeedAvailableDataFunc WhenNeedAvailableData
        {
            set { fWhenNeedAvailableDataFunc = value; }
        }

        public string selectedItemTitle
        {
            set { selectedLbl.Text  = value; }
        }
  
        public doubleListBox()
        {
            InitializeComponent();
        }

        public ArrayList SelectedItems
        {
            get 
            {
                ArrayList selected = new ArrayList();
                for (int idx=0;idx<selectedItemLb.Items.Count;idx++)
                {
                    selected.Add(selectedItemLb.Items[idx].ToString());
                }
                return selected;
            }

            set { 
                LoadListBox(selectedItemLb, value);
                ExcludeItem();
            }
        }

        public myComboBoxItem SelectedAvailableCategoryItem
        {
            get
            {
                if (availableCatCb.SelectedIndex<0) return null;   
                return (myComboBoxItem)availableCatCb.Items[availableCatCb.SelectedIndex];
            }
        }
        
        public ArrayList AvailableCategotyList
        {
            get 
            {
                if(availableCatCb.Items==null) return null;
                ArrayList arr = new ArrayList();
                for (int idx = 0; idx < availableCatCb.Items.Count;idx++)
                {
                    arr.Add(availableCatCb.Items[idx]) ;
                }
                return arr;
            }
            set 
            {
                sysLibs.LoadToComboBox(availableCatCb, value);
                if (availableCatCb.Items.Count >0 && availableCatCb.SelectedIndex < 0) 
                    availableCatCb.SelectedIndex = 0;
            }
        }

        public ArrayList AvailableItemList
        {
            get
            {
                ArrayList arr = new ArrayList();
                for (int idx = 0; idx < availableItemLb.Items.Count; idx++)
                {
                    arr.Add(availableItemLb.Items[idx].ToString());
                }
                return arr;
            }
            set
            {
                sysLibs.LoadToListBox(availableItemLb, value);
            }
        }

        
        public void ExcludeItem()
        {
            ExcludeListBoxItem(ref availableItemLb, selectedItemLb);
        }

        private void LoadListBox(ListBox lb,string[] items)
        {
            if (items == null) return;
            lb.Items.Clear();
            for (int idx = 0; idx < items.Length; idx++)
            {
                lb.Items.Add(items[idx]);
            }
        }
        
        private void LoadListBox(ListBox lb, ArrayList items)
        {
            if (items == null) return;
            lb.Items.Clear();
            for (int idx = 0; idx < items.Count; idx++)
            {
                lb.Items.Add(items[idx].ToString());
            }
        }

        private void ExcludeListBoxItem(ref ListBox availableLb, ListBox selectedLb)
        {
            int pos;
            for (int idx = 0; idx < selectedLb.Items.Count; idx++)
            {
                //remove from available list
                pos = availableLb.Items.IndexOf(selectedLb.Items[idx].ToString());
                if (pos >= 0) availableLb.Items.RemoveAt(pos);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            for (int idx = 0; idx < selectedItemLb.SelectedIndices.Count; idx++)
            {
                availableItemLb.Items.Add(selectedItemLb.Items[selectedItemLb.SelectedIndices[idx]]);
            }
            for (int idx = selectedItemLb.SelectedIndices.Count - 1; idx >= 0; idx--)
            {
                selectedItemLb.Items.RemoveAt(selectedItemLb.SelectedIndices[idx]);
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            for (int idx = 0; idx < availableItemLb.SelectedItems.Count; idx++)
            {
                selectedItemLb.Items.Add(availableItemLb.SelectedItems[idx].ToString());
            }
            for (int idx = availableItemLb.SelectedIndices.Count - 1; idx >= 0; idx--)
            {
                availableItemLb.Items.RemoveAt(availableItemLb.SelectedIndices[idx]);
            }
        }

        private void availableCatCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( availableCatCb.SelectedIndex<0) return;
            if(fWhenNeedAvailableDataFunc==null)
            {
                sysLibs.ShowMessage("Sự kiện [WhenNeedAvailableData] chưa được thiết lập");
                return;
            }
            ArrayList items = fWhenNeedAvailableDataFunc(((myComboBoxItem)availableCatCb.Items[availableCatCb.SelectedIndex]).Value);
            LoadListBox(availableItemLb, items);
            ExcludeListBoxItem(ref availableItemLb, selectedItemLb);
        }

        private void availableItemLb_DoubleClick(object sender, EventArgs e)
        {
            int idx = availableItemLb.SelectedIndex;
            if (idx < 0 || idx >= availableCatCb.Items.Count) return;
            selectedItemLb.Items.Add(availableItemLb.Items[idx].ToString());
            availableItemLb.Items.RemoveAt(idx);
        }

        private void selectedItemLb_DoubleClick(object sender, EventArgs e)
        {
            int idx = selectedItemLb.SelectedIndex;
            if ((idx < 0) || (idx >= selectedItemLb.Items.Count)) return;
            availableItemLb.Items.Add(selectedItemLb.Items[idx]);
            selectedItemLb.Items.RemoveAt(idx);
        }

    }
}
