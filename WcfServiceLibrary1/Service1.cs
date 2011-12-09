using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class Service1 : IService1
    {
        public Strategy.Meta test()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.configuration.withEncryption = true;

            string executeDir = "D:\\work\\stockProject\\code\\dlls";
            Strategy.Settings.sysDirectory = executeDir;
            common.settings.sysConfigFile = common.fileFuncs.ConcatFileName(executeDir, "wsStock.xml");
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            common.DictionaryList list = Strategy.Data.MetaList;
            return (Strategy.Meta)Strategy.Data.MetaList.Values[0];
        }        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
