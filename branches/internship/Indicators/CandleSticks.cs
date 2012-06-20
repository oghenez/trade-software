using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application.Indicators;
using commonClass;


namespace Indicators
{
    /// <summary>
    /// Doji Indicator
    /// </summary>
    public class CDLDojiHelper : Helpers
    {
        public CDLDojiHelper()
        {
            Init(typeof(CDLDoji), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }
    
    public class CDLDoji : DataSeries
    {
        /// <summary>
        /// Static method to create Doji DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CDLDoji Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLDoji)obj;

            //Create Doji, cache it, return it
            CDLDoji doji = new CDLDoji(ds, description);
            ds.Cache.Add(description, doji);
            return doji;
        }

        /// <summary>
        /// Doji indicators
        /// </summary>
        /// <param name="db">data to calculate Doji</param>        
        /// <param name="name"></param>
        public CDLDoji(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            //retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);
            retCode = Core.CdlDoji(0, db.Count - 1, db.Open.Values,db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// Harami Indicator
    /// </summary>
    public class CDLHaramiHelper : Helpers
    {
        public CDLHaramiHelper()
        {
            Init(typeof(CDLHarami), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }
    
    public class CDLHarami : DataSeries
    {
        /// <summary>
        /// Static method to create Harami DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CDLHarami Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLHarami)obj;

            //Create Doji, cache it, return it
            CDLHarami indicator = new CDLHarami(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Harami indicators
        /// </summary>
        /// <param name="db">data to calculate Doji</param>        
        /// <param name="name"></param>
        public CDLHarami(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            //retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);
            retCode = Core.CdlHarami(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// Harami Cross Indicator
    /// </summary>
    public class CDLHaramiCrossHelper : Helpers
    {
        public CDLHaramiCrossHelper()
        {
            Init(typeof(CDLHaramiCross), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDLHaramiCross : DataSeries
    {
        /// <summary>
        /// Static method to create Harami DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CDLHaramiCross Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLHaramiCross)obj;

            //Create Doji, cache it, return it
            CDLHaramiCross indicator = new CDLHaramiCross(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Harami indicators
        /// </summary>
        /// <param name="db">data to calculate Doji</param>        
        /// <param name="name"></param>
        public CDLHaramiCross(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            //retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);
            retCode = Core.CdlHaramiCross(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// Harami Cross Indicator
    /// </summary>
    public class CdlMorningStarHelper : Helpers
    {
        public CdlMorningStarHelper()
        {
            Init(typeof(CdlMorningStar), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CdlMorningStar : DataSeries
    {
        /// <summary>
        /// Static method to create Harami DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CdlMorningStar Series(DataBars ds,double optInPenetration, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CdlMorningStar)obj;

            //Create Doji, cache it, return it
            CdlMorningStar indicator = new CdlMorningStar(ds,optInPenetration, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Harami indicators
        /// </summary>
        /// <param name="db">data to calculate Doji</param>        
        /// <param name="name"></param>
        public CdlMorningStar(DataBars db,double optInPenetration, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            //retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);
            retCode = Core.CdlMorningStar(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, optInPenetration,out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// 2 Crows Indicator
    /// </summary>
    public class CDL2CROWSHelper : Helpers
    {
        public CDL2CROWSHelper()
        {
            Init(typeof(CDL2CROWS), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL2CROWS : DataSeries
    {        
        public static CDL2CROWS Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL2CROWS)obj;

            //Create Doji, cache it, return it
            CDL2CROWS indicator = new CDL2CROWS(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }
       
        public CDL2CROWS(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            //retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);
            retCode = Core.Cdl2Crows(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);            

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDL3BLACKCROWS Indicator
    /// </summary>
    public class CDL3BLACKCROWSHelper : Helpers
    {
        public CDL3BLACKCROWSHelper()
        {
            Init(typeof(CDL3BLACKCROWS), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3BLACKCROWS : DataSeries
    {
        public static CDL3BLACKCROWS Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3BLACKCROWS)obj;

            //Create Doji, cache it, return it
            CDL3BLACKCROWS indicator = new CDL3BLACKCROWS(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3BLACKCROWS(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];
            
            retCode = Core.Cdl3BlackCrows(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDL3INSIDE Indicator
    /// </summary>
    public class CDL3INSIDEHelper : Helpers
    {
        public CDL3INSIDEHelper()
        {
            Init(typeof(CDL3INSIDE), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3INSIDE : DataSeries
    {
        public static CDL3INSIDE Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3INSIDE)obj;

            //Create Doji, cache it, return it
            CDL3INSIDE indicator = new CDL3INSIDE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3INSIDE(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.Cdl3Inside(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDL3LINESTRIKE Indicator
    /// </summary>
    public class CDL3LINESTRIKEHelper : Helpers
    {
        public CDL3LINESTRIKEHelper()
        {
            Init(typeof(CDL3LINESTRIKE), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3LINESTRIKE : DataSeries
    {
        public static CDL3LINESTRIKE Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3LINESTRIKE)obj;

            //Create Doji, cache it, return it
            CDL3LINESTRIKE indicator = new CDL3LINESTRIKE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3LINESTRIKE(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.Cdl3LineStrike(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDL3OUTSIDE Indicator
    /// </summary>
    public class CDL3OUTSIDEHelper : Helpers
    {
        public CDL3OUTSIDEHelper()
        {
            Init(typeof(CDL3OUTSIDE), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3OUTSIDE : DataSeries
    {
        public static CDL3OUTSIDE Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3OUTSIDE)obj;

            //Create Doji, cache it, return it
            CDL3OUTSIDE indicator = new CDL3OUTSIDE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3OUTSIDE(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.Cdl3Outside(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDL3STARSINSOUTH Indicator
    /// </summary>
    public class CDL3STARSINSOUTHHelper : Helpers
    {
        public CDL3STARSINSOUTHHelper()
        {
            Init(typeof(CDL3STARSINSOUTH), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3STARSINSOUTH : DataSeries
    {
        public static CDL3STARSINSOUTH Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3STARSINSOUTH)obj;

            //Create Doji, cache it, return it
            CDL3STARSINSOUTH indicator = new CDL3STARSINSOUTH(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3STARSINSOUTH(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.Cdl3StarsInSouth(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }


    /// <summary>
    /// CDL3WHITESOLDIERS Indicator
    /// </summary>
    public class CDL3WHITESOLDIERSHelper : Helpers
    {
        public CDL3WHITESOLDIERSHelper()
        {
            Init(typeof(CDL3WHITESOLDIERS), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDL3WHITESOLDIERS : DataSeries
    {
        public static CDL3WHITESOLDIERS Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDL3WHITESOLDIERS)obj;

            //Create Doji, cache it, return it
            CDL3WHITESOLDIERS indicator = new CDL3WHITESOLDIERS(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDL3WHITESOLDIERS(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.Cdl3WhiteSoldiers(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDLABANDONEDBABY Indicator
    /// </summary>
    public class CDLABANDONEDBABYHelper : Helpers
    {
        public CDLABANDONEDBABYHelper()
        {
            Init(typeof(CDLABANDONEDBABY), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDLABANDONEDBABY : DataSeries
    {
        public static CDLABANDONEDBABY Series(DataBars ds,double optInPenetration, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLABANDONEDBABY)obj;

            //Create Doji, cache it, return it
            CDLABANDONEDBABY indicator = new CDLABANDONEDBABY(ds,optInPenetration, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDLABANDONEDBABY(DataBars db,double optInPenetration, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.CdlAbandonedBaby(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values,optInPenetration, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDLADVANCEBLOCK Indicator
    /// </summary>
    public class CDLADVANCEBLOCKHelper : Helpers
    {
        public CDLADVANCEBLOCKHelper()
        {
            Init(typeof(CDLADVANCEBLOCK), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDLADVANCEBLOCK : DataSeries
    {
        public static CDLADVANCEBLOCK Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLADVANCEBLOCK)obj;

            //Create Doji, cache it, return it
            CDLADVANCEBLOCK indicator = new CDLADVANCEBLOCK(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDLADVANCEBLOCK(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.CdlAdvanceBlock(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// CDLBELTHOLD Indicator
    /// </summary>
    public class CDLBELTHOLDHelper : Helpers
    {
        public CDLBELTHOLDHelper()
        {
            Init(typeof(CDLBELTHOLD), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    public class CDLBELTHOLD : DataSeries
    {
        public static CDLBELTHOLD Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CDLBELTHOLD)obj;

            //Create Doji, cache it, return it
            CDLBELTHOLD indicator = new CDLBELTHOLD(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public CDLBELTHOLD(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.CdlBeltHold(0, db.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
