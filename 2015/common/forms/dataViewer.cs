using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using common;

namespace common.forms
{
    public partial class dataViewer : common.forms.baseForm  
    {
        public dataViewer()
        {
            InitializeComponent();
            SetGridLocation(0, 0);
        }

        public void SetGridLocation(int x, int y)
        {
            this.gridViewer.Location = new Point(x, y + exportBtn.Height);
        }

         public void SetViewerSize(int w, int h)
         {
             SetGridLocation(0, 0);
             h -= this.myStatusStrip.Height + exportBtn.Height;
             this.gridViewer.SetGridSize(w,h);
         }

         public void SetViewerData(DataTable dataTbl, ArrayList arrList)
         {
             this.gridViewer.SetDataGrid(dataTbl,arrList); 
         }

         private void dataViewer_SizeChanged(object sender, EventArgs e)
         {
             SetGridLocation(0,0);
             SetViewerSize(this.Size.Width, this.Size.Height);
         }

         private void closeBtn_Click(object sender, EventArgs e)
         {
             this.Hide();
         }

         private void exitMenuItem_Click(object sender, EventArgs e)
         {
             Close();
         }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            gridViewer.Export();
        }

    }
}