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
        IEnumerable<UserDto> GetUsersByLogin(string userLogin);
        IEnumerable<RepoDto> GetUserRepos(string userLogin);
    }
}
