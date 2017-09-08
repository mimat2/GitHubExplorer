using System.Collections.Generic;

namespace GitHubExplorer.Shared.Interfaces
{
    public interface IUser
    {
        string Login { get; set; }
        
        string Name { get; set; }
        
        string Location { get; set; }
        
        string AvatarUrl { get; set; }

        IEnumerable<IUserRepo> UserRepos { get; set; }
    }
}
