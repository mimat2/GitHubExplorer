using GitHubExplorer.Shared.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using GitHubExplorer.Shared.Models;
using GitHubExplorer.Shared.Helpers;

namespace GitHubExplorer.Repository
{
    public class GitHubApi : IUsersRepository
    {
        public string ApiAddress { get; private set; }

        public GitHubApi(string apiAddress)
        {
            ApiAddress = apiAddress.TrimEnd('/');

            ValidateAddres();
        }

        private void ValidateAddres()
        {
            var responseString = WebRequestHelper.CallGetRequest(ApiAddress);

            if (responseString == null)
            {
                throw new InvalidDataException("Invalid API address");
            }

            if (responseString != null)
            {
                JObject deserializedRespone = JObject.Parse(responseString);
                var userSearchUrl = (string)deserializedRespone["user_search_url"];
                //jak sprawdzic czy podany adres jest prawidlowy?
            }
        }

        public IEnumerable<UserDto> GetUsersByLogin(string userLogin)
        {
            var url = $"{ApiAddress}/search/users?q={userLogin}+type:user+in:login";
            var responseString = WebRequestHelper.CallGetRequest(url);
            JObject deserializedRespone = JObject.Parse(responseString);

            List<string> serializedUsers = new List<string>();
            foreach (object obj in deserializedRespone["items"])
            {
                serializedUsers.Add(obj.ToString());
            }

            IEnumerable<UserDto> users = serializedUsers.Select(u => new UserDto(u));

            

            //more request but more data - could be blocked by limit exceed
            //List<string> logins = new List<string>();

            //foreach (JObject obj in deserializedRespone["items"])
            //{
            //    logins.Add(obj["login"].ToString());
            //}

            //List<UserDto> users = new List<UserDto>();
            //foreach (string login in logins)
            //{
            //    var userUrl = $"{ApiAddress}/users/{login}";
            //    var userDataResponseString = WebRequestHelper.CallGetRequest(userUrl);
            //    users.Add(new UserDto(userDataResponseString));
            //}

            return users;
        }

        public IEnumerable<RepoDto> GetUserRepos(string userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
