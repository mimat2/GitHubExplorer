using GitHubExplorer.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GitHubExplorer.Tests.Helpers
{
    [TestClass]
    public class WebRequestHelperTests
    {
        [TestMethod]
        public void WebRequestHelper_CallGetRequestWithCorrectUrl_SuccessAndAvailable()
        {
            var request = WebRequestHelper.CallGetRequest("http://www.google.com");
            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void WebRequestHelper_CallGetRequestWithIncorrectUrl_ThrowsException()
        {
            try
            {
                var request = WebRequestHelper.CallGetRequest("incorrectUrl");
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is UriFormatException);
            }
        }
    }
}
