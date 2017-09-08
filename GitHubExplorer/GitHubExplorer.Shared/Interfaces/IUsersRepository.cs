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
        IUser GetUserByLogin(string userLogin);
        IUser GetUserWithReposByLogin(string userLogin);
        IEnumerable<IUserRepo> GetUserRepos(string userLogin, int bestReposCount = 5);
    }
}
