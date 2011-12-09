﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charts
{
    public class Settings
    {
        // Zoom out/in means that the number of points will be increased/decreased respectively 
        // The value defines the scale for zooming 
        public static int sysZoomScale = 5;

        // Chart can be move back and forth.
        // The value defines the number of points to move from the current loccation (viewport).
        public static int sysMoveStep = 5;

        // Chart can have many points but we may want to see a portion of it.
        // The value defines the default number of points to view from the end of the chart.
        public static int sysNumberOfPoints = 100;

        // Chart-moving only occurs after [sysSensibilityPAN] times of mouse move event to slow dow the moving.
        // The higher value of [sysSensibilityPAN], the slower chart-moving speed is.
        public static int sysSensibilityPAN = 3; //5


        //Default margins of the rectangle where charts are in.
        public static int sysChartMarginLEFT = 50;
        public static int sysChartMarginRIGHT = 0;
        public static int sysChartMarginTOP = 0;
        public static int sysChartMarginBOTTOM = 3;

        //Viewport need some space arround to give the feelig of full display 
        public static double sysViewportMarginLEFT  = 0.0; //In percent , 5%
        public static double sysViewportMarginRIGHT = 0.1;  
        public static double sysViewportMarginTOP = 0.2;  //In value
        public static double sysViewportMarginBOT = 0.2;
    }
}
