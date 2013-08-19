using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReportProcessing
{
    public class ReflectionUtils
    {
        public static object GetMethod(object src, string methodName,params object[] paramss)
        {            
            MethodInfo magicMethod = src.GetType().GetMethod(methodName);
            return magicMethod.Invoke(src, paramss);
        }
    }
}
