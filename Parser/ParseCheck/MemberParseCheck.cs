using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;

namespace ParseCheck
{
    [TestClass]
    public class MemberParseCheck
    {
        [TestMethod]
        public void getMember1()
        {
            string text = "<Alias n=\"3086\" Id=\"Member=_context\" />";
            string extracted = ParseTools.extractMember(text);
            Assert.AreEqual("_context", extracted);
        }
        [TestMethod]
        public void getMember2()
        {
            string text = "<Link Source=\"@2530\" Target=\"(@28 @77 @2529 Member=(Name=IsAssemblyFileType @285))";
            string extracted=ParseTools.extractMember(text);
            Assert.AreEqual("Name=IsAssemblyFileType @285", extracted);
        }

    }
}
