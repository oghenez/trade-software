using System;
using System.Collections.Generic;
using System.Text;
using application;
namespace strategy
{
    public class GenericScreening : GenericStrategy
    {
        public GenericScreening(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
    }        
}
