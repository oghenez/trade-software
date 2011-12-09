using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    public class settings
    {
        // Zoom out/in means that the number of points will be increased/decreased respectively 
        // The value defines the scale for zooming 
        public static int sysZoomScale = 5;

        // Chart can be move back and forth.
        // The value defines the number of points to move from the current loccation (viewport).
        public static int sysMoveStep = 10;

        // Chart can have many points but we may want to see a portion of it.
        // The value defines the default number of points to view from the end of the chart.
        public static int sysNumberOfPoints = 100;

        public static int sysSensibilityPAN = 5;
    }
}
