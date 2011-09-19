using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Parameters
    {
        public int numOfParams;
        public int[] Params;

        public Parameters()
        {
            numOfParams = 0;
        }

        public Parameters(int p1, int p2)
        {
            numOfParams = 2;
            Params = new int[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
        }

        public Parameters(int p1, int p2,int p3)
        {
            numOfParams = 3;
            Params = new int[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
            Params[2] = p3;
        }


        public Parameters(int p1, int p2, int p3,int p4)
        {
            numOfParams = 4;
            Params = new int[numOfParams];
            Params[0] = p1;
            Params[1] = p2;
            Params[2] = p3;
            Params[3] = p4;
        }

        public Parameters(int[] p)
        {
            numOfParams = p.Length;
            if (numOfParams > 0)
            {
                Params=new int[numOfParams];
                Array.Copy(p, Params, numOfParams);
            }
        }

        public int getParameter(int index){
            if (index<numOfParams)
                return Params[index];
            else
                throw new IndexOutOfRangeException("Params out of index");
        }
    }
}
