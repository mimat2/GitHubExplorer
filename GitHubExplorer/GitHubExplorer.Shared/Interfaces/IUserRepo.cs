using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Interfaces
{
    public interface IUserRepo
    {
        string Name { get; set; }
        
        string SvnUrl { get; set; }
        
        int StargazersCount { get; set; }
        
        string Description { get; set; }
    }
}
