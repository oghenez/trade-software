using baseClass.forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace QuantumTest
{
    
    
    /// <summary>
    ///This is a test class for baseApplicationTest and is intended
    ///to contain all baseApplicationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class baseApplicationTest
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
        ///A test for CheckValid: checking connection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("baseClass.dll")]
        public void CheckValidTest()
        {
            //baseApplication_Accessor target = new baseApplication_Accessor(); // TODO: Initialize to an appropriate value
            //bool expected = false; // TODO: Initialize to an appropriate value
            //bool actual;
            //actual = target.CheckValid();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
            Assert.AreEqual(DataAccess.Libs.CheckConnection(), true);
        }
    }
}
