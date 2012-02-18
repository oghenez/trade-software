﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace Indicators
{
    public class language
    {
        private static ResourceManager _myResourceManager = null;
        private static ResourceManager myResourceManager
        {
            get
            {
                if (_myResourceManager == null)
                    _myResourceManager = new ResourceManager("Indicators.langs.myResources", System.Reflection.Assembly.GetExecutingAssembly());
                return _myResourceManager;
            }
        }
        public static string GetString(string code)
        {
            string tmp  = myResourceManager.GetString(code,common.language.myCulture);
            return (tmp == null ? "?" : tmp);
        }
    }
}