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
        }

        [TestMethod]
        public void GitHubApi_GetUserByLogin_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUserByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Login);
        }

        [TestMethod]
        public void GitHubApi_GetUserRepos_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUserRepos("mimat2");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GitHubApi_GetUserWithReposByLogin_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUserWithReposByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsTrue(result.UserRepos.Any());
        }
    }
}
