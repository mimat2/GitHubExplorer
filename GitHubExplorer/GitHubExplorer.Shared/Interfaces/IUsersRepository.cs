using GitHubExplorer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Interfaces
{
    public interface IUsersRepository
    {
        UserDto GetUserByLogin(string userLogin);
        UserDto GetUserWithReposByLogin(string userLogin);
        IEnumerable<UserRepoDto> GetUserRepos(string userLogin, int bestReposCount = 5);
    }
}
