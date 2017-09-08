using System.Collections.Generic;

namespace GitHubExplorer.Shared.Interfaces
{
    public interface IUsersRepository
    {
        IUser GetUserByLogin(string userLogin);
        IUser GetUserWithReposByLogin(string userLogin);
        IEnumerable<IUserRepo> GetUserRepos(string userLogin, int bestReposCount = 5);
    }
}
