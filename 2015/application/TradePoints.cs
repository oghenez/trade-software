using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using application;
using commonTypes;
using commonClass;

namespace application
{
    //List of all possible trading points
    [DataContract]
    public class TradePoints : ArrayList
    {
        public TradePoints() { }
        public void Add(AppTypes.TradeActions action, int idx, BusinessInfo info)
        {
            this.Add(new TradePointInfo(action, idx, info));
        }
        public void Add(AppTypes.TradeActions action, int idx)
        {
            this.Add(new TradePointInfo(action, idx));
        }
    }
}
