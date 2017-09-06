using GitHubExplorer.Shared.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using GitHubExplorer.Shared.Models;
using GitHubExplorer.Shared.Helpers;

namespace GitHubExplorer.Repository
{
    public class GitHubApi : IUsersRepository
    {
        public string ApiAddress { get; private set; }

        public GitHubApi(string apiAddress)
        {
            ApiAddress = apiAddress.TrimEnd('/');

            CheckApiAvailability();
        }

        private void CheckApiAvailability()
        {
            var responseString = WebRequestHelper.CallGetRequest(ApiAddress);

            if (responseString == null)
            {
                throw new Exception("Api address response is null");
            }
        }

        public UserDto GetUserByLogin(string userLogin)
        {
            var userUrl = $"{ApiAddress}/users/{userLogin}";
            var userResponseString = WebRequestHelper.CallGetRequest(userUrl);
            var foundUser = JsonConvert.DeserializeObject<UserDto>(userResponseString);
            return foundUser;            
        }

        public UserDto GetUserWithReposByLogin(string userLogin)
        {
            var foundUser = GetUserByLogin(userLogin);
            foundUser.UserRepos = GetUserRepos(foundUser.Login);
            return foundUser;
        }

        public IEnumerable<UserRepoDto> GetUserRepos(string userLogin, int bestReposCount = 5)
        {
            var userReposUrl = $"{ApiAddress}/users/{userLogin}/repos";
            var userReposResponseString = WebRequestHelper.CallGetRequest(userReposUrl);
            var userRepos = JsonConvert.DeserializeObject<List<UserRepoDto>>(userReposResponseString);
            userRepos.OrderByDescending(r => r.Stargazers_Count).Take(bestReposCount);
            return userRepos;
        }
    }
}
