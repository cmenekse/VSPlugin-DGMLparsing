using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Parser;

namespace ParseCheck
{
    [TestClass]
    public class overloadingParseCheck
    {
        [TestMethod]
        public void overloadingParseWithSingle()
        {
            string str = "@1 @2 @3 @4";
            string[] splitted = ParseTools.overloadedParse(str);
            Assert.AreEqual("@1 @2 @3 @4", splitted[0].ToString());
        }
        [TestMethod]
        public void overloadingParseWithMultiple()
        {
            string str = "@1 @2 @3 @4,@5 @6";
            string[] splitted = ParseTools.overloadedParse(str);
            Assert.AreEqual("@1 @2 @3 @4", splitted[0].ToString());
            Assert.AreEqual("@5 @6", splitted[1].ToString());
        }
        [TestMethod]
        public void extractingOverloadingParameters()
        {
            string str="<Alias n=\"285\" Id=\"OverloadingParameters=[@284]\" />";
            string extracted=ParseTools.extractOverloadedPart(str);
            Assert.AreEqual("@284",extracted);
        }
       
    }
   
}
