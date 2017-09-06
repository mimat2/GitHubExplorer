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
        public UserDto(string login, string name, string location, string avatarUrl, string reposUrl)
        {
            Login = login;
            Name = name;
            Location = location;
            AvatarUrl = avatarUrl;
            ReposUrl = reposUrl;
        }

        public UserDto(string jsonSerializedUser)
        {
            JObject deserializedUserObject = JObject.Parse(jsonSerializedUser);
            Login = (string)deserializedUserObject["login"];
            Name = (string)deserializedUserObject["name"];
            Location = (string)deserializedUserObject["location"];
            AvatarUrl = (string)deserializedUserObject["avatar_url"];
            ReposUrl = (string)deserializedUserObject["repos_url"];
        }

        public string Login { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public string AvatarUrl { get; private set; }
        public string ReposUrl { get; private set; }
    }
}
