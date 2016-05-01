using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;
using System.Collections.Generic;

namespace UnitTestCreate
{
    [TestClass]
    public class CreateStudentWithList
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();
            //arrange
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "1", "", "", "", "" });
            string input = "2,teast,aes,aew2131,Class";
            bool sum = true;

            //act
            var result = school.Create(list, input);

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
