using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;

namespace UnitTestAskForLogin
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();

            //Arrenge
            string User = "Admin";
            string Pass = "Pass";

            bool sum = true;

            //act
            school.GetData();
            school.SplitData();
            bool result = school.AskForLogin(User, Pass);

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
