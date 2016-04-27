using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;

namespace UnitTestMenu
{
    [TestClass]
    public class UnitTestMenu
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();

            //Arreage
            int value = 4;
            int sum = 4;

            int result = school.Menu(value);

            Assert.AreEqual(sum, result);
        }
    }
}
