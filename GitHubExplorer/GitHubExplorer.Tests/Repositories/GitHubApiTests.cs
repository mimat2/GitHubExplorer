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
        IUsersRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository.GitHubApi("https://api.github.com/");
        }

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
        public void GitHubApi_UsersSearch_Success()
        {
            GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");

            var result = gitHubApi.GetUsersByLogin("test1");

            Assert.IsNotNull(result);
        }
    }
}
