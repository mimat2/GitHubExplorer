using GitHubExplorer.Shared.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Models
{
    public class UserDto : IUser
    {
        public static UserDto NullUser = new UserDto() { Login = "User not found", Name = "User not found" };

        public UserDto()
        {
            UserRepos = new List<UserRepoDto>();
        }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public IEnumerable<IUserRepo> UserRepos { get; set; }
    }
}
