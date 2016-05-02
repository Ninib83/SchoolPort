using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolPort;
using System.Collections.Generic;

namespace UnitTestDelete
{
    [TestClass]
    public class DeleteStudent
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School();

            //arrange
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "1", "", "", "", "" });
            list.Add(new string[] { "2", "", "", "", "" });
            list.Add(new string[] { "5", "", "", "", "" });
            list.Add(new string[] { "6", "", "", "", "" });
            string input = "5";
            bool sum = true;

            //act
            var result = school.Delete(list, input);

            //assert
            Assert.AreEqual(sum, result);

        }
    }
}
