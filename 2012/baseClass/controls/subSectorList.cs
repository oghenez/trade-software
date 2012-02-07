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
    public partial class subSectorList : common.controls.baseListEdit2
    {
        public subSectorList()
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
        protected override common.controls.baseListBox CreateListObj()
        {
            controls.lbSubSectorCode lbox = new controls.lbSubSectorCode();
            lbox.SelectionMode = SelectionMode.MultiExtended;
            return lbox;
        }
        protected override common.forms.baseListSelection CreateCodeSelectionForm()
        {
            return new forms.subSectorSelectionForm();
        }
    }
}
