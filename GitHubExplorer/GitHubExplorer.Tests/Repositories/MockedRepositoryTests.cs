using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Tests.Repositories
{
    [TestClass]
    public class MockedRepositoryTests
    {
        [TestMethod]
        public void MockedRepository_CreateRepository_Success()
        {
            GitHubExplorer.Repository.MockedRepository repository = new Repository.MockedRepository();

            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void MockedRepository_GetUserByLogin_Success()
        {
            GitHubExplorer.Repository.MockedRepository repository = new Repository.MockedRepository();

            var result = repository.GetUserByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Login);
        }

        [TestMethod]
        public void MockedRepository_GetUserRepos_Success()
        {
            GitHubExplorer.Repository.MockedRepository repository = new Repository.MockedRepository();

            var result = repository.GetUserRepos("mimat2");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void MockedRepository_GetUserWithReposByLogin_Success()
        {
            GitHubExplorer.Repository.MockedRepository repository = new Repository.MockedRepository();

            var result = repository.GetUserWithReposByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsTrue(result.UserRepos.Any());
        }
    }
}
