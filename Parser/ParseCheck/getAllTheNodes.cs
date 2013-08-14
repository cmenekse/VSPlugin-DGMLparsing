using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Parser;

namespace ParseCheck
{
    [TestClass]
    public class getAllTheNodes
    {
        [TestMethod]
        public void getAllTheNodesRegexJustNumbers()
        {
            string str = "@127 @2 @332 @49";

            MatchCollection matches = ParseTools.getAllIdsFromInput(str);
            Match match = matches[0];
            Assert.AreEqual("127", match.Groups[1].ToString());
            match = matches[1];
            Assert.AreEqual("2", match.Groups[1].ToString());
            match = matches[2];
            Assert.AreEqual("332", match.Groups[1].ToString());
            match = matches[3];
            Assert.AreEqual("49", match.Groups[1].ToString());

        }
        [TestMethod]
        public void getAllTheNodesRegexWithText()
        {
            string str = "(@271 @2809 Type=AutoResetEvent)";

            MatchCollection matches = ParseTools.getAllIdsFromInput(str);
            Match match = matches[0];
            Assert.AreEqual("271", match.Groups[1].ToString());
            match = matches[1];
            Assert.AreEqual("2809", match.Groups[1].ToString());
        }
    }
}
