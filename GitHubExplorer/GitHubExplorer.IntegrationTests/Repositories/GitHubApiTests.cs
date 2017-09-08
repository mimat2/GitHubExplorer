using GitHubExplorer.Repository;
using GitHubExplorer.Shared.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.IntegrationTests.Repositories
{
    [TestClass]
    public class GitHubApiTests
    {
        [TestMethod]
        public void GitHubApi_CreateApi_Success()
        {
            GitHubApi gitHubApi = new GitHubApi("https://api.github.com/");
            
            Assert.IsNotNull(gitHubApi);
        }

        [TestMethod]
        public void GitHubApi_CreateApi_ThrowsException()
        {
            try
            {
                GitHubApi gitHubApi = new GitHubApi("invalid_address");
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is UriFormatException);
            }
        }

        [TestMethod]
        public void GitHubApi_GetUserByLogin_GetAndIsTheSame()
        {
            GitHubApi gitHubApi = new GitHubApi("https://api.github.com/");
            string login = "mimat2";

            var result = gitHubApi.GetUserByLogin(login);

            Assert.IsNotNull(result);
            Assert.AreEqual(login, result.Login);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsFalse(result.UserRepos.Any());
        }

        [TestMethod]
        public void GitHubApi_GetUserRepos_GetAndExistsAny()
        {
            GitHubApi gitHubApi = new GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUserRepos("mimat2");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GitHubApi_GetUserWithReposByLogin_GetUserAndExistAnyRepo()
        {
            GitHubApi gitHubApi = new GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUserWithReposByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Login);
            Assert.AreNotEqual("", result.Login);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsTrue(result.UserRepos.Any());
        }
    }
}
