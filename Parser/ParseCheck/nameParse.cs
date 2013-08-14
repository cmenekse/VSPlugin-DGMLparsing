using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Parser;

namespace ParseCheck
{
    [TestClass]
    public class nameParse
    {
        [TestMethod]
        public void extractNameCheck1()
        {
            string str = "Name=Greater";
            string extracted = ParseTools.extractName(str);
            Assert.AreEqual("Greater", extracted);
        }
        [TestMethod]
        public void extractNameCheck2()
        {
            string str = "(@28 @77 @2089 Member=(Name=AppendDotNetFrameworks @2785))";
            string extracted = ParseTools.extractName(str);
            Assert.AreEqual("AppendDotNetFrameworks", extracted);
        }
        
    }
}
