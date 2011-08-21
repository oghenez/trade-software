using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class SimpleMarkov : GenericStrategy
    {
        double[] closePrice;
        double[,] matrix;
        int column,row;
        double[] temp;

        public SimpleMarkov(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) 
        {
            row=4;
            column=3;
            matrix=new double[row,column];
            temp = new double[column];

            for (int i=0;i<row;i++)
                for (int j=0;j<column;j++)
                    matrix[i,j]=0;
            InitMatrix();
        }

        void InitMatrix()
        {
            matrix[0, 0] = 0; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
            matrix[2, 0] = 1; matrix[2, 1] = 0; matrix[2, 2] = 0;
            matrix[3, 0] = 1; matrix[3, 1] = 1; matrix[3, 2] = 0;
        }

        void print()
        {
            for (int i=0;i<row;i++)
            {
                for (int j=0;j<column;j++){
                    Console.Write(matrix[i, j]+ " ");

                }
                Console.WriteLine();

            }
            Console.ReadLine();
        }

        public void CreateMarkovMatrix(int length)
        {
            //int column=3;
            InitMatrix();

            for (int idx = 3; idx < length; idx++)
            {               
                //dem so pattern;
                temp[0]=closePrice[idx-3];
                temp[1] = closePrice[idx - 2];
                temp[2] = closePrice[idx - 1];
                //temp[3] = closePrice[idx];
                if ((temp[0] > temp[1])&(temp[1] > temp[2]))
                    matrix[3,2]++;
                if ((temp[0] > temp[1]) & (temp[1] < temp[2]))
                    matrix[2, 2]++;

                if ((temp[0] < temp[1]) & (temp[1] > temp[2]))
                    matrix[1, 2]++;

                if ((temp[0] < temp[1]) & (temp[1] < temp[2]))
                    matrix[0, 2]++;
            }
            //print();
        }

        public override analysis.analysisResult Execute()
        {
            int ParamUp = 60;
            int ParamDown = 60;
            bool is_bought=false;

            closePrice = data.closePrice;
            
            
            analysis.analysisResult adviceInfo = new analysis.analysisResult();

            for (int idx = 50; idx < closePrice.Length; idx++)
            {
                CreateMarkovMatrix(idx-1);
                temp[0] = closePrice[idx - 3];
                temp[1] = closePrice[idx - 2];
                temp[2] = closePrice[idx - 1];
                if (temp[0] < temp[1])
                {
                    double totalNumber = matrix[0, 2] + matrix[1, 2];
                    double percentDown = matrix[0, 2] / totalNumber*100;
                    double percentUp = matrix[1, 2] / totalNumber * 100;
                    //Buy Condition
                    if (!is_bought&&percentUp > ParamUp)
                    {
                        is_bought = true;
                        adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    }

                    //Sell Condition

                    if (is_bought&&percentDown> ParamDown)
                    {
                        is_bought = false;
                        adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    }
                }

                if (temp[0] > temp[1])
                {
                    double totalNumber = matrix[2, 2] + matrix[3, 2];
                    double percentDown = matrix[2, 2] / totalNumber * 100;
                    double percentUp = matrix[3, 2] / totalNumber * 100;
                    //Buy Condition
                    if (!is_bought&&percentUp > ParamUp)
                    {
                        is_bought = true;
                        adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    }

                    //Sell Condition

                    if (is_bought && percentDown > ParamDown)
                    {
                        is_bought = false;
                        adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    }
                }

            }
            
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, closePrice);
            return adviceInfo;
        }
    }
}
