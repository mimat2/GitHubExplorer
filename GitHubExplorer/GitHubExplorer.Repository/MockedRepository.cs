using GitHubExplorer.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
                AvatarUrl = "https://i.vimeocdn.com/portrait/58832_300x300"
            };

            mockedUserRepos = new List<IUserRepo>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                mockedUserRepos.Add(new UserRepoDto
                {
                    Description = "Repo description",
                    Name = "Repo name",
                    StargazersCount = rand.Next(0, 100),
                    SvnUrl = "http://www.google.com"
                });
            }
        }

        private IUser mockedUser;
        private List<IUserRepo> mockedUserRepos;

        public IUser GetUserByLogin(string userLogin)
        {
            mockedUser.Login = userLogin;
            mockedUser.Name = userLogin;

            return mockedUser;
        }

        public IUser GetUserWithReposByLogin(string userLogin)
        {
            mockedUser.Login = userLogin;
            mockedUser.Name = userLogin;
            mockedUser.UserRepos = GetUserRepos(mockedUser.Login);

            return mockedUser;
        }

        public IEnumerable<IUserRepo> GetUserRepos(string userLogin, int bestReposCount = 5)
        {
            return mockedUserRepos.OrderByDescending(r => r.StargazersCount).Take(bestReposCount);
        }
    }
}
