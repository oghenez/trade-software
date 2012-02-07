using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charts
{
    public class Settings
    {
        // Zoom out/in means that the number of points will be increased/decreased respectively 
        // The value defines the number of points increased/decreased in each zooming 
        public static int sysZoom_Percent = 1;   // The percent of the viewport to be increased/decreased
        public static int sysZoom_MinCount = 10; // Must be increased/decreased at least sysZoom_MinCount points

        // Chart can be move back and forth.
        // The value defines the number of points to move from the current loccation (viewport).
        public static int sysPAN_MovePercent  = 1 ; // The percent of the viewport to be moved
        public static int sysPAN_MoveMinCount = 10; // Must be moved at least sysPAN_MoveMinCount points

        // Chart-moving only occurs after [sysSensibilityPAN] times of mouse move event to slow dow the moving.
        // The higher value of [sysSensibilityPAN], the slower chart-moving speed is.
        public static int sysPAN_MouseRate = 3; //5

        // Chart can have many points but we may want to see a portion of it.
        // The value defines the default number of points to view from the end of the chart.
        public static int sysNumberOfPoint_DEFA = 100;
        public static int sysNumberOfPoint_MIN = 10;

        //Default margins of the rectangle where charts are in.
        public static int sysChartMarginLEFT = 50;
        public static int sysChartMarginRIGHT = 0;
        public static int sysChartMarginTOP = 0;
        public static int sysChartMarginBOTTOM = 3;

        //Viewport need some space arround to give the feeling of full display 
        public static int sysViewSpaceAtLEFT = 0;  //In percentage
        public static int sysViewSpaceAtRIGHT = 10; //10%

        public static int sysViewMinBarAtLEFT  = 5;  //In bars
        public static int sysViewMinBarAtRIGHT = 5; 

        public static double sysViewSpaceAtTOP = 0.2;  //In value
        public static double sysViewSpaceAtBOT = 0.2;
    }
}
