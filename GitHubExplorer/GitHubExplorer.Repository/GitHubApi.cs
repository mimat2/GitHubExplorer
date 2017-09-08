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

            CheckAvailability();
        }

        private void CheckAvailability()
        {
            try
            {
                var responseString = WebRequestHelper.CallGetRequest(ApiAddress);

                if (responseString == null)
                {
                    throw new Exception("Api is unavailable");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }

        public IUser GetUserByLogin(string userLogin)
        {
            try
            {
                var userUrl = $"{ApiAddress}/users/{userLogin}";
                var userResponseString = WebRequestHelper.CallGetRequest(userUrl);
                if (userResponseString.Equals("NotFound"))
                {
                    return UserDto.NullUser;
                }
                var foundUser = JsonConvert.DeserializeObject<UserDto>(userResponseString);
                return foundUser;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }

        public IUser GetUserWithReposByLogin(string userLogin)
        {
            var foundUser = GetUserByLogin(userLogin);
            if (foundUser != UserDto.NullUser)
            {
                foundUser.UserRepos = GetUserRepos(foundUser.Login);
            }
            return foundUser;
        }

        public IEnumerable<IUserRepo> GetUserRepos(string userLogin, int bestReposCount = 5)
        {
            try
            {
                var userReposUrl = $"{ApiAddress}/users/{userLogin}/repos";
                var userReposResponseString = WebRequestHelper.CallGetRequest(userReposUrl);
                var userRepos = JsonConvert.DeserializeObject<List<UserRepoDto>>(userReposResponseString);
                return userRepos.OrderByDescending(r => r.StargazersCount).Take(bestReposCount);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }
    }
}
