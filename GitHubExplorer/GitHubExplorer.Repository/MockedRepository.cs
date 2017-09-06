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
        public IEnumerable<RepoDto> GetUserRepos(string userLogin)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsersByLogin(string userLogin)
        {
            List<UserDto> users = new List<UserDto>();
            for (int i = 0; i < 10; i++)
            {
                users.Add(new UserDto($"login{i}", $"name{i}", $"location{i}", $"avatarUrl{i}", $"reposUrl{i}"));
            }
            return users;
        }
    }
}
