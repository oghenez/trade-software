using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class testWCF : baseClass.forms.configure
    {
        public testWCF()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            InitializeComponent();
        }
    }
}
