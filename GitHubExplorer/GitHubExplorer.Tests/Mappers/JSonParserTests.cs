﻿using GitHubExplorer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Tests.Mappers
{
    [TestClass]
    public class JSonParserTests
    {
        [TestMethod]
        public void JSonParser_UserDeserialize_Success()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = $"{directory}\\MockData\\UserJson.txt";
            var userJson = File.ReadAllText(path);

            var deserializedUser = JsonConvert.DeserializeObject<UserDto>(userJson);

            Assert.IsNotNull(deserializedUser);
        }

        [TestMethod]
        public void JSonParser_UserReposDeserialize_Success()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = $"{directory}\\MockData\\UserReposJson.txt";
            var userReposJson = File.ReadAllText(path);

            var deserializedUserRepos = JsonConvert.DeserializeObject<List<UserRepoDto>>(userReposJson);

            Assert.IsNotNull(deserializedUserRepos);
        }
    }
}