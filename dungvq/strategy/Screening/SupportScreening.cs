using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace strategy
{
    class SupportScreening : GenericScreening
    {
        public SupportScreening(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        protected override void ScreeningExecute()
        {
            int period = (int)parameters.getParameter(0);
            double distance = (double)parameters.getParameter(1);

            int Bar = data.closePrice.Length - 1;
            if (Bar <= 1) return;
            double[] close = data.closePrice;
            double support = strategyLib.findSupport(close, Bar, period);
            if (support == -1) return;
            if ((close[Bar]-support)/support<distance)
                SelectStock(Bar,null);
        }
    }
}
