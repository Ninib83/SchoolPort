using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;
using System.Collections.Generic;

namespace UnitTestCreate
{
    [TestClass]
    public class CreateClassSuccess
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();
            //arrange
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "Class" });
            string input = "1,Th3,John";
            bool sum = true;

            //act
            var result = school.Create(list, input);

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
