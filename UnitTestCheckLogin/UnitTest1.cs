using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;

namespace UnitTestCheckLogin
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();
            //arrange
            string[] sum = { "Admin", "Lösen" };

            //act
            var result = school.CheckLogin();

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
