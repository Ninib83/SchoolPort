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
            string Pass = "Lösen";

            bool sum = true;

            bool result = school.AskForLogin(User, Pass);

            Assert.AreEqual(sum, result);
        }
    }
}
