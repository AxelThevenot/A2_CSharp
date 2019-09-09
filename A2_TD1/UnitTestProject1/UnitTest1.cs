using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A2_TD1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSqRoot()
        {
            Assert.AreEqual((double)4, TD1.SqRoot(16));
        }
    }
}
