using Serg_Sak_pr5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var win = new MainWindow();
            Assert.IsTrue(win.Auth("test", "test"));
            Assert.IsFalse(win.Auth("user1", "12345"));
            Assert.IsFalse(win.Auth("", ""));
            Assert.IsFalse(win.Auth(" ", " "));
        }
    }
}
