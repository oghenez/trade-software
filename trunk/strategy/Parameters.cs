using System;
using System.Collections.Generic;
using System.Text;

namespace strategy
{
    /// <summary>
    /// This class defines the lists of Parameters. 
    /// </summary>
    public class Parameters
    {
        public int numOfParams;
        public double[] Params;

        public Parameters()
        {
            numOfParams = 0;
        }

        public Parameters(double p1, double p2)
        {
            numOfParams = 2;
            Params = new double[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
        }

        public Parameters(double p1, double p2,double p3)
        {
            numOfParams = 3;
            Params = new double[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
            Params[2] = p3;
        }


        public Parameters(double p1, double p2, double p3,double p4)
        {
            numOfParams = 4;
            Params = new double[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
            Params[2] = p3;
            Params[3] = p4;
        }

        public Parameters(double[] p)
        {
            numOfParams = p.Length;
            if (numOfParams > 0)
            {
                Params=new double[numOfParams];
                Array.Copy(p, Params, numOfParams);
            }
        }

        public double getParameter(int index){
            if (index<numOfParams)
                return Params[index];
            else
                throw new IndexOutOfRangeException("Params out of index");
        }
    }
}
