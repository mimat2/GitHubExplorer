using GitHubExplorer.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Models
{
    public class NullUser : UserDto
    {
        public NullUser()
        {
            Login = "User not found";
            Name = "User not found";
        }
    }
}
