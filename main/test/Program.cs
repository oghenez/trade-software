using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainTest());
            //Application.Run(new testPanel());
            Application.Run(new Form2());
            //Application.Run(new baseClass.forms.configure());
        }
    }
}
