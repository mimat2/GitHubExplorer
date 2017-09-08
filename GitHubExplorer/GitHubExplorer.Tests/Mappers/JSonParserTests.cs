using GitHubExplorer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubExplorer.Tests.Mappers
{
    [TestClass]
    public class JSonParserTests
    {
        [TestMethod]
        public void JSonParser_UserDeserialize_SuccessAndHaveValues()
        {
            var userJson = GetMockDataFileText("UserJson");

            var deserializedUser = JsonConvert.DeserializeObject<UserDto>(userJson);

            Assert.IsNotNull(deserializedUser);
            Assert.IsNotNull(deserializedUser.Login);
            Assert.IsNotNull(deserializedUser.Name);
            Assert.IsNotNull(deserializedUser.Location);
            Assert.IsNotNull(deserializedUser.AvatarUrl);
        }

        [TestMethod]
        public void JSonParser_UserReposDeserialize_SuccessAndHaveValues()
        {
            var userReposJson = GetMockDataFileText("UserReposJson");

            var deserializedUserRepos = JsonConvert.DeserializeObject<List<UserRepoDto>>(userReposJson);

            Assert.IsNotNull(deserializedUserRepos);
            Assert.IsTrue(deserializedUserRepos.Any());
            var firstRepo = deserializedUserRepos.First();
            Assert.IsNotNull(firstRepo.Name);
            Assert.IsNotNull(firstRepo.Description);
            Assert.IsNotNull(firstRepo.StargazersCount);
            Assert.AreNotEqual(0, firstRepo.StargazersCount);
            Assert.IsNotNull(firstRepo.SvnUrl);
        }

        private string GetMockDataFileText(string fileName)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = $"{directory}\\MockData\\{fileName}.txt";
            return File.ReadAllText(path);
        }
    }
}
