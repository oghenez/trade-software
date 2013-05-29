using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ServiceConsumer
{
    public static class MethodTableReference
    {
        private static bool isLoaded = false;
        private static  char delimiter = ':';
        private static string fileName = "method.tbl";
        private static Dictionary<string, string> DictMethods = new Dictionary<string, string>();
        public static void initTable()
        {
            if (!isLoaded)
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] arr = line.Split(delimiter);
                    DictMethods.Add(arr[0], arr[1]);
                }
                isLoaded = true;
            }
            else
            {

            }
        }
        public static string getMethodName(string input)
        {
            return DictMethods[input];
        }
    }
}
