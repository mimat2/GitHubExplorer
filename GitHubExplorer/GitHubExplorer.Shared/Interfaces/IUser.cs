using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
