using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenXMLDemo.StockService;

namespace OpenXMLDemo.Gateway
{
    public class SerivceHandler
    {
        public static void InitService()
        {
            if (!IsOpened())
            {
                Statics.svc_Client = new StockServiceClient();
                Statics.svc_Client.ClientCredentials.Windows.ClientCredential.UserName = Statics.svc_User;
                Statics.svc_Client.ClientCredentials.Windows.ClientCredential.Password = Statics.svc_Password;
            }
        }
        //check service is opened
        public static bool IsOpened()
        {
            return (Statics.svc_Client != null && Statics.svc_Client.State == System.ServiceModel.CommunicationState.Opened);
        }
    }
}
