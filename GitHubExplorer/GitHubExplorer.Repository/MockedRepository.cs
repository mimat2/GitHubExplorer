using GitHubExplorer.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubExplorer.Shared.Models;

namespace GitHubExplorer.Repository
{
    public class MockedRepository : IUsersRepository
    {
        public MockedRepository()
        {
            mockedUser = new UserDto
            {
                Login = "User login",
                Name = "User name",
                Location = "User Location",
                Avatar_Url = "https://i.vimeocdn.com/portrait/58832_300x300"
            };

            mockedUserRepos = new List<UserRepoDto>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                mockedUserRepos.Add(new UserRepoDto
                {
                    Description = "Repo description",
                    Name = "Repo name",
                    Stargazers_Count = rand.Next(0, 100),
                    Svn_Url = "http://www.google.com"
                });
            }
        }

        private UserDto mockedUser;
        private List<UserRepoDto> mockedUserRepos;

        public UserDto GetUserByLogin(string userLogin)
        {
            mockedUser.Login = userLogin;

            return mockedUser;
        }

        public UserDto GetUserWithReposByLogin(string userLogin)
        {
            mockedUser.Login = userLogin;
            mockedUser.UserRepos = GetUserRepos(mockedUser.Login);

            return mockedUser;
        }

        public IEnumerable<UserRepoDto> GetUserRepos(string userLogin, int bestReposCount = 5)
        {
            return mockedUserRepos.OrderByDescending(r => r.Stargazers_Count).Take(bestReposCount);
        }
    }
}
