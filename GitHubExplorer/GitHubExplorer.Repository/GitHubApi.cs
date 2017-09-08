using GitHubExplorer.Shared.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using GitHubExplorer.Shared.Models;
using GitHubExplorer.Shared.Helpers;

namespace GitHubExplorer.Repository
{
    /// <summary>
    /// Provides to get info about user and his repositories from GitHub using GitHubApi (https://developer.github.com/v3/)
    /// </summary>
    public class GitHubApi : IUsersRepository
    {
        public GitHubApi(string apiAddress, ILogger logger)
        {
            ApiAddress = apiAddress.TrimEnd('/');
            _logger = logger;

            CheckAvailability();
        }

        public string ApiAddress { get; private set; }
        private readonly ILogger _logger;

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
                _logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Method for get data of specific user from GitHubApi
        /// </summary>
        /// <param name="userLogin">Login of user which you are looking for</param>
        /// <returns>Object containing data of found user</returns>
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
                _logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Method for get data of specific user including his repositories from GitHubApi
        /// </summary>
        /// <param name="userLogin">Login of user which you are looking for</param>
        /// <returns>Object containing data of found user with collection of his repositories</returns>
        public IUser GetUserWithReposByLogin(string userLogin)
        {
            var foundUser = GetUserByLogin(userLogin);
            if (foundUser != UserDto.NullUser)
            {
                foundUser.UserRepos = GetUserRepos(foundUser.Login);
            }
            return foundUser;
        }

        /// <summary>
        /// Method for get repositories of specific user from GitHubApi
        /// </summary>
        /// <param name="userLogin">Login of user which repositories you want to get</param>
        /// <param name="bestReposCount">Number of best repositories to return</param>
        /// <returns>Collection of user repositories</returns>
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
                _logger.LogException(ex);
                throw;
            }
        }
    }
}
