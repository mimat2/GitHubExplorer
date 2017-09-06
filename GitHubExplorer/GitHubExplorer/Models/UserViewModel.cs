using GitHubExplorer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GitHubExplorer.Models
{
    public class UserViewModel
    {
        public UserViewModel(UserDto userDto)
        {
            Login = userDto.Login;
            Name = userDto.Name;
            Location = userDto.Location;
            AvatarUrl = userDto.Avatar_Url;
            UserRepos = userDto.UserRepos;
        }

        public string Login { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public string AvatarUrl { get; private set; }
        public IEnumerable<UserRepoDto> UserRepos { get; private set; }
    }
}