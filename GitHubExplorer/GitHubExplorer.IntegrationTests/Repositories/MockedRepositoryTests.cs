using GitHubExplorer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GitHubExplorer.IntegrationTests.Repositories
{
    [TestClass]
    public class MockedRepositoryTests
    {
        [TestMethod]
        public void MockedRepository_CreateRepository_Success()
        {
            MockedRepository repository = new MockedRepository();

            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void MockedRepository_GetUserByLogin_GetAndIsTheSame()
        {
            MockedRepository repository = new Repository.MockedRepository();
            string login = "mimat2";

            var result = repository.GetUserByLogin(login);

            Assert.IsNotNull(result);
            Assert.AreEqual(login, result.Login);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsFalse(result.UserRepos.Any());
        }

        [TestMethod]
        public void MockedRepository_GetUserRepos_GetAndExistsAny()
        {
            Repository.MockedRepository repository = new Repository.MockedRepository();

            var result = repository.GetUserRepos("mimat2");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void MockedRepository_GetUserWithReposByLogin_GetUserAndExistAnyRepo()
        {
            Repository.MockedRepository repository = new Repository.MockedRepository();

            var result = repository.GetUserWithReposByLogin("mimat2");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Login);
            Assert.AreNotEqual("", result.Login);
            Assert.IsNotNull(result.UserRepos);
            Assert.IsTrue(result.UserRepos.Any());
        }
    }
}
