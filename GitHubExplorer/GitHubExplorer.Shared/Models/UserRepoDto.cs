using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Models
{
    public class UserRepoDto
    {
        public UserRepoDto()
        {

        }

        public string Name { get; set; }
        public string Svn_Url { get; set; }
        public int Stargazers_Count { get; set; }
        public string Description { get; set; }
    }
}
