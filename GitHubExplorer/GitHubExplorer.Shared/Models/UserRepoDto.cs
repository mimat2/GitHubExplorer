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
    public class UserRepoDto : IUserRepo
    {
        public UserRepoDto()
        {

        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("svn_url")]
        public string SvnUrl { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
