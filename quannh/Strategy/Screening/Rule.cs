using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Strategy
{
    public class Rule
    {
        public Rule()
        {
        }

        virtual public bool isValid()
        {
            return false;
        }

        virtual public bool isValid(int index)
        {
            return false;
        }
    }    


}
