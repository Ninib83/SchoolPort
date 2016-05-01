using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;
using System.Collections.Generic;

namespace UnitTestCreate
{
    [TestClass]
    public class CreateStudentSuccess
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();
            //arrange
            List<string[]> list = new List<string[]>();
            string input = "1,teast,aes,aew2131,class";
            bool sum = true;

            //act
            var result = school.Create(list, input);

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
