using GitHubExplorer.Shared.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Tests.Repositories
{
    [TestClass]
    public class GitHubApiTests
    {
        [TestMethod]
        public void GitHubApi_CreateApi_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");
            
            Assert.IsNotNull(gitHubApi);
        }

        [TestMethod]
        public void GitHubApi_CreateApi_ThrowsException()
        {
            try
            {
                GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("invalid_address");
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is UriFormatException);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GitHubApi_FindUser_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");
            var result = gitHubApi.GetUserByLogin("test");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Login);
        }

        [TestMethod]
        public void GitHubApi_GetUserRepos_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");
            var result = gitHubApi.GetUserRepos("test");

            Assert.IsNotNull(result);
        }
    }
}
