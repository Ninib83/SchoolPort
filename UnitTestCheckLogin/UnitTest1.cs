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
            school.GetData();
            school.SplitData();
            var result = school.CheckLogin();

            //assert
            CollectionAssert.AreEqual(sum, result);
        }
    }
}
