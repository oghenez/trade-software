using Indicators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using commonClass;
using commonTypes;

namespace QuantumTest
{
    
    
    /// <summary>
    ///This is a test class for MACDTest and is intended
    ///to contain all MACDTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MACDTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SignalSeries
        ///</summary>
        [TestMethod()]
        public void SignalSeriesTest()
        {
            //application.MarketData market = new application.MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day),"SSI");
            application.MarketData stockData = new application.MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"));
            DataSeries ds = null; // TODO: Initialize to an appropriate value
            double fastPeriod = 12; 
            double slowPeriod = 26; 
            double signalPeriod = 9; 
            string name = string.Empty; // TODO: Initialize to an appropriate value
            MACD target = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, name); // TODO: Initialize to an appropriate value
            DataSeries actual;
            actual = target.SignalSeries;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HistSeries
        ///</summary>
        [TestMethod()]
        public void HistSeriesTest()
        {
            DataSeries ds = null; // TODO: Initialize to an appropriate value
            double fastPeriod = 0F; // TODO: Initialize to an appropriate value
            double slowPeriod = 0F; // TODO: Initialize to an appropriate value
            double signalPeriod = 0F; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            MACD target = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, name); // TODO: Initialize to an appropriate value
            DataSeries actual;
            actual = target.HistSeries;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExtraSeries
        ///</summary>
        [TestMethod()]
        public void ExtraSeriesTest()
        {
            DataSeries ds = null; // TODO: Initialize to an appropriate value
            double fastPeriod = 0F; // TODO: Initialize to an appropriate value
            double slowPeriod = 0F; // TODO: Initialize to an appropriate value
            double signalPeriod = 0F; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            MACD target = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, name); // TODO: Initialize to an appropriate value
            DataSeries[] actual;
            actual = target.ExtraSeries;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Series
        ///</summary>
        [TestMethod()]
        public void SeriesTest()
        {
            DataSeries ds = null; // TODO: Initialize to an appropriate value
            double fastPeriod = 0F; // TODO: Initialize to an appropriate value
            double slowPeriod = 0F; // TODO: Initialize to an appropriate value
            double signalPeriod = 0F; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            MACD expected = null; // TODO: Initialize to an appropriate value
            MACD actual;
            actual = MACD.Series(ds, fastPeriod, slowPeriod, signalPeriod, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MACD Constructor
        ///</summary>
        [TestMethod()]
        public void MACDConstructorTest()
        {
            DataSeries ds = null; // TODO: Initialize to an appropriate value
            double fastPeriod = 0F; // TODO: Initialize to an appropriate value
            double slowPeriod = 0F; // TODO: Initialize to an appropriate value
            double signalPeriod = 0F; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            MACD target = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, name);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
