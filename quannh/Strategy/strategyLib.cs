using application;

namespace Strategy
{
    class strategyLib
    {
        /* Get average of a list for 0 to position
         */
        public static double findAverage(DataSeries list, int position, int number_Periods)
        {
            if (list.Count == 0 || position - number_Periods < 0) return 0;

            double average = 0;
            for (int i = position; i > position - number_Periods; i--)
                average += list[i];
            return average / number_Periods;
        }

        /* Find the minimum value of a list, from position back to number_Periods period
         */
        public static double findSupport(DataSeries list, int position, int number_Periods)
        {
            if (list.Count == 0 || position - number_Periods < 0) return -1;

            double min = double.MaxValue;
            for (int i = position; i > position - number_Periods; i--)
                if (min > list[i])
                    min = list[i];    
                
            return min;
        }

        /* Find the maximum value of a list, from position back to number_Periods period
         */
        public static double findResistance(DataSeries list, int position, int number_Periods)
        {
            if (list.Count == 0 || position - number_Periods < 0) return -1;

            double max = double.MinValue;
            for (int i = position; i > position - number_Periods; i--)
                if (max < list[i])
                    max = list[i];

            return max;
        }

        /*Detect if there is "days" cummulative up in close price
         * 
         */
        
        static public bool isCummulativeUp(DataSeries closePrice, int idx, int days)
        {
            for (int i = idx; i > idx - days; i--)
            {
                if (closePrice[i] < closePrice[i - 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Detect if there is "days" cummulative down in close price
        /// </summary>
        /// <param name="closePrice"></param>
        /// <param name="idx"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        static public bool isCummulativeDown(DataSeries closePrice, int idx, int days)
        {
            for (int i = idx; i > idx - days; i--)
            {
                if (closePrice[i] > closePrice[i - 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Tim ratio reward/risk
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position"></param>
        /// <param name="number_Periods"></param>
        /// <returns></returns>

        static public double RiskRewardRatio(DataSeries list, int position, int number_Periods)
        {
            if (list.Count == 0 || position - number_Periods < 0) return -1;

            double min = double.MaxValue;
            double max = double.MinValue;
            double risk_reward;

            for (int i = position; i > position - number_Periods; i--)
                if (min > list[i])
                    min = list[i];
                else
                if (max < list[i])
                    max = list[i];
            double distance1 = list[position]-min;
            double distance2 = max-list[position];
            if (distance1>0) 
                risk_reward = distance2 / distance1;
            else
                risk_reward=100;
            return risk_reward;
        }
    }
}
