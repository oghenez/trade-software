using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer
{
    public class ReflectionUtils
    {
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
