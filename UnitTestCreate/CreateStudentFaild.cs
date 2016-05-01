using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;
using System.Collections.Generic;

namespace UnitTestCreate
{
    [TestClass]
    public class CreateStudentFaild
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();
            //arrange
            List<string[]> list = new List<string[]>();
            string input = "1,teast,aes,aew2131";
            bool sum = false;

            //act
            var result = school.Create(list, input);

            //assert
            Assert.AreEqual(sum, result);
        }
    }
}
