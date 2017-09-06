using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Models
{
    public class UserDto
    {
        public UserDto()
        {
            UserRepos = new List<UserRepoDto>();
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<UserRepoDto> UserRepos { get; set; }
    }
}
